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
            Address adminAddress = new Address() { City = cityRivne, Street = "Київська", Number = "20" };
            Login adminLogin = new Login() { Name = "admin", LoginStatus = loginStatusAdmin, Password = md5passwordAdmin, Address = adminAddress };
            ctx.Logins.Add(adminLogin);
            ctx.Logins.Add(new Login() { Name = "serge", LoginStatus = loginStatusUser, Password = md5passwordUser, Address = adminAddress });
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
            byte[] terminalImage = File.ReadAllBytes(directoryPath + "bancomat_icon.jpg");
            byte[] supermarketImage = File.ReadAllBytes(directoryPath+"supermarket_icon.jpg");
            byte[] schoolImage = File.ReadAllBytes(directoryPath + "school_icon.jpg");
            byte[] otherImage = File.ReadAllBytes(directoryPath + "Pointer.jpg");
            byte[] cinemaImage = File.ReadAllBytes(directoryPath + "cinema_icon.png");
            byte[] libraryImage = File.ReadAllBytes(directoryPath + "library_icon.png");
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
            Address terminal1 = new Address() { City = cityRivne, Street = "Соборна", Number = "15" };
            Address terminal2 = new Address() { City = cityRivne, Street = "Соборна", Number = "17" };
            Address terminal3 = new Address() { City = cityRivne, Street = "Соборна", Number = "12а" };
            Address terminal4 = new Address() { City = cityRivne, Street = "Проспект Миру", Number = "2" };
            Address terminal5 = new Address() { City = cityRivne, Street = "Словацького", Number = "4/6" };
            Address terminal6 = new Address() { City = cityRivne, Street = "Шевченка", Number = "18" };
            Address terminal7 = new Address() { City = cityRivne, Street = "Проспект Миру", Number = "8" };
            Address terminal8 = new Address() { City = cityRivne, Street = "Відінська", Number = "48" };
            Address terminal9 = new Address() { City = cityRivne, Street = "Вячеслава Чорновола", Number = "53" };
            Address terminal10 = new Address() { City = cityRivne, Street = "Алекси Новака", Number = "75" };
            Address terminal11 = new Address() { City = cityRivne, Street = "Шкільна", Number = "33" };
            Address library1 = new Address() { City = cityRivne, Street = "Соборна", Number = "416" };
            Address library2 = new Address() { City = cityRivne, Street = "Залізнична", Number = "6" };
            Address library3 = new Address() { City = cityRivne, Street = "Короленка", Number = "6" };
            Address library4 = new Address() { City = cityRivne, Street = "Проспект Миру", Number = "18" };
            Address library5 = new Address() { City = cityRivne, Street = "Петра Могили", Number = "22Б" };
            ctx.Addresses.Add(cinemaEra);
            ctx.Addresses.Add(cinemaUkraine);
            ctx.Addresses.Add(school6Address);
            ctx.Addresses.Add(school26Address);
            ctx.Addresses.Add(school23Address);
            ctx.Addresses.Add(school27Address);
            ctx.Addresses.Add(school8Address);
            ctx.Addresses.Add(school19Address);
            ctx.Addresses.Add(school12Address);
            ctx.Addresses.Add(terminal1);
            ctx.Addresses.Add(terminal2);
            ctx.Addresses.Add(terminal3);
            ctx.Addresses.Add(terminal4);
            ctx.Addresses.Add(terminal5);
            ctx.Addresses.Add(terminal6);
            ctx.Addresses.Add(terminal7);
            ctx.Addresses.Add(terminal8);
            ctx.Addresses.Add(terminal9);
            ctx.Addresses.Add(terminal10);
            ctx.Addresses.Add(terminal11);
            ctx.Addresses.Add(library1);
            ctx.Addresses.Add(library2);
            ctx.Addresses.Add(library3);
            ctx.Addresses.Add(library4);
            ctx.Addresses.Add(library5);
            ctx.SaveChanges();
            //Address school12Address = new Address() { Name = "school 12", City = cityRivne, Street = "Академіка Грушевського", Number = "81А" };
            Marker librarymarker1 = new Marker()
            {
                Type = ctx.MarkerTypes.FirstOrDefaultAsync(x => x.Name == "library").Result,
                Lat = 50.635571,
                Lng = 26.2130483,
                Name = "Library",
                Address = library1,
                Picture = libraryImage,
                Description = "Міська бібліотека №3",
                Login = adminLogin
            };
            Marker librarymarker2 = new Marker()
            {
                Type = ctx.MarkerTypes.FirstOrDefaultAsync(x => x.Name == "library").Result,
                Lat = 50.6001784,
                Lng = 26.2351745,
                Name = "Library",
                Address = library2,
                Picture = libraryImage,
                Description = "Міська бібліотека №2",
                Login = adminLogin
            };
            Marker librarymarker3 = new Marker()
            {
                Type = ctx.MarkerTypes.FirstOrDefaultAsync(x => x.Name == "library").Result,
                Lat = 50.617936,
                Lng = 26.246253,
                Name = "Library",
                Address = library3,
                Picture = libraryImage,
                Description = "Рівненська обласна універсальна наукова бібліотека",
                Login = adminLogin
            };
            Marker librarymarker4 = new Marker()
            {
                Type = ctx.MarkerTypes.FirstOrDefaultAsync(x => x.Name == "library").Result,
                Lat = 50.6259239,
                Lng = 26.246049,
                Name = "Library",
                Address = library4,
                Picture = libraryImage,
                Description = "Рівненська обласна бібліотека для дітей",
                Login = adminLogin
            };
            Marker librarymarker5 = new Marker()
            {
                Type = ctx.MarkerTypes.FirstOrDefaultAsync(x => x.Name == "library").Result,
                Lat = 50.6194729,
                Lng = 26.2274645,
                Name = "Library",
                Address = library5,
                Picture = libraryImage,
                Description = "Центральна Районна Бібліотека",
                Login = adminLogin
            };
            Marker terminalmarker1 = new Marker()
            {
                Type = ctx.MarkerTypes.FirstOrDefaultAsync(x => x.Name == "bank").Result,
                Lat = 50.6186878,
                Lng = 26.2542766,
                Name = "ATM",
                Address = terminal1,
                Picture = terminalImage,
                Description = "ATM Privatbank",
                Login = adminLogin
            };
            Marker terminalmarker2 = new Marker()
            {
                Type = ctx.MarkerTypes.FirstOrDefaultAsync(x => x.Name == "bank").Result,
                Lat = 50.6186417,
                Lng = 26.2526823,
                Name = "ATM",
                Address = terminal2,
                Picture = terminalImage,
                Description = "ATM Privatbank",
                Login = adminLogin
            };
            Marker terminalmarker3 = new Marker()
            {
                Type = ctx.MarkerTypes.FirstOrDefaultAsync(x => x.Name == "bank").Result,
                Lat = 50.6185876,
                Lng = 26.2620209,
                Name = "ATM",
                Address = terminal3,
                Picture = terminalImage,
                Description = "ATM Privatbank",
                Login = adminLogin
            };
            Marker terminalmarker4 = new Marker()
            {
                Type = ctx.MarkerTypes.FirstOrDefaultAsync(x => x.Name == "bank").Result,
                Lat = 50.6232695,
                Lng = 26.2532465,
                Name = "ATM",
                Address = terminal4,
                Picture = terminalImage,
                Description = "ATM Privatbank",
                Login = adminLogin
            };
            Marker terminalmarker5 = new Marker()
            {
                Type = ctx.MarkerTypes.FirstOrDefaultAsync(x => x.Name == "bank").Result,
                Lat = 50.6220565,
                Lng = 26.2494317,
                Name = "ATM",
                Address = terminal5,
                Picture = terminalImage,
                Description = "ATM Privatbank",
                Login = adminLogin
            };
            Marker terminalmarker6 = new Marker()
            {
                Type = ctx.MarkerTypes.FirstOrDefaultAsync(x => x.Name == "bank").Result,
                Lat = 50.6224676,
                Lng = 26.2434406,
                Name = "ATM",
                Address = terminal6,
                Picture = terminalImage,
                Description = "ATM Privatbank",
                Login = adminLogin
            };
            Marker terminalmarker7 = new Marker()
            {
                Type = ctx.MarkerTypes.FirstOrDefaultAsync(x => x.Name == "bank").Result,
                Lat = 50.6240029,
                Lng = 26.250818,
                Name = "ATM",
                Address = terminal7,
                Picture = terminalImage,
                Description = "ATM Privatbank",
                Login = adminLogin
            };
            Marker terminalmarker8 = new Marker()
            {
                Type = ctx.MarkerTypes.FirstOrDefaultAsync(x => x.Name == "bank").Result,
                Lat = 50.6057137,
                Lng = 26.2723808,
                Name = "ATM",
                Address = terminal8,
                Picture = terminalImage,
                Description = "ATM Privatbank",
                Login = adminLogin
            };
            Marker terminalmarker9 = new Marker()
            {
                Type = ctx.MarkerTypes.FirstOrDefaultAsync(x => x.Name == "bank").Result,
                Lat = 50.6073427,
                Lng = 26.2588497,
                Name = "ATM",
                Address = terminal9,
                Picture = terminalImage,
                Description = "ATM Privatbank",
                Login = adminLogin
            };
            Marker terminalmarker10= new Marker()
            {
                Type = ctx.MarkerTypes.FirstOrDefaultAsync(x => x.Name == "bank").Result,
                Lat = 50.6095943,
                Lng = 26.2614005,
                Name = "ATM",
                Address = terminal10,
                Picture = terminalImage,
                Description = "ATM Privatbank",
                Login = adminLogin
            };
            Marker terminalmarker11 = new Marker()
            {
                Type = ctx.MarkerTypes.FirstOrDefaultAsync(x => x.Name == "bank").Result,
                Lat = 50.6194412,
                Lng = 26.2438825,
                Name = "ATM",
                Address = terminal11,
                Picture = terminalImage,
                Description = "ATM Privatbank",
                Login = adminLogin
            };
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
            ctx.Markers.Add(librarymarker1);
            ctx.Markers.Add(librarymarker2);
            ctx.Markers.Add(librarymarker3);
            ctx.Markers.Add(librarymarker4);
            ctx.Markers.Add(librarymarker5);
            ctx.Markers.Add(terminalmarker1);
            ctx.Markers.Add(terminalmarker2);
            ctx.Markers.Add(terminalmarker3);
            ctx.Markers.Add(terminalmarker4);
            ctx.Markers.Add(terminalmarker5);
            ctx.Markers.Add(terminalmarker6);
            ctx.Markers.Add(terminalmarker7);
            ctx.Markers.Add(terminalmarker8);
            ctx.Markers.Add(terminalmarker9);
            ctx.Markers.Add(terminalmarker10);
            ctx.Markers.Add(terminalmarker11);
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
            ctx.Contacts.Add(new Contact() { Name = "0567161131", Marker = terminalmarker1 });
            ctx.Contacts.Add(new Contact() { Name = "0567161131", Marker = terminalmarker2 });
            ctx.Contacts.Add(new Contact() { Name = "0567161131", Marker = terminalmarker3 });
            ctx.Contacts.Add(new Contact() { Name = "0567161131", Marker = terminalmarker4 });
            ctx.Contacts.Add(new Contact() { Name = "0567161131", Marker = terminalmarker5 });
            ctx.Contacts.Add(new Contact() { Name = "0567161131", Marker = terminalmarker6 });
            ctx.Contacts.Add(new Contact() { Name = "0567161131", Marker = terminalmarker7 });
            ctx.Contacts.Add(new Contact() { Name = "0567161131", Marker = terminalmarker8 });
            ctx.Contacts.Add(new Contact() { Name = "0567161131", Marker = terminalmarker9 });
            ctx.Contacts.Add(new Contact() { Name = "0567161131", Marker = terminalmarker10 });
            ctx.Contacts.Add(new Contact() { Name = "0567161131", Marker = terminalmarker11 });
            ctx.Contacts.Add(new Contact() { Name = "0362252042", Marker = librarymarker1 });
            ctx.Contacts.Add(new Contact() { Name = "0362681805", Marker = librarymarker2 });
            ctx.Contacts.Add(new Contact() { Name = "0362263585", Marker = librarymarker3 });
            ctx.SaveChanges();
            base.Seed(ctx);
        }
    }
}