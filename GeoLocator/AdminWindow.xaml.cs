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
using ClassLib;

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
        DataTable cities;
        DataTable markertypes;
        DataTable logins;
        public AdminWindow()
        {
            InitializeComponent();
            bll = new BllForUi();
            // Markers= bll.GetMarkersOfTypeAsDataTable("supermarket", "Rivne");
            markers = bll.GetAllMarkers();
            cities = bll.GetAllCitiesCollection();
            markertypes = bll.GetAllMarkerTypes();
            logins = bll.GetAllLogins();
            markers.RowChanged += new DataRowChangeEventHandler(Row_Changed);
            markers.RowDeleting += new DataRowChangeEventHandler(Row_Deleted);
            markertypes.RowChanged += new DataRowChangeEventHandler(MarkerTypeRow_Changed);
            markertypes.RowDeleting += new DataRowChangeEventHandler(MarkerTypeRow_Deleted);
            cities.RowChanged += new DataRowChangeEventHandler(CitiesRow_Changed);
            cities.RowDeleting += new DataRowChangeEventHandler(CitiesRow_Deleted);
            Marker_DataGrid.ItemsSource = markers.DefaultView;
            City_DataGrid.ItemsSource = cities.DefaultView;
            MarkerType_DataGrid.ItemsSource = markertypes.DefaultView;
            Logins_DataGrid.ItemsSource = logins.DefaultView;
            // Marker_DataGrid.DataContext = Markers;
        }

        private void CitiesRow_Deleted(object sender, DataRowChangeEventArgs e)
        {
            var Id = (int)e.Row["Id"];
            //bll.DeleteCity(int id);
        }

        private void CitiesRow_Changed(object sender, DataRowChangeEventArgs e)
        {
            var Id = (int)e.Row["Id"];
            var  Name = (string)e.Row["Name"];
            //bll.UpdateCity(int id, string name);
        }

        IBllForUi.IBll bll;



        private void AddClick(object sender, RoutedEventArgs e)
        {
            switch (DataBase_TabControl.SelectedIndex)
            {
                case 0:
                    {
                        NewMarker newMarker = new NewMarker("admin");
                        newMarker.ShowDialog();
                        Marker_DataGrid.ItemsSource = bll.GetAllMarkers().DefaultView;
                    }
                    break;
                case 1:
                    {
                       
                        break;
                    }
                case 2:
                    {
                        //NewMarkerType newMarkerType = new NewMarkerType();
                        //newMarkerType.ShowDialog();
                        MarkerType_DataGrid.ItemsSource = bll.GetAllMarkerTypes().DefaultView;
                        break;
                    }
                case 3:
                    {
                        break;
                    }
                default:
                    break;
            }
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

        private void MarkerTypeRow_Changed(object sender, DataRowChangeEventArgs e)
        {
            var Id = (int)e.Row["Id"];
            var Name = (string)e.Row["Name"];
            var Markers = (string[])e.Row["Markers"];
            //bll.UpdateMarkerType(int id, string name);
        }
        private void MarkerTypeRow_Deleted(object sender, DataRowChangeEventArgs e)
        {
            var Id = (int)e.Row["Id"];
            //bll.DeleteMarkerType(int id);
        }
        private void Row_Changed(object sender, DataRowChangeEventArgs e)
        {
            //Console.WriteLine("Row_Changed Event: name={0}; action={1}",
            //    e.Row["name"], e.Action);
            var Id = (int)e.Row["Id"];
            var Name = (string)e.Row["Name"];
            var City = e.Row["City"].ToString();
            var Street = (string)e.Row["Street"];
            var Number = (string)e.Row["Number"];
            var Description = (string)e.Row["Description"];
            var Lat = (double)e.Row["Lat"];
            var Lng = (double)e.Row["Lng"];
            var UserName = (string)e.Row["UserName"];
            var Picture = (byte[])e.Row["Picture"];
            var MarkerType = (string)e.Row["MarkerType"];
            var Contacts = (string[])e.Row[11];
            Marker marker = new Marker()
            {
                Id = (int)e.Row["Id"],
                Name = (string)e.Row["Name"],
                City = "Rivne",
                Street = (string)e.Row["Street"],
                Number = (string)e.Row["Number"],
                Description = (string)e.Row["Description"],
                Lat = (double)e.Row["Lat"],
                Lng = (double)e.Row["Lng"],
                UserName = (string)e.Row["UserName"],
                Picture = (byte[])e.Row["Picture"],
                MarkerType = (string)e.Row["MarkerType"],
                Contacts = (string[])e.Row[11]
            };
            //IBll bll = new BllForUi();
            bll.UpdateMarker(marker);
            Marker_DataGrid.ItemsSource = bll.GetAllMarkers().DefaultView;
        }

        private void Row_Deleted(object sender, DataRowChangeEventArgs e)
        {
            int id = (int)e.Row["Id"];
            bll.DeleteMarker(id);
            Marker_DataGrid.ItemsSource = bll.GetAllMarkers().DefaultView;
        }
    }
}
