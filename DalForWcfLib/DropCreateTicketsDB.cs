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


            var directoryPath = System.IO.Directory.GetCurrentDirectory();
            //byte[] supermarketImage = File.ReadAllBytes(@"Resources\supermarket_icon.jpg");
            //byte[] schoolImage = File.ReadAllBytes(@"Resources\school_icon.jpg");
            byte[] otherImage = File.ReadAllBytes(@"C: \Users\vitalii_best\Downloads\bankimage.jpg"); /*(@"C:\Users\Serge\Source\Repos\team\teamproject\DalForWcfLib\Resources\Pointer.jpg");*/
            byte[] supermarketImage = File.ReadAllBytes(@"C: \Users\vitalii_best\Downloads\bankimage.jpg"); /*(@"C:\Users\Serge\Source\Repos\team\teamproject\DalForWcfLib\Resources\supermarket_icon.jpg");*/
            byte[] schoolImage = File.ReadAllBytes(@"C: \Users\vitalii_best\Downloads\bankimage.jpg");/* (@"C:\Users\Serge\Source\Repos\team\teamproject\DalForWcfLib\Resources\school_icon.jpg");*/
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

            Address school12Address = new Address() { City = cityRivne, Street = "Академіка Грушевського", Number = "81А" };
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
            ctx.Markers.Add(school12Marker);
            ctx.SaveChanges();
            ctx.Contacts.Add(new Contact() { Name = "0362 20 52 04", Marker = school12Marker });
            ctx.SaveChanges();
            base.Seed(ctx);
        }
    }
}