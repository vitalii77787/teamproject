using ClassLib;
using GeoLocator.ContextObjects;
using GMap.NET;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;
using ClassLib;
using IBllForUi;

namespace GeoLocator
{
    /// <summary>
    /// Interaction logic for NewMarker.xaml
    /// </summary>
    public partial class NewMarker : Window
    {
        MarkerContext markercontext = new MarkerContext();
        private bool iscorrect=true;
        public bool IsLoginUser { get; set; }
        //Marker marker;
        string loginName = string.Empty;
        IBllForUi.IBll bll;
        public NewMarker(string userName)
        {
            InitializeComponent();
            loginName = userName;
            DataContext = markercontext;
            bll = new BllForUi();
            City_combo.ItemsSource = bll.GetAllCities();
            if (loginName == "admin")
            {
                MarkerType_combo.Visibility = Visibility.Visible;
                MarkerType_combo.ItemsSource = bll.GetAllPlaceTypes();
            }
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window is MainWindow)
                {
                    (window as MainWindow).IsEnabled = true;
                }
            }
            base.OnClosing(e);
        }
        private static BitmapFrame CreateResizedImage(ImageSource source, int width, int height, int margin)
        {
            var rect = new Rect(margin, margin, width - margin * 2, height - margin * 2);

            var group = new DrawingGroup();
            RenderOptions.SetBitmapScalingMode(group, BitmapScalingMode.HighQuality);
            group.Children.Add(new ImageDrawing(source, rect));

            var drawingVisual = new DrawingVisual();
            using (var drawingContext = drawingVisual.RenderOpen())
                drawingContext.DrawDrawing(group);

            var resizedImage = new RenderTargetBitmap(
                width, height,         // Resized dimensions
                96, 96,                // Default DPI values
                PixelFormats.Default); // Default pixel format
            resizedImage.Render(drawingVisual);

            return BitmapFrame.Create(resizedImage);
        }
        private void SelectImage(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            if (of.ShowDialog() == true)
            {
                //MyImage.Source = new BitmapImage(new Uri(of.FileName));
                MyImage.Source=CreateResizedImage(new BitmapImage(new Uri(of.FileName)), (int)btn.Width, (int)btn.Height, 0);
                markercontext.MyImageSource = of.FileName;
            }

        }
        private void Sample1_DialogHost_OnDialogClosing(object sender, DialogClosingEventArgs eventArgs)
        {
            Console.WriteLine("SAMPLE 1: Closing dialog with parameter: " + (eventArgs.Parameter ?? ""));

            //you can cancel the dialog close:
            //eventArgs.Cancel();

            if (!Equals(eventArgs.Parameter, true)) return;

            if (!string.IsNullOrWhiteSpace(FruitTextBox.Text))
            //FruitListBox.Items.Add(FruitTextBox.Text.Trim());
            {
                markercontext.Contacts.Add(FruitTextBox.Text.Trim());
            }
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

        private void BtnOkClick(object sender, RoutedEventArgs e)
        {
            
            if (IsLoginUser == true)
            {
                iscorrect = (markercontext.Name != null && markercontext.Street != null && markercontext.City != null && markercontext.StreetNumber != null && 
                    markercontext.MyImageSource != null && markercontext.Description != null && MarkerType_combo.Text != null);
            }
            else
            {
                iscorrect = (markercontext.Name != null && markercontext.Street != null && markercontext.City != null && markercontext.StreetNumber != null && 
                    markercontext.MyImageSource != null && markercontext.Description != null);

            }

            if (iscorrect)
            {
                DialogResult = true;
                byte[] picture = File.ReadAllBytes(markercontext.MyImageSource);
                PointLatLng pointLatLng = GetCoordinates(markercontext.City, markercontext.Street, markercontext.StreetNumber);
                string markerType = "user";
                if (loginName != "admin")
                {
                    markerType = MarkerType_combo.Text;
                }
                Marker marker = new Marker()
                {
                    Name = markercontext.Name,
                    City = markercontext.City,
                    Contacts = markercontext.Contacts.ToArray(),
                    Description = markercontext.Description,
                    Lat = pointLatLng.Lat,
                    Lng = pointLatLng.Lng,
                    MarkerType = markerType,
                    Number = markercontext.StreetNumber,
                    Picture = picture,
                    Street = markercontext.Street,
                    UserName = loginName
                };
                bll.AddNewPlace(marker);
                MessageBox.Show("New marker was added!");
                Close();
            }
            else
            {
                DialogResult = false;
                MessageBox.Show("Incorrect value!");
                Close();
            }
        }

        private void ClearListBox(object sender, RoutedEventArgs e)
        {
            if (ContactsListBox.SelectedItem != null)
            {
                var item = ContactsListBox.SelectedItem;
                markercontext.Contacts.Remove((string)item);
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
    }
}
