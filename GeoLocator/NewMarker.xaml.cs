using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace GeoLocator
{
    /// <summary>
    /// Interaction logic for NewMarker.xaml
    /// </summary>
    public partial class NewMarker : Window
    {
        public NewMarker()
        {
            InitializeComponent();
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

        private void SelectImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            if (of.ShowDialog() == true)
            {
                MyImage.Source = new BitmapImage(new Uri(of.FileName));
            }

        }
    }
}
