using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDalForUi;
using System.Security.Cryptography;
using System.Data;
using ClassLib;

namespace IBllForUi
{
    public class BllForUi : IBll
    {
        DalUi dalUi = new DalUi();
        public void AddNewPlace(ClassLib.Marker marker)
        {
            dalUi.AddNewUserPlace(marker.Name, marker.City, marker.Street, marker.Number, marker.MarkerType, marker.Lat, marker.Lng, marker.Picture,
                                 marker.UserName, marker.Description, marker.Contacts);
        }

        public void AddNewUser(string userName, string password, string city, string street, string number, string loginStatus)
        {
            var passwordByte = Encoding.ASCII.GetBytes(password);
            var md5 = new MD5CryptoServiceProvider();
            byte[] md5password = md5.ComputeHash(passwordByte);
            dalUi.AddNewUser(userName, md5password, city, street, number, loginStatus);
        }


        public string[] GetAllCities()
        {
            return dalUi.GetAllCities();
        }

        public string[] GetAllPlaceTypes()
        {
            return dalUi.GetAllPlaceTypes();
        }

        public List<ClassLib.Marker> GetMarkersOfType(string type, string city)
        {
            return dalUi.GetMarkersOfType(type, city);
        }

        public List<ClassLib.Marker> GetMarkersOfUser(string userName)
        {
            return dalUi.GetMarkersOfUser(userName);
        }

        public bool IsSuchUserNameInDB(string userName)
        {
            return dalUi.IsSuchUserNameInDB(userName);
        }

        public bool IsValidPassword(string userName, string password)
        {
            var passwordByte = Encoding.ASCII.GetBytes(password);
            var md5 = new MD5CryptoServiceProvider();
            byte[] md5password = md5.ComputeHash(passwordByte);
            return dalUi.IsPasswordsEquals(userName, md5password);
        }

        public string GetLoginStatusOfUser(string userName)
        {
            return dalUi.GetLoginStatusOfUser(userName);
        }

        /// <summary>
        /// Get info about user's address - string[] with 3 elements: string[0] - city, string[1] - street, string[2] - street number
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string[] GetCityStreetAndNumberOfUser(string userName)
        {
            return dalUi.GetCityStreetAndNumberOfUser(userName);
        }

        public byte[] GetDefaultPicture()
        {
            return dalUi.GetDefaultPicture();
        }

        public DataTable GetMarkersOfTypeAsDataTable(string type, string city)
        {
            DataTable markersDataTable = new DataTable("markers");
            DataColumn markerId = markersDataTable.Columns.Add("Id", typeof(Int32));
            markersDataTable.PrimaryKey = new DataColumn[] { markerId };
            markersDataTable.Columns.Add("Name", typeof(string));
            markersDataTable.Columns.Add("Description", typeof(string));
            markersDataTable.Columns.Add("City", typeof(string));
            markersDataTable.Columns.Add("Street", typeof(string));
            markersDataTable.Columns.Add("Number", typeof(string));
            markersDataTable.Columns.Add("MarkerType", typeof(string));
            markersDataTable.Columns.Add("Lat", typeof(double));
            markersDataTable.Columns.Add("Lng", typeof(double));
            markersDataTable.Columns.Add("Picture", typeof(byte[]));
            markersDataTable.Columns.Add("UserName", typeof(string));
            markersDataTable.Columns.Add("Contacts", typeof(string[]));
            List<ClassLib.Marker> markersList = GetMarkersOfType(type, city);
            //int i = 0;
            foreach (var item in markersList)
            {
                DataRow dr = markersDataTable.NewRow();
                dr["Id"] = item.Id;
                dr["Name"] = item.Name;
                dr["Description"] = item.Description;
                dr["City"] = item.City;
                dr["Street"] = item.Street;
                dr["Number"] = item.Number;
                dr["MarkerType"] = item.MarkerType;
                dr["Lat"] = item.Lat;
                dr["Lng"] = item.Lng;
                dr["Picture"] = item.Picture;
                dr["UserName"] = item.UserName;
                dr["Contacts"] = item.Contacts;
                markersDataTable.Rows.Add(dr);
            }
            return markersDataTable;
        }

        public DataTable GetAllMarkers()
        {
            DataTable markersDataTable = new DataTable("markers");
            DataColumn markerId = markersDataTable.Columns.Add("Id", typeof(Int32));
            markersDataTable.PrimaryKey = new DataColumn[] { markerId };
            markersDataTable.Columns.Add("Name", typeof(string));
            markersDataTable.Columns.Add("Description", typeof(string));
            markersDataTable.Columns.Add("City", typeof(string));
            markersDataTable.Columns.Add("Street", typeof(string));
            markersDataTable.Columns.Add("Number", typeof(string));
            markersDataTable.Columns.Add("MarkerType", typeof(string));
            markersDataTable.Columns.Add("Lat", typeof(double));
            markersDataTable.Columns.Add("Lng", typeof(double));
            markersDataTable.Columns.Add("Picture", typeof(byte[]));
            markersDataTable.Columns.Add("UserName", typeof(string));
            markersDataTable.Columns.Add("Contacts", typeof(string[]));
            List<ClassLib.Marker> markersList = dalUi.GetAllMarkers();
            //int i = 0;
            foreach (var item in markersList)
            {
                DataRow dr = markersDataTable.NewRow();
                dr["Id"] = item.Id;
                dr["Name"] = item.Name;
                dr["Description"] = item.Description;
                dr["City"] = item.City;
                dr["Street"] = item.Street;
                dr["Number"] = item.Number;
                dr["MarkerType"] = item.MarkerType;
                dr["Lat"] = item.Lat;
                dr["Lng"] = item.Lng;
                dr["Picture"] = item.Picture;
                dr["UserName"] = item.UserName;
                dr["Contacts"] = item.Contacts;
                markersDataTable.Rows.Add(dr);
            }
            return markersDataTable;
        }

        public void UpdateMarker(Marker marker)
        {
            dalUi.UpdateMarker(marker);
        }

        public void DeleteMarker(int id)
        {
            dalUi.DeleteMarker(id);
        }

        public DataTable GetAllCitiesCollection()
        {
            DataTable citiesDataTable = new DataTable("cities");
            DataColumn cityId = citiesDataTable.Columns.Add("Id", typeof(Int32));
            citiesDataTable.PrimaryKey = new DataColumn[] { cityId };
            citiesDataTable.Columns.Add("Name", typeof(string));
            citiesDataTable.Columns.Add("Addresses", typeof(string[]));
            List<City> citiesList = dalUi.GetCities();
            foreach (var item in citiesList)
            {
                DataRow dr = citiesDataTable.NewRow();
                dr["Id"] = item.Id;
                dr["Name"] = item.Name;
                dr["Addresses"] = item.Addresses;
                citiesDataTable.Rows.Add(dr);
            }
            return citiesDataTable;
        }
    }
}
