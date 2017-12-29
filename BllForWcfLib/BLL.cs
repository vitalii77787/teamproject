using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalForWcfLib;
using ServerDtoLib;

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
            if (databasePassword.SequenceEqual(password))
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

        public string GetLoginStatusOfUser(string userName)
        {
            return dal.GetLoginStatusOfUser(userName);
        }


        /// <summary>
        /// Get info about user's address - string[] with 3 elements: string[0] - city, string[1] - street, string[2] - street number
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string[] GetCityStreetAndNumberOfUser(string userName)
        {
            return dal.GetCityStreetAndNumberOfUser(userName);
        }

        public byte[] GetDefaultPicture()
        {
            return dal.GetDefaultPicture();
        }

        public MarkerDto[] GetMarkersDtoOfType(string markerType, string city)
        {
            MarkerType _markerType = dal.GetMarkerType(markerType);
            City _city = dal.GetCity(city);
            return dal.GetMarkersDtoOfType(_markerType, _city);
        }

        public MarkerDto[] GetAllMarkersDto()
        {
            return dal.GetAllMarkersDto();
        }

        public void UpdateMarker(MarkerDto newMarker)
        {
            MarkerType _markerType = dal.GetMarkerType(newMarker.MarkerType);
            Address address;
            if (IsSuchAddress(newMarker.City, newMarker.Street, newMarker.Number))
            {
                address = dal.GetQueryableAddress(newMarker.City, newMarker.Street, newMarker.Number).FirstOrDefault();
            }
            else
            {
                City _city = dal.GetCity(newMarker.City);
                address = dal.AddNewAddress(_city, newMarker.Street, newMarker.Number);
            }
            Login login = dal.GetLoginByName(newMarker.UserName);
            Marker marker = new Marker()
            {
                Name = newMarker.Name,
                Address = address,
                Description = newMarker.Description,
                Lat = newMarker.Lat,
                Lng = newMarker.Lng,
                Login = login,
                Picture = newMarker.Picture,
                Type = _markerType
            };
            dal.UpdateMarker(newMarker.Id, marker, newMarker.Contacts);
        }

        public void DeleteMarker(int id)
        {
            dal.DeleteMarker(id);
        }
    }
}
