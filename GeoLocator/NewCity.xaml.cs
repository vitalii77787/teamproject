using GeoLocator.ContextObjects;
using IBllForUi;
using System.Windows;


namespace GeoLocator
{
    /// <summary>
    /// Interaction logic for NewCity.xaml
    /// </summary>
    public partial class NewCity : Window
    {
        IBllForUi.IBll bll;
        NewCityContext context = new NewCityContext();
        public NewCity()
        {
            InitializeComponent();
            DataContext = context;
            bll = new BllForUi();
        }

        private void OKClick(object sender, RoutedEventArgs e)
        {
            if (context.Name != null)
            {
                //bll.AddNewCity(context.Name);
            }
            Close();
        }
    }
}
