using GMap.NET;
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
            //bll = new BllForUi();
            //MarkerTypes_combo.ItemsSource = bll.GetAllPlaceTypes();
        }

        IBllForUi.IBll bll;
        public string LoginName { get; set; }
        public string UserCity { get; set; }
        public string UserStreetName { get; set; }
        public string UserStreetNumber { get; set; }
        List<PointLatLng> points = new List<PointLatLng>();
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
            NewMarker nm = new NewMarker();
            if (LoginName != string.Empty)
            {
                nm.Type.Visibility = Visibility.Visible;
                nm.Type.ItemsSource = bll.GetAllPlaceTypes();
                nm.IsLoginUser = true;
            }
            bool? res = nm.ShowDialog();
            if (res.HasValue && res.Value)
            {
                if (LoginName != string.Empty)
                {
                    //Maybe new Task?
                    AddUserPlace(nm.DataContext as MarkerContext);
                }
                AddNewMarkerToMap((nm.DataContext as MarkerContext).City, (nm.DataContext as MarkerContext).Street, (nm.DataContext as MarkerContext).StreetNumber, (nm.DataContext as MarkerContext).MyImageSource, (nm.DataContext as MarkerContext).Description, (nm.DataContext as MarkerContext).Contacts.ToArray());
            }
            else
            {
                
            }
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
                List<Marker> markers = bll.GetMarkersOfType(MarkerTypes_combo.Text, "Rivne");
                foreach (var item in markers)
                {
                    AddNewMarkerToMap(item);
                }
            }
        }

        private void AddNewMarkerToMap(Marker marker)
        {
            ToolTip toolTip = new ToolTip { Content = marker.Description };
            GMap.NET.WindowsPresentation.GMapMarker markerG = new GMap.NET.WindowsPresentation.GMapMarker(new GMap.NET.PointLatLng(marker.Lat, marker.Lng));
            Image image = new Image();
            image.ToolTip = toolTip;
            BitmapImage biImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(marker.Picture);
            biImg.BeginInit();
            biImg.StreamSource = ms;
            biImg.EndInit();
            ImageSource imgSrc = biImg as ImageSource;
            image.Source = biImg;
            image.Width = 20;
            image.Height = 20;
            markerG.Shape = image;
            markerG.Offset = new Point(-16, -32);
            markerG.ZIndex = int.MaxValue;
            mapView.Markers.Add(markerG);       ///////////////////////
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
            image.Width = 20;
            image.Height = 20;
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
            image.ToolTip = toolTip;
            image.Source = new BitmapImage(new Uri(markerimage)); 
            image.Width = 20;
            image.Height = 20;
            markerG.Shape = image;
            markerG.Offset = new Point(-16, -32);
            //markerG.ZIndex = int.MaxValue;
            mapView.Markers.Add(markerG);       ///////////////////////
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
                ShowRoute();
            }
        }


        private void ShowRoute()
        {
            
            PointLatLng userStart = GetCoordinates(UserCity, UserStreetName, UserStreetNumber);
            PointLatLng endPoint = GetCoordinates("Рівне", StreetToFind_field.Text, NumberToFind_field.Text);
            //PointLatLng userStart = GetCoordinates(UserCity, "Чебишева", "16");
            //PointLatLng endPoint = GetCoordinates("Рівне", "Соборна", "20");

            //GMap.NET.WindowsPresentation.GMapMarker markerG = new GMap.NET.WindowsPresentation.GMapMarker(routePoints[0]);

            //markerG.Map = new GMap.NET.WindowsPresentation.GMapControl();
            //markerG.Map.CreateRoutePath(listPoints);
            //gMapControl1.Markers.Add(markerG);


            //gMapControl1.CreateRoutePath(listPoints, true);
            //GMap.NET.WindowsPresentation.GMapRoute mRoute = new GMap.NET.WindowsPresentation.GMapRoute(routePoints);
            //mRoute.RegenerateShape(gMapControl1);
            //((System.Windows.Shapes.Path)mRoute.Shape).Stroke = new SolidColorBrush(Colors.Red);
            //((System.Windows.Shapes.Path)mRoute.Shape).StrokeThickness = 20;
            //gMapControl1.Markers.Add(mRoute);

            //GMapRoute gmRoute = new GMapRoute(route.Points);
            //MapRoute mapRoute = GMap.NET.MapProviders.GoogleMapProvider.Instance.GetRoute()
            //MapRoute route2 = GMap.NET.

            GDirections ss;
            var xx = GMapProviders.GoogleMap.GetDirections(out ss, userStart, endPoint, false, false, true, false, false);
            
            GMapRoute r = new GMapRoute(ss.Route);
            r.RegenerateShape(mapView);
            ((System.Windows.Shapes.Path)r.Shape).Stroke = new SolidColorBrush(Colors.Red);
            ((System.Windows.Shapes.Path)r.Shape).StrokeThickness = 5;
            //r.Map.BorderThickness = new Thickness(;
            mapView.Markers.Add(r);
            //mapView.Markers[0].Shape = 
            //MapRoute route2 = GMap.NET.MapProviders.GoogleMapProvider.Instance.GetRoute("Рівне, Чебишева 16", //start
            //    "Рівне, Соборна 20", //end
            //    false, //avoid highways 
            //    true, 0);

            //GMapRoute gmRoute2 = new GMapRoute(route2.Points);

            //mapView.Markers.Add(gmRoute2);
            //gMapControl1.Markers.Add(new GMap.NET.WindowsPresentation.GMapMarker());

            //gMapControl1.UpdateLayout();
        }
    }
}
