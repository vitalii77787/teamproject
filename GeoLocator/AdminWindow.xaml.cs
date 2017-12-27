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
            bll = new BllForUi();
            markersDataGrid.ItemsSource = bll.GetMarkersOfTypeAsDataTable("supermarket", "Rivne").DefaultView;
        }

        IBllForUi.IBll bll;
    }
}
