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
