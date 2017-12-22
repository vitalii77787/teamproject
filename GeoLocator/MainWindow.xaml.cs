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
            image.Width = 40;
            image.Height = 40;
            markerG.Shape = image;
            markerG.Offset = new Point(-16, -32);
            markerG.ZIndex = int.MaxValue;
            mapView.Markers.Add(markerG);       ///////////////////////
        }
    }
}
