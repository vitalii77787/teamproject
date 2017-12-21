﻿using System;
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
    }
}