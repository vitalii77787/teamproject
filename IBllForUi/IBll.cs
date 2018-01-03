using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBllForUi
{
    public interface IBll
    {
        string[] GetAllPlaceTypes();
        //void AddNewUserPlace(string name, string city, string street, string number, string markerType, double lat, double lng, byte[] picture, string userName,
        //                          string description, string[] contacts); // add place of proper user. Is visible only for this user
        void AddNewPlace(ClassLib.Marker marker); // such added place will be visible for all users
        List<ClassLib.Marker> GetMarkersOfType(string type, string city); // get type of place. For example: supermarket, bank, school etc.
        List<ClassLib.Marker> GetMarkersOfUser(string userName); // get markers to show them on the map
        void AddNewUser(string userName, string password, string city, string street, string number, string loginStatus);
        bool IsSuchUserNameInDB(string userName);
        bool IsValidPassword(string userName, string password);
        string[] GetAllCities();
        string GetLoginStatusOfUser(string userName);
        string[] GetCityStreetAndNumberOfUser(string userName);
        byte[] GetDefaultPicture();
        DataTable GetMarkersOfTypeAsDataTable(string type, string city);
        DataTable GetAllMarkers();
        DataTable GetAllCitiesCollection();
        DataTable GetAllMarkerTypes();
        void UpdateMarker(ClassLib.Marker marker);
        void DeleteMarker(int id);

    }
}
