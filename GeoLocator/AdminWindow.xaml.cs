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
        public AdminWindow()
        {
            InitializeComponent();
            bll = new BllForUi();
           // Markers= bll.GetMarkersOfTypeAsDataTable("supermarket", "Rivne");
           var collection= bll.GetAllMarkers();
            collection.RowChanged += new DataRowChangeEventHandler(Row_Changed);
            Marker_DataGrid.ItemsSource = collection.DefaultView;
           // Marker_DataGrid.DataContext = Markers;
        }

        IBllForUi.IBll bll;

        private void AddClick(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {

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
