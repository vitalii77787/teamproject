using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDalForUi.ServiceReference1;
using ClassLib;

namespace IDalForUi
{
    public class DalUi
    {
        Service1Client client = new Service1Client();

        public void AddNewUser(string userName, byte[] password, string city, string street, string number, string loginStatus)
        {
            client.AddNewUser(userName, password, city, street, number, loginStatus);
        }

        public void AddNewUserPlace(string name, string city, string street, string number, string markerType, double lat, double lng, byte[] picture, string userName,
                                    string description, string[] contacts)
        {
            client.AddNewUserPlace(name, city, street, number, markerType, lat, lng, picture, userName, description, contacts);
        }

        public List<Marker> GetMarkersOfType(string markerType, string city)
        {
            MarkerWcf[] markersWcf = client.GetMarkersOfType(markerType, city);
            List<Marker> markers = new List<Marker>();
            foreach (var item in markersWcf)
            {
                Marker marker = new Marker()
                {
                    Id = item.Id,
                    Name = item.Name,
                    City = item.City,
                    Contacts = item.Contacts,
                    Street = item.Street,
                    Number = item.Number,
                    Description = item.Description,
                    Lat = item.Lat,
                    Lng = item.Lng,
                    MarkerType = item.MarkerType,
                    Picture = item.Picture,
                    UserName = item.UserName
                };
                markers.Add(marker);
            }
            return markers;
        }

        public List<Marker> GetMarkersOfUser(string userName)
        {
            MarkerWcf[] markersWcf = client.GetMarkersOfUser(userName);
            List<Marker> markers = new List<Marker>();
            foreach (var item in markersWcf)
            {
                Marker marker = new Marker()
                {
                    Id = item.Id,
                    Name = item.Name,
                    City = item.City,
                    Contacts = item.Contacts,
                    Street = item.Street,
                    Number = item.Number,
                    Description = item.Description,
                    Lat = item.Lat,
                    Lng = item.Lng,
                    MarkerType = item.MarkerType,
                    Picture = item.Picture,
                    UserName = item.UserName
                };
                markers.Add(marker);
            }
            return markers;
        }

        public List<Marker> GetAllMarkers()
        {
            MarkerWcf[] markersWcf = client.GetAllMarkersDto();
            List<Marker> markers = new List<Marker>();
            foreach (var item in markersWcf)
            {
                Marker marker = new Marker()
                {
                    Id = item.Id,
                    Name = item.Name,
                    City = item.City,
                    Contacts = item.Contacts,
                    Street = item.Street,
                    Number = item.Number,
                    Description = item.Description,
                    Lat = item.Lat,
                    Lng = item.Lng,
                    MarkerType = item.MarkerType,
                    Picture = item.Picture,
                    UserName = item.UserName
                };
                markers.Add(marker);
            }
            return markers;
        }

        public List<City> GetCities()
        {
            CityWcf[] citiesWcf = client.GetAllCitiesDto();
            List<City> cities = new List<City>();
            foreach (var item in citiesWcf)
            {
                City city = new City()
                {
                    Id = item.CityId,
                    Name = item.CityName,
                    Addresses = item.CityAddresses,
                };
                cities.Add(city);
            }
            return cities;
        }

        public List<MarkerType> GetAllMarkerTypes()
        {
            MarkerTypeWcf[] markerTypeWcf = client.GetAllMarkerTypesDto();
            List<MarkerType> markertypes = new List<MarkerType>();
            foreach (var item in markerTypeWcf)
            {
                MarkerType markerType = new MarkerType()
                {
                    Id = item.Id,
                    Name = item.Name,
                    MarkersCollection = item.Markers,
                };
                markertypes.Add(markerType);
            }
            return markertypes;
        }

        public bool IsPasswordsEquals(string userName, byte[] password)
        {
            return client.IsPasswordsEquals(userName, password);
        }

        public bool IsSuchAddress(string city, string street, string number)
        {
            return client.IsSuchAddress(city, street, number);
        }

        public bool IsSuchUserNameInDB(string userName)
        {
            return client.IsSuchUserNameInDB(userName);
        }

        public string[] GetAllCities()
        {
            return client.GetAllCities();
        }

        public string[] GetAllPlaceTypes()
        {
            return client.GetAllPlaceTypes();
        }

        public string GetLoginStatusOfUser(string userName)
        {
            return client.GetLoginStatusOfUser(userName);
        }

        /// <summary>
        /// Get info about user's address - string[] with 3 elements: string[0] - city, string[1] - street, string[2] - street number
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string[] GetCityStreetAndNumberOfUser(string userName)
        {
            return client.GetCityStreetAndNumberOfUser(userName);
        }

        public byte[] GetDefaultPicture()
        {
            return client.GetDefaultPicture();
        }

        public void UpdateMarker(Marker newMarker)
        {
            MarkerWcf marker = new MarkerWcf()
            {
                Id = newMarker.Id,
                Name = newMarker.Name,
                City = newMarker.City,
                Street = newMarker.Street,
                Number = newMarker.Number,
                Description = newMarker.Description,
                Lat = newMarker.Lat,
                Lng = newMarker.Lng,
                UserName = newMarker.UserName,
                Picture = newMarker.Picture,
                MarkerType = newMarker.MarkerType,
                Contacts = newMarker.Contacts
            };
            client.UpdateMarker(marker);
        }

        public void DeleteMarker(int id)
        {
            client.DeleteMarker(id);
        }
    }
}
