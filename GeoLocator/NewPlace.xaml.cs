using GeoLocator.ContextObjects;
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
    /// Interaction logic for NewPlace.xaml
    /// </summary>
    public partial class NewPlace : Window
    {
        NewPlaceContext windowcontext = new NewPlaceContext();
        public NewPlace()
        {
            InitializeComponent();
            DataContext = windowcontext;
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(windowcontext.ToString());
            // Must be interface realization
            //bll.AddNewPlace(new Place() { Name =windowcontext.Name, Type = windowcontext.Type, Description = windowcontext.Description, City = windowcontext.City,Street = windowcontext.Street, StreetNumber = windowcontext.StreetNumber});
            Close();
        }
    }
}
