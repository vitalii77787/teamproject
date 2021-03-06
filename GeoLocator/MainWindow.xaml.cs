﻿using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using IBllForUi;
using ClassLib;
using System.IO;
using System.Windows.Threading;
using GMap.NET.WindowsPresentation;
using GMap.NET.MapProviders;
using GeoLocator.ContextObjects;

namespace GeoLocator
{
    //Knyaz Oleg comments 17.43
    //Knyaz Oleg comments 17.43
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoginName = string.Empty;
            bll = new BllForUi();
            MarkerTypes_combo.ItemsSource = bll.GetAllPlaceTypes();
        }

        IBllForUi.IBll bll;
        public string LoginName { get; set; }
        public string UserCity { get; set; }
        public string UserStreetName { get; set; }
        public string UserStreetNumber { get; set; }
        List<PointLatLng> points = new List<PointLatLng>();
        bool IsAddedRoute = false;
        //Image defaultMarkerImage = null;

        private void mapView_Loaded(object sender, RoutedEventArgs e)
        {
            GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            // choose your provider here
            mapView.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            mapView.MinZoom = 10;
            mapView.MaxZoom = 18;
            // whole world zoom
            mapView.Zoom = 12;
            // lets the map use the mousewheel to zoom
            mapView.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            // lets the user drag the map
            mapView.CanDragMap = true;
            // lets the user drag the map with the left mouse button
            mapView.DragButton = MouseButton.Left;
            mapView.Position = new PointLatLng(50.6231, 26.2274);
            //GMap.NET.WindowsPresentation.GMapMarker marker = new GMap.NET.WindowsPresentation.GMapMarker(new PointLatLng(50.6188152, 26.2596711));
            //RotateTransform rotateTransform2 = new RotateTransform(-90);
            //WpfShapes.SpeechBubble diamond = new WpfShapes.SpeechBubble
            //{
            //    RenderTransform=rotateTransform2,
            //    Height = 5,
            //    Width = 15,
            //    Fill = new SolidColorBrush(Colors.Violet),
            //    Stroke = new SolidColorBrush(Colors.Black),
            //    StrokeThickness = 2
            //};
            //marker.Shape = diamond;
            //mapView.Markers.Add(marker);
        }

        private void OpenConstruct(object sender, RoutedEventArgs e)
        {
            NewPlace np = new NewPlace();
            np.Show();
            this.IsEnabled = false;
        }

        private void OpenNewMarker(object sender, RoutedEventArgs e)
        {
            NewMarker nm = new NewMarker(LoginName);
            string loginStatus = bll.GetLoginStatusOfUser(LoginName);
            if (LoginName != string.Empty)
            {
                nm.IsAdminUser = false;
                if (loginStatus == "admin")
                {
                    nm.IsAdminUser = true;
                    nm.MarkerType_combo.Visibility = Visibility.Visible;
                    nm.MarkerType_combo.ItemsSource = bll.GetAllPlaceTypes();
                }
                nm.ShowDialog();
            }
            else
            {
                MessageBox.Show("You have to log in.");
            }
            //bool? res = nm.ShowDialog();
            //if (res.HasValue && res.Value)
            //{
            //    if (LoginName != string.Empty)
            //    {
            //        //Maybe new Task?
            //        AddUserPlace(nm.DataContext as MarkerContext);
            //    }
            //    AddNewMarkerToMap((nm.DataContext as MarkerContext).City, (nm.DataContext as MarkerContext).Street, (nm.DataContext as MarkerContext).StreetNumber, (nm.DataContext as MarkerContext).MyImageSource, (nm.DataContext as MarkerContext).Description, (nm.DataContext as MarkerContext).Contacts.ToArray());
            //}
            //else
            //{
                
            //}
            //nm.ShowDialog();
            //this.IsEnabled = false;
        }

        private void AddUserPlace(MarkerContext context)
        {
            PointLatLng pointLatLng = GetCoordinates(context.City, context.Street, context.StreetNumber);
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(context.MyImageSource));
            var byteimage = ImageToByte(image.Source as BitmapImage);
            Marker newmarker = new Marker() { Name = context.Name, City = context.City, Street = context.Street, Number = context.StreetNumber, Contacts = context.Contacts.ToArray(), Description = context.Description, Lat = pointLatLng.Lat, Lng = pointLatLng.Lng, MarkerType = context.Type, Picture = byteimage, UserName = LoginName };
            bll.AddNewPlace(newmarker);
        }

        public Byte[] ImageToByte(BitmapImage imageSource)
        {
            Stream stream = imageSource.StreamSource;
            Byte[] buffer = null;
            if (stream != null && stream.Length > 0)
            {
                using (BinaryReader br = new BinaryReader(stream))
                {
                    buffer = br.ReadBytes((Int32)stream.Length);
                }
            }
            return buffer;
        }

        private void ShowMarkers_btn_Click(object sender, RoutedEventArgs e)
        {

            if (MarkerTypes_combo.Text.Length != 0)
            {
                if (mapView.Markers.Count() > 0)
                {
                    mapView.Markers.Clear();
                }
                List<Marker> markers;
                if (LoginName.Length > 0 && MarkerTypes_combo.Text == "user")
                {
                    markers = bll.GetMarkersOfUser(LoginName);
                }
                else
                {
                    markers = bll.GetMarkersOfType(MarkerTypes_combo.Text, "Rivne");
                }
                foreach (var item in markers)
                {
                    AddNewMarkerToMap(item);
                }
                PointLatLng pointLatLng = new PointLatLng();
                double distanceMin = double.MaxValue;
                if (LoginName.Length > 0)
                {
                    PointLatLng userStart = GetCoordinates(UserCity, UserStreetName, UserStreetNumber);
                    foreach (var item in markers)
                    {
                        double distance = CalculateDistance(userStart.Lat, userStart.Lng, item.Lat, item.Lng);
                        if (distanceMin > distance)
                        {
                            distanceMin = distance;
                            pointLatLng.Lat = item.Lat;
                            pointLatLng.Lng = item.Lng;
                        }
                    }
                    try
                    {
                        IsAddedRoute = true;
                        ShowRoute(pointLatLng);
                    }
                    catch (Exception)
                    {
                        IsAddedRoute = false;
                    }

                }
            }
        }

        private void AddNewMarkerToMap(Marker marker)
        {
            ToolTip toolTip = new ToolTip { Content = marker.Description };
            GMap.NET.WindowsPresentation.GMapMarker markerG = new GMap.NET.WindowsPresentation.GMapMarker(new GMap.NET.PointLatLng(marker.Lat, marker.Lng));
            Image image = new Image();
            image.MouseLeftButtonUp += ((sender, e) => { ImageClick(sender, e, new GMap.NET.PointLatLng(marker.Lat, marker.Lng)); });
            image.MouseEnter += ((sender, e) => { Image_MouseEnter(sender, e, marker.Description, marker.Contacts); });
            image.MouseLeave += Image_MouseLeave;
            image.ToolTip = toolTip;
            BitmapImage biImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(marker.Picture);
            biImg.BeginInit();
            biImg.StreamSource = ms;
            biImg.EndInit();
            ImageSource imgSrc = biImg as ImageSource;
            image.Source = biImg;
            image.Width = 30;
            image.Height = 30;
            markerG.Shape = image;
            markerG.Offset = new Point(-16, -32);
            markerG.ZIndex = int.MaxValue;
            mapView.Markers.Add(markerG);       ///////////////////////
        }

        private void ImageClick(object sender, RoutedEventArgs e, PointLatLng pointLatLng)
        {
            if (LoginName.Length > 0)
            {
                if (IsAddedRoute)
                {
                    mapView.Markers.RemoveAt(mapView.Markers.Count - 1);
                }
                try
                {
                    IsAddedRoute = true;
                    ShowRoute(pointLatLng);
                }
                catch (Exception)
                {
                    IsAddedRoute = false;
                }

            }
        }

        private void AddNewMarkerToMap(string city, string street, string number)
        {
            PointLatLng pointLatLng = GetCoordinates(city, street, number);
            GMap.NET.WindowsPresentation.GMapMarker markerG = new GMap.NET.WindowsPresentation.GMapMarker(pointLatLng);
            Image image = new Image();
            BitmapImage biImg = new BitmapImage();
            byte[] imageByte = bll.GetDefaultPicture();
            MemoryStream ms = new MemoryStream(imageByte);
            biImg.BeginInit();
            biImg.StreamSource = ms;
            biImg.EndInit();
            ImageSource imgSrc = biImg as ImageSource;
            image.Source = biImg;
            image.Width = 30;
            image.Height = 30;
            markerG.Shape = image;
            //markerG.Offset = new Point(-16, -32);
            markerG.Offset = new Point(-5, -5);
            markerG.ZIndex = int.MaxValue;
            mapView.Markers.Add(markerG);       ///////////////////////
        }

        private void AddNewMarkerToMap(string city, string street, string number, string markerimage, string description,string[] contacts)
        {
            ToolTip toolTip = new ToolTip { Content = description};
            foreach (var item in contacts)
            {
                toolTip.Content += "\n" + item;
            }
            PointLatLng pointLatLng = GetCoordinates(city, street, number);
            GMap.NET.WindowsPresentation.GMapMarker markerG = new GMap.NET.WindowsPresentation.GMapMarker(pointLatLng);
            Image image =new Image();
            image.MouseEnter += ((sender, e) => { Image_MouseEnter(sender, e, description, contacts); });
            image.MouseLeave += Image_MouseLeave;
            image.ToolTip = toolTip;
            image.Source = new BitmapImage(new Uri(markerimage)); 
            image.Width = 30;
            image.Height = 30;
            markerG.Shape = image;
            markerG.Offset = new Point(-16, -32);
            //markerG.ZIndex = int.MaxValue;
            mapView.Markers.Add(markerG);       ///////////////////////
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            ToolTipBorder.Opacity = 0;
            DescriptionText.Opacity = 0;
            DescriptionText.Text = "";
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e, string description, string[] contacts)
        {
            ToolTipBorder.Opacity = 80;
            DescriptionText.Opacity = 80;
            DescriptionText.Text = description+"\nContacts:";
            foreach (var item in contacts)
            {
                DescriptionText.Text += "\n" + item;
            }
        }

        private GMap.NET.PointLatLng GetCoordinates(string city, string street, string number)
        {
            GMap.NET.PointLatLng coords = new PointLatLng();
            string address = city + ", " + street + " " + number;
            string url = string.Format(
             "http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=true_or_false&language=ru",
                 Uri.EscapeDataString(address));

            //Выполняем запрос к универсальному коду ресурса (URI).
            System.Net.HttpWebRequest request =
                (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);

            //Получаем ответ от интернет-ресурса.
            System.Net.WebResponse response =
                request.GetResponse();

            //Экземпляр класса System.IO.Stream 
            //для чтения данных из интернет-ресурса.
            System.IO.Stream dataStream =
                response.GetResponseStream();

            //Инициализируем новый экземпляр класса 
            //System.IO.StreamReader для указанного потока.
            System.IO.StreamReader sreader =
                new System.IO.StreamReader(dataStream);

            //Считывает поток от текущего положения до конца.            
            string responsereader = sreader.ReadToEnd();

            //Закрываем поток ответа.
            response.Close();

            System.Xml.XmlDocument xmldoc =
                new System.Xml.XmlDocument();

            xmldoc.LoadXml(responsereader);
            if (xmldoc.GetElementsByTagName("status")[0].ChildNodes[0].InnerText == "OK")
            {
                System.Xml.XmlNodeList nodes =
                    xmldoc.SelectNodes("//location");
                //Получаем широту и долготу.
                foreach (System.Xml.XmlNode node in nodes)
                {
                    coords.Lat =
                       System.Xml.XmlConvert.ToDouble(node.SelectSingleNode("lat").InnerText.ToString());
                    coords.Lng =
                       System.Xml.XmlConvert.ToDouble(node.SelectSingleNode("lng").InnerText.ToString());
                }
            }
            return coords;
        }

        private void Login_btn_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).Content.ToString() == "Login")
            {
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();
                if (loginWindow.IsSuccsesfullLogin)
                {
                    (sender as Button).Content = "Logout";
                    if (loginWindow.LoginStatusName == "user")
                    {
                        LoginName = loginWindow.LoginName;
                        UserCity = loginWindow.City;
                        UserStreetName = loginWindow.Street;
                        UserStreetNumber = loginWindow.Number;
                        points.Add(GetCoordinates(UserCity, UserStreetName, UserStreetNumber));
                    }
                    else
                    {
                        LoginName = loginWindow.LoginName;
                        AdminWindow adminWindow = new AdminWindow();
                        adminWindow.ShowDialog();
                    }
                }
            }
            else
            {
                (sender as Button).Content = "Login";
                LoginName = string.Empty;
                UserCity = string.Empty;
                UserStreetName = string.Empty;
                UserStreetNumber = string.Empty;
            }

        }

        private void Register_btn_Click(object sender, RoutedEventArgs e)
        {
            RegisterNewUser registerNewUser = new RegisterNewUser();
            registerNewUser.ShowDialog();
        }

        private void FindPlace_btn_Click(object sender, RoutedEventArgs e)
        {
            //if (defaultMarkerImage == null)
            //{
            //    defaultMarkerImage = new Image();
            //    BitmapImage biImg = new BitmapImage();
            //    MemoryStream ms = new MemoryStream(bll.GetDefaultPicture());
            //    biImg.BeginInit();
            //    biImg.StreamSource = ms;
            //    biImg.EndInit();
            //    ImageSource imgSrc = biImg as ImageSource;
            //    defaultMarkerImage.Source = imgSrc;
            //}
            //GDirections ss;
            //var xx = GMapProviders.GoogleMap.GetDirections(out ss, GetCoordinates("Рівне", "Соборна", "22"), GetCoordinates("Рівне", "Київська", "12"), false, false, false, false, false);
            //GMapRoute r = new GMapRoute(ss.Route);
            //var a = GMap.NET.MapProviders.GoogleChinaMapProvider.Instance.GetRoute(GetCoordinates("Рівне", "Соборна", "22"), //start
            //    GetCoordinates("Рівне", "Київська", "12"), //end
            //    false, //avoid highways 
            //    true, 0);
            mapView.Markers.Clear();
            if (StreetToFind_field.Text.Length > 0 && NumberToFind_field.Text.Length > 0)
            {
                //AddNewMarkerToMap("Рівне", StreetToFind_field.Text, NumberToFind_field.Text);

                this.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => {
                    AddNewMarkerToMap("Рівне", StreetToFind_field.Text, NumberToFind_field.Text);
                }));
                
            }
            if (LoginName.Length > 0)
            {
                try
                {
                    ShowRoute(StreetToFind_field.Text, NumberToFind_field.Text);
                    IsAddedRoute = true;
                }
                catch (Exception)
                {
                    IsAddedRoute = false;
                }
                
            }
        }

        public static double CalculateDistance(double sLatitude, double sLongitude, double eLatitude,
                               double eLongitude)
        {
            var radiansOverDegrees = (Math.PI / 180.0);

            var sLatitudeRadians = sLatitude * radiansOverDegrees;
            var sLongitudeRadians = sLongitude * radiansOverDegrees;
            var eLatitudeRadians = eLatitude * radiansOverDegrees;
            var eLongitudeRadians = eLongitude * radiansOverDegrees;

            var dLongitude = eLongitudeRadians - sLongitudeRadians;
            var dLatitude = eLatitudeRadians - sLatitudeRadians;

            var result1 = Math.Pow(Math.Sin(dLatitude / 2.0), 2.0) +
                          Math.Cos(sLatitudeRadians) * Math.Cos(eLatitudeRadians) *
                          Math.Pow(Math.Sin(dLongitude / 2.0), 2.0);

            // Using 3956 as the number of miles around the earth
            var result2 = 3956.0 * 2.0 *
                          Math.Atan2(Math.Sqrt(result1), Math.Sqrt(1.0 - result1));

            return result2;
        }

        private void ShowRoute(string street, string streetNumber)
        {
            
            PointLatLng userStart = GetCoordinates(UserCity, UserStreetName, UserStreetNumber);
            PointLatLng endPoint = GetCoordinates("Рівне", street, streetNumber);
            double distance = CalculateDistance(userStart.Lat, userStart.Lng, endPoint.Lat, endPoint.Lng);

            GDirections ss;
            var xx = GMapProviders.GoogleMap.GetDirections(out ss, userStart, endPoint, false, false, true, false, false);
            
            GMapRoute r = new GMapRoute(ss.Route);
            
            r.RegenerateShape(mapView);
            ((System.Windows.Shapes.Path)r.Shape).Stroke = new SolidColorBrush(Colors.Red);
            ((System.Windows.Shapes.Path)r.Shape).StrokeThickness = 5;
            mapView.Markers.Add(r);
        }

        private void ShowRoute(PointLatLng end)
        {

            PointLatLng userStart = GetCoordinates(UserCity, UserStreetName, UserStreetNumber);
            PointLatLng endPoint = end;
            double distance = CalculateDistance(userStart.Lat, userStart.Lng, endPoint.Lat, endPoint.Lng);

            GDirections ss;
            var xx = GMapProviders.GoogleMap.GetDirections(out ss, userStart, endPoint, false, false, true, false, false);

            GMapRoute r = new GMapRoute(ss.Route);

            r.RegenerateShape(mapView);
            ((System.Windows.Shapes.Path)r.Shape).Stroke = new SolidColorBrush(Colors.Red);
            ((System.Windows.Shapes.Path)r.Shape).StrokeThickness = 5;
            mapView.Markers.Add(r);
        }
    }
}
