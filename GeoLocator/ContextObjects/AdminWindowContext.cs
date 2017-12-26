using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoLocator.ContextObjects
{
    class AdminWindowContext
    {
        public class Marker
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public ObservableCollection<DTOAddress> Address { get; set; }
            public ObservableCollection<DTOMarkerType> Type { get; set; }
            public double Lat { get; set; }  // coordinate for google map
            public double Lng { get; set; }  // coordinate long for google map
            public byte[] Picture { get; set; }
            public ObservableCollection<DTOLogin> Login { get; set; }
            public ObservableCollection<DTOContact> Contacts { get; set; }
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string name)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    public class DTOMarkerType
    {
        public string Name { get; set; }
    }

    public class DTOAddress
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
    }

    public class DTOCity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class DTOLogin
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

    public class DTOContact
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
 
}
