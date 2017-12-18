using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoLocator.ContextObjects
{
    class NewPlaceContext : INotifyPropertyChanged
    {
        #region private fields
        private string name;
        private string type;
        private string description;
        private string city;
        private string street;
        private string streetnumber;
        #endregion


        public string Name
        {
            get { return name; }
            set
            {
                name = value; OnPropertyChanged("Name");
            }
        }

        public string Type
        {
            get { return type; }
            set
            {
                type = value; OnPropertyChanged("Type");
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                description = value; OnPropertyChanged("Description");
            }
        }

        public string City
        {
            get { return city; }
            set
            {
                city = value; OnPropertyChanged("City");
            }
        }

        public string Street
        {
            get { return street; }
            set
            {
                street = value; OnPropertyChanged("Street");
            }
        }

        public string StreetNumber
        {
            get { return streetnumber; }
            set
            {
                streetnumber = value; OnPropertyChanged("Streetnumber");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public override string ToString()
        {
            return "Name: " + Name + "\n" + "Type: " + Type + "\n" + "Description: " + Description + "\n" + '\n' + "City: " + City + " " + "Street: " + Street + " " + "Streetnumber: " + StreetNumber;
        }
    }
}
