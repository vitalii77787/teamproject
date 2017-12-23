using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace GeoLocator.ContextObjects
{
    public class MarkerContext : INotifyPropertyChanged
    {
        #region private fields
        private string name;
        private BitmapImage myimage;
        private string type;
        private string description;
        private string city;
        private string street;
        private string streetnumber;
        private string[] contacts;
        #endregion

        public string Name
        {
            get { return name; }
            set
            {
                name = value; OnPropertyChanged("Name");
            }
        }

        public BitmapImage MyImage
        {
            get { return myimage; }
            set
            {
                myimage = value; OnPropertyChanged("MyImage");
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

        public string Description
        {
            get { return description; }
            set
            {
                description = value; OnPropertyChanged("Description");
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

        public string[] Contacts
        {
            get { return contacts; }
            set
            {
                contacts = value; OnPropertyChanged("Contacts");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public override string ToString()
        {
            return "Name: " + Name + "\n";
        }
    }
}
