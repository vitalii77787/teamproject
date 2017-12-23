using GeoLocator.ContextObjects;
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
        public NewMarker()
        {
            InitializeComponent();
            DataContext = markercontext;
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
            if(IsLoginUser==true)
            {
                iscorrect = (markercontext.Name != null && markercontext.Street != null && markercontext.City != null && markercontext.StreetNumber != null && markercontext.MyImageSource != null && markercontext.Description != null && Type!=null);
            }
            else
            {
                iscorrect = (markercontext.Name != null && markercontext.Street != null && markercontext.City != null && markercontext.StreetNumber != null && markercontext.MyImageSource != null && markercontext.Description != null);

            }

            if (iscorrect)
            {
                DialogResult = true;
               // var bytearr = ImageToByte(markercontext.MyImage);
               // MessageBox.Show(markercontext.ToString());
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
            if (FruitListBox.SelectedItem != null)
            {
                var item = FruitListBox.SelectedItem;
                markercontext.Contacts.Remove((string)item);
            }
        }
    }
}
