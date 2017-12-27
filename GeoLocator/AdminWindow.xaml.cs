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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        //IBllForUi.IBll bll;

        public AdminWindow()
        {
            InitializeComponent();
            //bll = new IBllForUi.BllForUi();
            //Marker_DataGrid.ItemsSource = bll.GetAllMarkers;
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            switch (DataBase_TabControl.SelectedIndex)
            {
                case 0:
                default:
                    break;
            }
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            switch (DataBase_TabControl.SelectedIndex)
            {
                case 0:
                default:
                    break;
            }
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            switch (DataBase_TabControl.SelectedIndex)
            {
                case 0:
                default:
                    break;
            }
        }
    }
}
