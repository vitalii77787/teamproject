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
            bll = new BllForUi();
            MarkerTypes_combo.ItemsSource = bll.GetAllPlaceTypes();
        }

        IBllForUi.IBll bll;
        public string LoginName { get; set; }
        public string UserCity { get; set; }
        public string UserStreetName { get; set; }
        public string UserStreetNumber { get; set; }
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
            nm.Show();
            this.IsEnabled = false;
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
            GMap.NET.WindowsPresentation.GMapMarker markerG = new GMap.NET.WindowsPresentation.GMapMarker(new GMap.NET.PointLatLng(marker.Lat, marker.Lng));
            Image image = new Image();
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
            MemoryStream ms = new MemoryStream(bll.GetDefaultPicture());
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

        private GMap.NET.PointLatLng GetCoordinates(string city, string street, string number)
        {
            GMap.NET.PointLatLng coords = new PointLatLng();
            string address = city +", " + street + " " + number;
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
                    }
                    else
                    {

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
            if (StreetToFind_field.Text.Length > 0 && NumberToFind_field.Text.Length > 0)
            {
                //AddNewMarkerToMap("Рівне", StreetToFind_field.Text, NumberToFind_field.Text);

                this.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => {
                    AddNewMarkerToMap("Рівне", StreetToFind_field.Text, NumberToFind_field.Text);
                }));
                
            }


        }
    }
}
