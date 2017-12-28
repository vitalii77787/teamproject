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
using IBllForUi;
using System.Collections.ObjectModel;
//using GMap;
//using ServerDtoLib;
using System.Data;


namespace GeoLocator
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        //IBllForUi.IBll bll;
        // public ObservableCollection<ClassLib.Marker> Markers { get; set; }
        DataTable markers;
        public AdminWindow()
        {
            InitializeComponent();
            bll = new BllForUi();
           // Markers= bll.GetMarkersOfTypeAsDataTable("supermarket", "Rivne");
          markers= bll.GetAllMarkers();
            markers.RowChanged += new DataRowChangeEventHandler(Row_Changed);
            Marker_DataGrid.ItemsSource = markers.DefaultView;
           // Marker_DataGrid.DataContext = Markers;
        }

        IBllForUi.IBll bll;

        

        private void AddClick(object sender, RoutedEventArgs e)
        {
            NewMarker newMarker = new NewMarker("admin");
            newMarker.ShowDialog();
            Marker_DataGrid.ItemsSource = bll.GetAllMarkers().DefaultView;
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            switch (DataBase_TabControl.SelectedIndex)
            {
                case 0:
                    {
                        while (Marker_DataGrid.SelectedItems.Count >= 1)
                        {
                            DataRowView drv = (DataRowView)Marker_DataGrid.SelectedItem;
                            drv.Row.Delete();
                        }
                        break;
                    }
                case 1:
                    {
                        while (Logins_DataGrid.SelectedItems.Count >= 1)
                        {
                            DataRowView drv = (DataRowView)Logins_DataGrid.SelectedItem;
                            drv.Row.Delete();
                        }
                        break;
                    }
                case 2:
                    {
                        while (MarkerType_DataGrid.SelectedItems.Count >= 1)
                        {
                            DataRowView drv = (DataRowView)MarkerType_DataGrid.SelectedItem;
                            drv.Row.Delete();
                        }
                        break;
                    }
                case 3:
                    {
                        while (City_DataGrid.SelectedItems.Count >= 1)
                        {
                            DataRowView drv = (DataRowView)City_DataGrid.SelectedItem;
                            drv.Row.Delete();
                        }
                        break;
                    }
                default:
                    break;
            }
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {

        }

      
        private static void Row_Changed(object sender, DataRowChangeEventArgs e)
        {
            Console.WriteLine("Row_Changed Event: name={0}; action={1}",
                e.Row["name"], e.Action);
        }
    }
}
