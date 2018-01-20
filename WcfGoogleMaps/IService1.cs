using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfGoogleMaps
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        void AddNewMarkerType(string name);
        [OperationContract]
        void AddNewCity(string name);
        [OperationContract]
        void UpdateMarkerType(int id, string name);
        [OperationContract]
        void UpdateCity(int id, string name);
        [OperationContract]
        void DeleteMarkerType(int id);
        [OperationContract]
        void DeleteCity(int id);
        [OperationContract]
        void DeleteLogin(int id);
        [OperationContract]
        void UpdateLogin(int id, string name);
        [OperationContract]
        bool IsSuchAddress(string city, string street, string number);

        [OperationContract]
        void AddNewUserPlace(string name, string city, string street, string number, string markerType, double lat, double lng, byte[] picture, string userName,
            string description, string[] contacts);

       
        [OperationContract]
        MarkerWcf[] GetMarkersOfType(string markerType, string city);

        [OperationContract]
        MarkerWcf[] GetMarkersOfUser(string userName);

        [OperationContract]
        void AddNewUser(string userName, byte[] password, string city, string street, string number, string loginStatus);

        [OperationContract]
        bool IsSuchUserNameInDB(string userName);

        [OperationContract]
        bool IsPasswordsEquals(string userName, byte[] password);

        [OperationContract]
        string[] GetAllPlaceTypes();

        [OperationContract]
        string[] GetAllCities();

        [OperationContract]
        string GetLoginStatusOfUser(string userName);

        [OperationContract]
        string[] GetCityStreetAndNumberOfUser(string userName);

        [OperationContract]
        byte[] GetDefaultPicture();

        [OperationContract]
        MarkerWcf[] GetAllMarkersDto();

        [OperationContract]
        CityWcf[] GetAllCitiesDto();

        [OperationContract]
        MarkerTypeWcf[] GetAllMarkerTypesDto();
        [OperationContract]
        LoginWcf[] GetAllLoginDto();
        [OperationContract]
        void UpdateMarker(MarkerWcf newMarker);

        [OperationContract]
        void DeleteMarker(int id);

        [OperationContract]
        void DeleteLogin(string loginName);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class MarkerWcf
    {
        int id;
        string name = string.Empty;
        string description = string.Empty;
        string city = string.Empty;
        string street = string.Empty;
        string number = string.Empty;
        string markerType = string.Empty;
        double lat = 0;
        double lng = 0;
        byte[] picture;
        string userName = string.Empty;
        string[] contacts;

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        [DataMember]
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        [DataMember]
        public string Street
        {
            get { return street; }
            set { street = value; }
        }

        [DataMember]
        public string Number
        {
            get { return number; }
            set { number = value; }
        }

        [DataMember]
        public string MarkerType
        {
            get { return markerType; }
            set { markerType = value; }
        }

        [DataMember]
        public double Lat
        {
            get { return lat; }
            set { lat = value; }
        }

        [DataMember]
        public double Lng
        {
            get { return lng; }
            set { lng = value; }
        }

        [DataMember]
        public byte[] Picture
        {
            get { return picture; }
            set { picture = value; }
        }

        [DataMember]
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        [DataMember]
        public string[] Contacts
        {
            get { return contacts; }
            set { contacts = value; }
        }
    }

    [DataContract]
    public class CityWcf
    {
        int cityid;
        string cityname = string.Empty;
        string[] cityaddresses;

        [DataMember]
        public int CityId
        {
            get { return cityid; }
            set { cityid = value; }
        }

        [DataMember]
        public string CityName
        {
            get { return cityname; }
            set { cityname = value; }
        }
        [DataMember]
        public string[] CityAddresses
        {
            get { return cityaddresses; }
            set { cityaddresses = value; }
        }
    }

    [DataContract]
    public class MarkerTypeWcf
    {
        int id;
        string name = string.Empty;
        string[] markers;

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        [DataMember]
        public string[] Markers
        {
            get { return markers; }
            set { markers = value; }
        }
    }

    [DataContract]
    public class LoginWcf
    {
        int id;
        string name = string.Empty;
        byte[] password;

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        [DataMember]
        public byte[] Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
