namespace DalForWcfLib
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class GoogleMapModel : DbContext
    {
        // Your context has been configured to use a 'GoogleMapModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DalForWcfLib.GoogleMapModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'GoogleMapModel' 
        // connection string in the application configuration file.
        public GoogleMapModel()
            : base("name=GoogleMapModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<LoginStatus> LoginStatuses { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<MarkerType> MarkerTypes { get; set; }
        public virtual DbSet<Marker> Markers { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
    }

    public class LoginStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Login> Logins { get; set; }
    }

    public class Login
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Password { get; set; }
        public virtual LoginStatus LoginStatus { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Marker> Markers { get; set; }
    }


    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }

    public class Address
    {
        public int Id { get; set; }
        //public string Name { get; set; }
        public virtual City City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public virtual ICollection<Login> Logins { get; set; }
        public virtual ICollection<Marker> Markers { get; set; }
    }

    public class MarkerType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Marker> Markers { get; set; }
    }

    public class Marker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Address Address { get; set; }
        public virtual MarkerType Type { get; set; }
        public double Lat { get; set; }  // coordinate for google map
        public double Lng { get; set; }  // coordinate long for google map
        public byte[] Picture { get; set; }
        public virtual Login Login { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }

    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Marker Marker { get; set; }
    }
}