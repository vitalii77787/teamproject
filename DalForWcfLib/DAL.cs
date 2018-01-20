using AutoMapper;
using ServerDtoLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalForWcfLib
{
    public class DAL
    {
        GoogleMapModel ctx = new GoogleMapModel();

        public string[] GetAllPlaceTypes()
        {
            string[] b = ctx.MarkerTypes.Select(item => item.Name).ToArray();
            return b;
        }

        public void AddNewUserPlace(string name, Address address, MarkerType markerType, string description, double lat, double lng, byte[] picture, Login login,
            string[] contacts)
        {
            Marker marker = new Marker()
            {
                Name = name,
                Address = address,
                Type = markerType,
                Lat = lat,
                Lng = lng,
                Login = login,
                Picture = picture,
                Description = description
            };
            ctx.Markers.Add(marker);
            ctx.SaveChanges();
            foreach (var item in contacts)
            {
                ctx.Contacts.Add(new Contact() { Name = item, Marker = marker });
            }
            ctx.SaveChanges();
        }

        public Marker[] GetMarkersOfType(MarkerType type, City city)
        {
            return ctx.Markers.Where(item => item.Type.Name == type.Name && item.Address.City.Name == city.Name).ToArray();
        }

        public Marker[] GetMarkersOfUser(string userName)
        {
            return ctx.Markers.Where(item => item.Login != null && item.Login.Name == userName).ToArray();
        }

        public void AddNewUser(string userName, byte[] password, Address address, LoginStatus loginStatus)
        {
            ctx.Logins.Add(new Login() { Name = userName, Password = password, Address = address, LoginStatus = loginStatus });
            ctx.SaveChanges();
        }

        public IQueryable<Login> GetQeeryableUserNameInDB(string userName)
        {
            return ctx.Logins.Where(item => item.Name == userName);
        }

        public byte[] GetUserPassword(string userName)
        {
            return ctx.Logins.Where(item => item.Name == userName).Select(item => item.Password).FirstOrDefault();
        }

        public string[] GetAllCities()
        {
            return ctx.Cities.Select(item => item.Name).ToArray();
        }

        public City GetCity(string cityName)
        {
            return ctx.Cities.Where(item => item.Name == cityName).FirstOrDefault();
        }

        public MarkerType GetMarkerType(string marketType)
        {
            return ctx.MarkerTypes.Where(item => item.Name == marketType).FirstOrDefault();
        }

        public void AddNewMarkerType(string name)
        {
            MarkerType markerType = new MarkerType() { Name = name};
            ctx.MarkerTypes.Add(markerType);
            ctx.SaveChanges();
        }
        public void UpdateMarkerType(int id, string name)
        {
            MarkerType markertype = ctx.MarkerTypes.Where(item => item.Id == id).FirstOrDefault();
            markertype.Name = name;
            ctx.SaveChanges();
        }
        public void DeleteMarkerType(int id)
        {
            MarkerType markertype = ctx.MarkerTypes.Where(item => item.Id == id).FirstOrDefault();
            ctx.MarkerTypes.Remove(markertype);
            ctx.SaveChanges();
        }
        public void AddNewCity(string name)
        {
            City city = new City() { Name = name };
            ctx.Cities.Add(city);
            ctx.SaveChanges();
        }
        public void UpdateCity(int id, string name)
        {
            City city = ctx.Cities.Where(item => item.Id == id).FirstOrDefault();
            city.Name = name;
            ctx.SaveChanges();
        }
        public void DeleteCity(int id)
        {
            City city= ctx.Cities.Where(item => item.Id == id).FirstOrDefault();
            ctx.Cities.Remove(city);
            ctx.SaveChanges();
        }
        public void UpdateLogin(int id, string name)
        {
            Login login = ctx.Logins.Where(item => item.Id == id).FirstOrDefault();
            login.Name = name;
            ctx.SaveChanges();
        }
        public void DeleteLogin(int id)
        {
            Login login = ctx.Logins.Where(item => item.Id == id).FirstOrDefault();
            if (login != null)
            {
                ctx.Logins.Remove(login);
                ctx.SaveChanges();
            }
        }
        public Address AddNewAddress(City city, string street, string number)
        {
            Address address = new Address() { City = city, Street = street, Number = number };
            ctx.Addresses.Add(address);
            ctx.SaveChanges();
            return address;
        }

        public IQueryable<Address> GetQueryableAddress(string city, string street, string number)
        {
            return ctx.Addresses.Where(item => item.City.Name == city && item.Street == street && item.Number == number);
        }

        public Login GetLoginByName(string userName)
        {
            return ctx.Logins.Where(item => item.Name == userName).FirstOrDefault();
        }

        public LoginStatus GetLoginStatus(string loginStatus)
        {
            return ctx.LoginStatuses.Where(item => item.Name == loginStatus).FirstOrDefault();
        }

        public string GetLoginStatusOfUser(string userName)
        {
            return ctx.Logins.Where(item => item.Name == userName).Select(item => item.LoginStatus.Name).FirstOrDefault();
        }


        /// <summary>
        /// Get info about user's address - string[] with 3 elements: string[0] - city, string[1] - street, string[2] - street number
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string[] GetCityStreetAndNumberOfUser(string userName)
        {
            string[] cityStreetAndNumberOfUser = new string[3];
            cityStreetAndNumberOfUser[0] = ctx.Logins.Where(item => item.Name == userName).Select(item => item.Address.City.Name).FirstOrDefault();
            cityStreetAndNumberOfUser[1] = ctx.Logins.Where(item => item.Name == userName).Select(item => item.Address.Street).FirstOrDefault();
            cityStreetAndNumberOfUser[2] = ctx.Logins.Where(item => item.Name == userName).Select(item => item.Address.Number).FirstOrDefault();
            return cityStreetAndNumberOfUser;
        }

        public byte[] GetDefaultPicture()
        {
            return ctx.Markers.Where(item => item.Type.Name == "other").Select(item => item.Picture).FirstOrDefault();
        }

        public MarkerDto[] GetMarkersDtoOfType(MarkerType type, City city)
        {
            Marker[] markers = ctx.Markers.Where(item => item.Type.Name == type.Name && item.Address.City.Name == city.Name).ToArray();
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<Marker, MarkerDto>()
                    .ForMember(x => x.City, opt => opt.MapFrom(src => src.Address.City.Name))
                    .ForMember(x => x.Street, opt => opt.MapFrom(src => src.Address.Street))
                    .ForMember(x => x.Number, opt => opt.MapFrom(src => src.Address.Number))
                    .ForMember(x => x.MarkerType, opt => opt.MapFrom(src => src.Type.Name))
                    .ForMember(x => x.UserName, opt => opt.MapFrom(src => src.Login.Name))
                    .ForMember(x => x.Contacts, opt => opt.MapFrom(src => src.Contacts.Select(item=>item.Name).ToArray()))
                    );
            List<MarkerDto> markersDto = new List<MarkerDto>();
            // Выполняем сопоставление
            foreach (var item in markers)
            {
                MarkerDto markerDto = Mapper.Map<Marker, MarkerDto>(item);
                markersDto.Add(markerDto);
            }
            
            return markersDto.ToArray();
        }

        public MarkerTypeDto[] GetAllMarkerTypesDto()
        {
            MarkerType[] markertypes = ctx.MarkerTypes.ToArray();
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<MarkerType, ServerDtoLib. MarkerTypeDto>()
                  .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name))
                  .ForMember(x => x.MarkersCollection, opt => opt.MapFrom(src => src.Markers.Select(item => item.Name).ToArray()))
                  );
            List<MarkerTypeDto> markerstypeDto = new List<MarkerTypeDto>();
            foreach (var item in markertypes)
            {
                MarkerTypeDto markertypeDto = Mapper.Map<MarkerType, MarkerTypeDto>(item);
                markerstypeDto.Add(markertypeDto);
            }
            return markerstypeDto.ToArray();
        }
        
        public CityDto[] GetAllCitiesDto()
        {
            City[] cities = ctx.Cities.ToArray();
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<City, CityDto>()
                    .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(x => x.Addresses, opt => opt.MapFrom(src => src.Addresses.Select(item => item.Street+" "+item.Number).ToArray()))
                    );
            List<CityDto> citiesDto = new List<CityDto>();
            foreach (var item in cities)
            {
                CityDto cityDto = Mapper.Map<City, CityDto>(item);
                citiesDto.Add(cityDto);
            }
            return citiesDto.ToArray();
        }

        public LoginDto[] GetAllLoginsDto()
        {
            Login[] logins = ctx.Logins.ToArray();
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<Login, LoginDto>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(x => x.Password, opt => opt.MapFrom(src => src.Password)));
            List<LoginDto> loginsDto = new List<LoginDto>();
            foreach (var item in logins)
            {
                LoginDto loginDto = Mapper.Map<Login, LoginDto>(item);
                loginsDto.Add(loginDto);
            }
            return loginsDto.ToArray();
        }
        public MarkerDto[] GetAllMarkersDto()
        {
            Marker[] markers = ctx.Markers.ToArray();
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<Marker, MarkerDto>()
                    .ForMember(x => x.City, opt => opt.MapFrom(src => src.Address.City.Name))
                    .ForMember(x => x.Street, opt => opt.MapFrom(src => src.Address.Street))
                    .ForMember(x => x.Number, opt => opt.MapFrom(src => src.Address.Number))
                    .ForMember(x => x.MarkerType, opt => opt.MapFrom(src => src.Type.Name))
                    .ForMember(x => x.UserName, opt => opt.MapFrom(src => src.Login.Name))
                    .ForMember(x => x.Contacts, opt => opt.MapFrom(src => src.Contacts.Select(item => item.Name).ToArray()))
                    );
            List<MarkerDto> markersDto = new List<MarkerDto>();
            // Выполняем сопоставление
            foreach (var item in markers)
            {
                MarkerDto markerDto = Mapper.Map<Marker, MarkerDto>(item);
                markersDto.Add(markerDto);
            }

            return markersDto.ToArray();
        }

        public void UpdateMarker(int id, Marker newMarker, string[] contacts)
        {
            Marker marker = ctx.Markers.Where(item => item.Id == id).FirstOrDefault();
            marker.Address = newMarker.Address;
            marker.Description = newMarker.Description;
            marker.Lat = newMarker.Lat;
            marker.Lng = newMarker.Lng;
            marker.Login = newMarker.Login;
            marker.Name = newMarker.Name;
            marker.Picture = newMarker.Picture;
            marker.Type = newMarker.Type;
            marker.Contacts.Clear();
            ctx.SaveChanges();
            foreach (var item in contacts)
            {
                if (isSuchContactInDB(item))
                {
                    Contact contact = GetContact(item);
                    contact.Marker = marker;
                }
                else
                {
                    AddNewContact(item, marker);
                }
            }
            ctx.SaveChanges();
        }

        public bool isSuchContactInDB(string contactName)
        {
            bool isSuchContact = false;
            if (ctx.Contacts.Where(item => item.Name == contactName).Count() > 0)
            {
                isSuchContact = true;
            }
            return isSuchContact;
        }


        public Contact GetContact(string contactName)
        {
            return ctx.Contacts.Where(item => item.Name == contactName).FirstOrDefault();
        }

        public void AddNewContact(string contactName, Marker marker)
        {
            ctx.Contacts.Add(new Contact() { Name = contactName, Marker = marker });
            ctx.SaveChanges();
        }

        public void DeleteMarker(int id)
        {
            Marker marker = ctx.Markers.Where(item => item.Id == id).FirstOrDefault();
            Contact[] contacts = ctx.Contacts.Where(item => item.Marker.Id == id).ToArray();
            foreach (var item in contacts)
            {
                ctx.Contacts.Remove(item);
            }
            ctx.SaveChanges();
            //ctx.Entry(marker).State = System.Data.Entity.EntityState.Deleted;
            ctx.Markers.Remove(marker);
            ctx.SaveChanges();
        }

        public string[] GetAllLogins()
        {
            return ctx.Logins.Select(item => item.Name).ToArray();
        }

        public void DeleteLogin(string loginName)
        {
            Login login = ctx.Logins.Where(item => item.Name == loginName).FirstOrDefault();
            if (login != null)
            {
                ctx.Logins.Remove(login);
                ctx.SaveChanges();
            }
            
        }

        public void DeleteMarkerType(string markerTypeName)
        {
            MarkerType markerType = ctx.MarkerTypes.Where(item => item.Name == markerTypeName).FirstOrDefault();
            if (markerType != null)
            {
                ctx.MarkerTypes.Remove(markerType);
                ctx.SaveChanges();
            }
        }

        //public void AddNewCity(string city)
        //{
        //    if (ctx.Cities.Where(item => item.Name == city).Count() == 0)
        //    {
        //        ctx.Cities.Add(new City() { Name = city });
        //        ctx.SaveChanges();
        //    }
        //}

        public void DeleteCity(string cityName)
        {
            City city = ctx.Cities.Where(item => item.Name == cityName).FirstOrDefault();
            if (city != null)
            {
                ctx.Cities.Remove(city);
                ctx.SaveChanges();
            }
        }

        //public string GetLoginStatusOfUser(string loginName)
        //{
        //    Login login = ctx.Logins.Where(item => item.Name == loginName).FirstOrDefault();
        //    string loginStatus = string.Empty;
        //    if (login != null)
        //    {
        //        loginStatus = login.LoginStatus.Name;
        //    }
        //    return loginStatus;
        //}
    }
}
