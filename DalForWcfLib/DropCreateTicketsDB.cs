using System;
using System.Data.Entity;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DalForWcfLib
{
    internal class DropCreateTicketsDB<T> : DropCreateDatabaseIfModelChanges<GoogleMapModel>
    {
        protected override void Seed(GoogleMapModel ctx)
        {
            City cityRivne = new City() { Name = "Rivne" };
            ctx.Cities.Add(cityRivne);
            ctx.Cities.Add(new City() { Name = "Kyiv" });
            ctx.Cities.Add(new City() { Name = "Lutsk" });
            ctx.Cities.Add(new City() { Name = "Lviv" });
            ctx.SaveChanges();

            LoginStatus loginStatusAdmin = new LoginStatus() { Name = "admin" };
            LoginStatus loginStatusUser = new LoginStatus() { Name = "user" };
            ctx.LoginStatuses.Add(loginStatusAdmin);
            ctx.LoginStatuses.Add(loginStatusUser);
            ctx.SaveChanges();

            var password1 = Encoding.ASCII.GetBytes("admin");
            var password2 = Encoding.ASCII.GetBytes("serge");
            var md5 = new MD5CryptoServiceProvider();
            byte[] md5passwordAdmin = md5.ComputeHash(password1);
            byte[] md5passwordUser = md5.ComputeHash(password2);
            Login adminLogin = new Login() { Name = "admin", LoginStatus = loginStatusAdmin, Password = md5passwordAdmin };
            ctx.Logins.Add(adminLogin);
            ctx.Logins.Add(new Login() { Name = "serge", LoginStatus = loginStatusUser, Password = md5passwordUser });
            ctx.SaveChanges();

            MarkerType supermarketType = new MarkerType() { Name = "supermarket" };
            MarkerType schoolType = new MarkerType() { Name = "school" };
            MarkerType otherType = new MarkerType() { Name = "other" };
            ctx.MarkerTypes.Add(new MarkerType() { Name = "user" });
            ctx.MarkerTypes.Add(supermarketType);
            ctx.MarkerTypes.Add(new MarkerType() { Name = "bank" });
            ctx.MarkerTypes.Add(schoolType);
            ctx.MarkerTypes.Add(new MarkerType() { Name = "library" });
            ctx.MarkerTypes.Add(new MarkerType() { Name = "cinema" });
            ctx.MarkerTypes.Add(otherType);
            ctx.SaveChanges();


            var directoryPath = AppDomain.CurrentDomain.BaseDirectory.Replace("WcfGoogleMaps", "") + @"DalForWcfLib\Resources\";
            byte[] supermarketImage = File.ReadAllBytes(directoryPath+"supermarket_icon.jpg");
            byte[] schoolImage = File.ReadAllBytes(directoryPath + "school_icon.jpg");
            byte[] otherImage = File.ReadAllBytes(directoryPath + "Pointer.jpg");
            byte[] cinemaImage = File.ReadAllBytes(directoryPath + "cinema_icon.png");
            //byte[] schoolImage = File.ReadAllBytes(@"Resources\school_icon.jpg");
            //byte[] otherImage = File.ReadAllBytes(@"C: \Users\vitalii_best\Downloads\bankimage.jpg"); /*(@"C:\Users\Serge\Source\Repos\team\teamproject\DalForWcfLib\Resources\Pointer.jpg");*/
            //byte[] supermarketImage = File.ReadAllBytes(@"C: \Users\vitalii_best\Downloads\bankimage.jpg"); /*(@"C:\Users\Serge\Source\Repos\team\teamproject\DalForWcfLib\Resources\supermarket_icon.jpg");*/
            //byte[] schoolImage = File.ReadAllBytes(@"C: \Users\vitalii_best\Downloads\bankimage.jpg");/* (@"C:\Users\Serge\Source\Repos\team\teamproject\DalForWcfLib\Resources\school_icon.jpg");*/
            //byte[] otherImage = File.ReadAllBytes(@"C:\Users\Serge\Source\Repos\team\teamproject\DalForWcfLib\Resources\Pointer.jpg"); /*(@"C:\Users\Serge\Source\Repos\team\teamproject\DalForWcfLib\Resources\Pointer.jpg");*/
            //byte[] supermarketImage = File.ReadAllBytes(@"C:\Users\Serge\Source\Repos\team\teamproject\DalForWcfLib\Resources\supermarket_icon.jpg"); /*(@"C:\Users\Serge\Source\Repos\team\teamproject\DalForWcfLib\Resources\supermarket_icon.jpg");*/
            //byte[] schoolImage = File.ReadAllBytes(@"C:\Users\Serge\Source\Repos\team\teamproject\DalForWcfLib\Resources\school_icon.jpg");/* (@"C:\Users\Serge\Source\Repos\team\teamproject\DalForWcfLib\Resources\school_icon.jpg");*/
            Address silpoAddress = new Address() { City = cityRivne, Street = "Київська", Number = "69" };
            Address fozziAddress = new Address() { City = cityRivne, Street = "Курчатова", Number = "9" };
            Address velmartAddress = new Address() { City = cityRivne, Street = "Макарова", Number = "22" };
            Address cumAddress = new Address() { City = cityRivne, Street = "Соборна", Number = "17" };
            ctx.Addresses.Add(silpoAddress);
            ctx.Addresses.Add(fozziAddress);
            ctx.Addresses.Add(velmartAddress);
            ctx.Addresses.Add(cumAddress);
            ctx.SaveChanges();


            Marker silpoMarker = new Marker()
            {
                Type = supermarketType,
                Lat = 50.616842,
                Lng = 26.281758,
                Name = "Silpo",
                Address = silpoAddress,
                Picture = supermarketImage,
                Description = "supermarket",
                Login = adminLogin
            };
            ctx.Markers.Add(silpoMarker);
            Marker fozziMarker = new Marker()
            {
                Type = supermarketType,
                Lat = 50.603368,
                Lng = 26.284247,
                Name = "Fozzi",
                Address = fozziAddress,
                Picture = supermarketImage
                                            ,
                Description = "supermarket",
                Login = adminLogin
            };
            ctx.Markers.Add(fozziMarker);
            Marker velmartMarker = new Marker()
            {
                Type = supermarketType,
                Lat = 50.626279,
                Lng = 26.199893,
                Name = "Velmart",
                Address = velmartAddress,
                Picture = supermarketImage,
                Description = "supermarket",
                Login = adminLogin
            };
            ctx.Markers.Add(velmartMarker);
            Marker cumMarker = new Marker
            {
                Type = supermarketType,
                Lat = 50.618634,
                Lng = 26.252800,
                Name = "CUM",
                Address = cumAddress,
                Picture = supermarketImage,

                Description = "supermarket",
                Login = adminLogin
            };
            ctx.Markers.Add(cumMarker);

            Marker otherMarker = new Marker
            {
                Type = otherType,
                Lat = 50.618634,
                Lng = 26.252800,
                Name = "CUM",
                Address = cumAddress,
                Picture = otherImage,

                Description = "supermarket",
                Login = adminLogin
            };
            ctx.Markers.Add(otherMarker);

            ctx.Contacts.Add(new Contact() { Name = "0362 20 52 04", Marker = silpoMarker });
            ctx.Contacts.Add(new Contact() { Name = "0362 20 52 04", Marker = fozziMarker });
            ctx.Contacts.Add(new Contact() { Name = "0362 20 52 04", Marker = velmartMarker });
            ctx.Contacts.Add(new Contact() { Name = "0362 20 52 04", Marker = cumMarker });
            ctx.Contacts.Add(new Contact() { Name = "0362 20 52 04", Marker = otherMarker });
            ctx.SaveChanges();

            Address cinemaEra = new Address() { City = cityRivne, Street = "Гагаріна", Number = "51" };
            Address cinemaUkraine=new Address() { City = cityRivne, Street = "майдан Незалежності", Number = "2" };
            Address school12Address = new Address() { City = cityRivne, Street = "Академіка Грушевського", Number = "81А" };
            Address school19Address = new Address() { City = cityRivne, Street = "Макарова", Number = "48" };
            Address school8Address= new Address() { City = cityRivne, Street = "Князя Острозького", Number = "20" };
            Address school27Address = new Address() { City = cityRivne, Street = "Дубенська", Number = "133" };
            Address school23Address = new Address() { City = cityRivne, Street = "Вербова", Number = "42" };
            Address school26Address = new Address() { City = cityRivne, Street = "Павлюченка", Number = "24" };
            Address school6Address = new Address() { City = cityRivne, Street = "Олени Пчілки", Number = "9" };
            ctx.Addresses.Add(cinemaEra);
            ctx.Addresses.Add(cinemaUkraine);
            ctx.Addresses.Add(school6Address);
            ctx.Addresses.Add(school26Address);
            ctx.Addresses.Add(school23Address);
            ctx.Addresses.Add(school27Address);
            ctx.Addresses.Add(school8Address);
            ctx.Addresses.Add(school19Address);
            ctx.Addresses.Add(school12Address);
            ctx.SaveChanges();
            //Address school12Address = new Address() { Name = "school 12", City = cityRivne, Street = "Академіка Грушевського", Number = "81А" };
            Marker school12Marker = new Marker()
            {
                Type = schoolType,
                Lat = 50.617336,
                Lng = 26.275402,
                Name = "School 12",
                Address = school12Address,
                Picture = schoolImage,
                Description = "school",
                Login = adminLogin
            };

            Marker school19Marker = new Marker()
            {
                Type = schoolType,
                Lat = 50.6413633,
                Lng = 26.1992904,
                Name = "School 19",
                Address = school19Address,
                Picture = schoolImage,
                Description = "Rivne Educational Complex №19",
                Login = adminLogin
            };
            Marker school8Marker = new Marker()
            {
                Type = schoolType,
                Lat = 50.6379384,
                Lng = 26.2014107,
                Name = "School 8",
                Address = school8Address,
                Picture = schoolImage,
                Description = "Школа №8",
                Login = adminLogin
            };
            Marker school27Marker = new Marker()
            {
                Type = schoolType,
                Lat = 50.6113521,
                Lng = 26.2149297,
                Name = "School 27",
                Address = school27Address,
                Picture = schoolImage,
                Description = "Школа №27",
                Login = adminLogin
            };
            Marker school23Marker = new Marker()
            {
                Type = schoolType,
                Lat = 50.632157,
                Lng = 26.2051265,
                Name = "School 23",
                Address = school23Address,
                Picture = schoolImage,
                Description = "Школа №23",
                Login = adminLogin
            };
            Marker school26Marker = new Marker()
            {
                Type = schoolType,
                Lat = 50.6226748,
                Lng = 26.2096796,
                Name = "School 26",
                Address = school26Address,
                Picture = schoolImage,
                Description = "Школа №26",
                Login = adminLogin
            };
            Marker school6Marker = new Marker()
            {
                Type = schoolType,
                Lat = 50.6129689,
                Lng =26.2263948,
                Name = "School 6",
                Address = school6Address,
                Picture = schoolImage,
                Description = "Школа №6",
                Login = adminLogin
            };

            Marker cinemaUkr = new Marker()
            {
                Type = ctx.MarkerTypes.FirstOrDefaultAsync(x=>x.Name=="cinema").Result,
                Lat = 50.6202974,
                Lng = 26.2514783,
                Name = "Україна Кінопалац",
                Address = cinemaUkraine,
                Picture = cinemaImage,
                Description = "Украина Кинопалац",
                Login = adminLogin
            };

            Marker Eracinema = new Marker()
            {
                Type = ctx.MarkerTypes.FirstOrDefaultAsync(x => x.Name == "cinema").Result,
                Lat = 50.6320133,
                Lng = 26.2736146,
                Name = "Ера",
                Address = cinemaEra,
                Picture = cinemaImage,
                Description = "Мультиплекс Кіноцентр Ера",
                Login = adminLogin
            };
            ctx.Markers.Add(Eracinema);
            ctx.Markers.Add(cinemaUkr);
            ctx.Markers.Add(school6Marker);
            ctx.Markers.Add(school26Marker);
            ctx.Markers.Add(school23Marker);
            ctx.Markers.Add(school27Marker);
            ctx.Markers.Add(school8Marker);
            ctx.Markers.Add(school12Marker);
            ctx.Markers.Add(school19Marker);
            ctx.SaveChanges();
            ctx.Contacts.Add(new Contact() { Name = "0800 505 333", Marker = Eracinema });
            ctx.Contacts.Add(new Contact() { Name = "068 800 5588", Marker = cinemaUkr });
            ctx.Contacts.Add(new Contact() { Name = "097 716 7813", Marker = school6Marker });
            ctx.Contacts.Add(new Contact() { Name = "03622 52083", Marker = school23Marker });
            ctx.Contacts.Add(new Contact() { Name = "0362 628 377", Marker = school27Marker });
            ctx.Contacts.Add(new Contact() { Name = "03622 85592", Marker = school12Marker });
            ctx.Contacts.Add(new Contact() { Name = "0362 25 63 05", Marker = school19Marker });
            ctx.Contacts.Add(new Contact() { Name = "0362 641 257", Marker = school8Marker });
            ctx.Contacts.Add(new Contact() { Name = "03622 53238", Marker = school26Marker });
            ctx.SaveChanges();
            base.Seed(ctx);
        }
    }
}