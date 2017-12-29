using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BllForWcfLib;
using DalForWcfLib;
using System.Configuration;
using ServerDtoLib;

namespace WcfGoogleMaps
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        BLL bll = new BLL();

        public Service1()
        {
            //string machineName = Environment.MachineName;
            //string connectionStrSerge = "data source=DESKTOP-6LSJMMI;initial catalog=GoogleMapDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            //string connectionStrVitaliiHome = "data source=STEALTH-PC;initial catalog=GoogleMapDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            //string connectionStrVitaliiStep = "data source=A24COMP9;initial catalog=GoogleMapDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            //string providerName = "System.Data.SqlClient";
            //var cfg = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(@"/");
            //if (machineName == "DESKTOP-6LSJMMI")
            //{
            //    cfg.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings("GoogleMapModel", connectionStrSerge, providerName));
            //}
            //else if (machineName == "STEALTH-PC")
            //{
            //    cfg.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings("GoogleMapModel", connectionStrVitaliiHome, providerName));
            //}
            //else
            //{
            //    cfg.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings("GoogleMapModel", connectionStrVitaliiStep, providerName));
            //}
            
            //cfg.Save();
        }
        public void AddNewUser(string userName, byte[] password, string city, string street, string number, string loginStatus)
        {
            bll.AddNewUser(userName, password, city, street, number, loginStatus);
        }

        public void AddNewUserPlace(string name, string city, string street, string number, string markerType, double lat, double lng, byte[] picture, string userName,
            string description, string[] contacts)
        {
            bll.AddNewUserPlace(name, city, street, number, markerType, lat, lng, picture, userName, description, contacts);
        }

        public string[] GetAllCities()
        {
            return bll.GetAllCities();
        }

        public MarkerWcf[] GetAllMarkersDto()
        {
            //Marker[] markers = bll.GetMar;
            MarkerDto[] markersDto = bll.GetAllMarkersDto();

            List<MarkerWcf> markersWcf = new List<MarkerWcf>();
            foreach (var item in markersDto)
            {
                MarkerWcf marker = new MarkerWcf()
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
                markersWcf.Add(marker);
            }
            return markersWcf.ToArray();
        }

        public string[] GetAllPlaceTypes()
        {
            return bll.GetAllPlaceTypes();
        }

        public string[] GetCityStreetAndNumberOfUser(string userName)
        {
            return bll.GetCityStreetAndNumberOfUser(userName);
        }

        public byte[] GetDefaultPicture()
        {
            return bll.GetDefaultPicture();
        }

        public string GetLoginStatusOfUser(string userName)
        {
            return bll.GetLoginStatusOfUser(userName);
        }

        public MarkerWcf[] GetMarkersOfType(string markerType, string city)
        {
            Marker[] markers = bll.GetMarkersOfType(markerType, city);
            MarkerDto[] markersDto = bll.GetMarkersDtoOfType(markerType, city);

            List<MarkerWcf> markersWcf = new List<MarkerWcf>();
            foreach (var item in markersDto)
            {
                MarkerWcf marker = new MarkerWcf()
                {
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
                markersWcf.Add(marker);
            }
            //foreach (var item in markers)
            //{
            //    MarkerWcf marker = new MarkerWcf()
            //    {
            //        Name = item.Name,
            //        City = item.Address.City.Name,
            //        Contacts = item.Contacts.Select(c => c.Name).ToArray(),
            //        Street = item.Address.Street,
            //        Number = item.Address.Number,
            //        Description = item.Description,
            //        Lat = item.Lat,
            //        Lng = item.Lng,
            //        MarkerType = item.Type.Name,
            //        Picture = item.Picture,
            //        UserName = item.Login.Name
            //    };
            //    markersWcf.Add(marker);
            //}
            return markersWcf.ToArray();
        }

        public MarkerWcf[] GetMarkersOfUser(string userName)
        {
            Marker[] markers = bll.GetMarkersOfUser(userName);
            List<MarkerWcf> markersWcf = new List<MarkerWcf>();
            foreach (var item in markers)
            {
                MarkerWcf marker = new MarkerWcf()
                {
                    Name = item.Name,
                    City = item?.Address.City.Name,
                    Contacts = item?.Contacts.Select(c => c.Name).ToArray(),
                    Street = item?.Address.Street,
                    Number = item?.Address.Number,
                    Description = item.Description,
                    Lat = item.Lat,
                    Lng = item.Lng,
                    MarkerType = item?.Type.Name,
                    Picture = item.Picture,
                    UserName = item?.Login.Name
                };
                markersWcf.Add(marker);
            }
            return markersWcf.ToArray();
        }

        public bool IsPasswordsEquals(string userName, byte[] password)
        {
            return bll.IsPasswordsEquals(userName, password);
        }

        public bool IsSuchAddress(string city, string street, string number)
        {
            return bll.IsSuchAddress(city, street, number);
        }

        public bool IsSuchUserNameInDB(string userName)
        {
            return bll.IsSuchUserNameInDB(userName);
        }

        public void UpdateMarker(MarkerWcf newMarker)
        {
            MarkerDto markerDto = new MarkerDto()
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

            bll.UpdateMarker(markerDto);
        }
    }
}
