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
                    .ForMember(x => x.Contacts, opt => opt.MapFrom(src => src.Contacts.ToArray()))
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
    }
}
