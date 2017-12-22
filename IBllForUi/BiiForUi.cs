using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDalForUi;
using System.Security.Cryptography;

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
    }
}
