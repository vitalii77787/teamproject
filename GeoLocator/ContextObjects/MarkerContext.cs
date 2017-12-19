using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace GeoLocator.ContextObjects
{
    public class MarkerContext : IValueConverter, INotifyPropertyChanged
    {
        #region private fields
        private string name;
        private string type;
        private byte[] myimage;
        private Point point;
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

        public byte[] MyImage
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

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
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
