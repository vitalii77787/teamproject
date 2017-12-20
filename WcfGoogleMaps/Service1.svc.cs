﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BllForWcfLib;
using DalForWcfLib;

namespace WcfGoogleMaps
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        BLL bll = new BLL();
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

        public string[] GetAllPlaceTypes()
        {
            return bll.GetAllPlaceTypes();
        }

        public MarkerWcf[] GetMarkersOfType(string markerType, string city)
        {
            Marker[] markers = bll.GetMarkersOfType(markerType, city);

            List<MarkerWcf> markersWcf = new List<MarkerWcf>();
            foreach (var item in markers)
            {
                MarkerWcf marker = new MarkerWcf()
                {
                    Name = item.Name,
                    City = item.Address.City.Name,
                    Contacts = item.Contacts.Select(c => c.Name).ToArray(),
                    Street = item.Address.Street,
                    Number = item.Address.Number,
                    Description = item.Description,
                    Lat = item.Lat,
                    Lng = item.Lng,
                    MarkerType = item.Type.Name,
                    Picture = item.Picture,
                    UserName = item.Login.Name
                };
                markersWcf.Add(marker);
            }
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
    }
}
