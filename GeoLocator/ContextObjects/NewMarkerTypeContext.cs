using System.ComponentModel;
namespace GeoLocator.ContextObjects
{
    class NewMarkerTypeContext : INotifyPropertyChanged
    {
        #region private fields
        private string name;
        #endregion

        public string Name
        {
            get { return name; }
            set
            {
                name = value; OnPropertyChanged("Name");
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

 