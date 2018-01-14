using GeoLocator.ContextObjects;
using System.Windows;
using IBllForUi;

namespace GeoLocator
{
    /// <summary>
    /// Interaction logic for NewMarkerType.xaml
    /// </summary>
    public partial class NewMarkerType : Window
    {
        IBllForUi.IBll bll;
        NewMarkerTypeContext context = new NewMarkerTypeContext();
        public NewMarkerType()
        {
            InitializeComponent();
            DataContext = context;
        }

        private void OKClick(object sender, RoutedEventArgs e)
        {
            if(context.Name!=null)
            {
                bll.AddNewMarkerType(context.Name);
            }
            Close();
        }
    }
}
