using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalForWcfLib;

namespace BllForWcfLib
{
    public class BLL
    {
        DAL dal = new DAL();
        public string[] GetAllPlaceTypes()
        {
            return dal.GetAllPlaceTypes();
        }

        public bool IsSuchAddress(string city, string street, string number)
        {
            City _city = dal.GetCity(city);
            if (dal.GetQueryableAddress(city, street, number).Count() == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void AddNewUserPlace(string name, string city, string street, string number, string markerType, double lat, double lng, byte[] picture, string userName,
            string description, string[] contacts)
        {

            Address address;
            if (IsSuchAddress(city, street, number))
            {
                address = dal.GetQueryableAddress(city, street, number).FirstOrDefault();
            }
            else
            {
                City _city = dal.GetCity(city);
                address = dal.AddNewAddress(_city, street, number);
            }
            Login login = dal.GetLoginByName(userName);
            MarkerType _markerType = dal.GetMarkerType(markerType);
            dal.AddNewUserPlace(name, address, _markerType, description, lat, lng, picture, login, contacts);
        }

        public Marker[] GetMarkersOfType(string markerType, string city)
        {
            MarkerType _markerType = dal.GetMarkerType(markerType);
            City _city = dal.GetCity(city);
            return dal.GetMarkersOfType(_markerType, _city);
        }

        public Marker[] GetMarkersOfUser(string userName)
        {
            return dal.GetMarkersOfUser(userName);
        }

        public void AddNewUser(string userName, byte[] password, string city, string street, string number, string loginStatus)
        {
            LoginStatus _loginStatus = dal.GetLoginStatus(loginStatus);
            Address address;
            if (IsSuchAddress(city, street, number))
            {
                address = dal.GetQueryableAddress(city, street, number).FirstOrDefault();
            }
            else
            {
                City _city = dal.GetCity(city);
                address = dal.AddNewAddress(_city, street, number);
            }
            dal.AddNewUser(userName, password, address, _loginStatus);
        }

        public bool IsSuchUserNameInDB(string userName)
        {
            if (dal.GetQeeryableUserNameInDB(userName).Count() == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsPasswordsEquals(string userName, byte[] password)
        {
            byte[] databasePassword = dal.GetUserPassword(userName);
            if (databasePassword.Equals(password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string[] GetAllCities()
        {
            return dal.GetAllCities();
        }
    }
}
