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
        private string type;
        private Point point;
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

        public string Type
        {
            get { return type; }
            set
            {
                type = value; OnPropertyChanged("Type");
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

        public double MyPointX
        {
            get { return point.X; }
            set
            {
                point.X = value; OnPropertyChanged("MyPointX");
            }
        }

        public double MyPointY
        {
            get { return point.Y; }
            set
            {
                point.Y = value; OnPropertyChanged("MyPointY");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public override string ToString()
        {
            return "Name: " + Name + "\n" + "Type: " + Type + "\n" + "Langitude: " + MyPointX + "\n" + "Longitude: " + MyPointY;
        }
    }
}
