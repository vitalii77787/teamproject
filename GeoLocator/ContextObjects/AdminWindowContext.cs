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
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string City { get; set; }
            public string Street { get; set; }
            public string Number { get; set; }
            public string Type { get; set; }
            public double Lat { get; set; }  // coordinate for google map
            public double Lng { get; set; }  // coordinate long for google map
            public byte[] Picture { get; set; }
            public string Login { get; set; }
            public ObservableCollection<string> Contacts { get; set; }
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string name)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
}
