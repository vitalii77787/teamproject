﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IDalForUi.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MarkerWcf", Namespace="http://schemas.datacontract.org/2004/07/WcfGoogleMaps")]
    [System.SerializableAttribute()]
    public partial class MarkerWcf : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] ContactsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double LatField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double LngField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MarkerTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] PictureField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StreetField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string City {
            get {
                return this.CityField;
            }
            set {
                if ((object.ReferenceEquals(this.CityField, value) != true)) {
                    this.CityField = value;
                    this.RaisePropertyChanged("City");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] Contacts {
            get {
                return this.ContactsField;
            }
            set {
                if ((object.ReferenceEquals(this.ContactsField, value) != true)) {
                    this.ContactsField = value;
                    this.RaisePropertyChanged("Contacts");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Lat {
            get {
                return this.LatField;
            }
            set {
                if ((this.LatField.Equals(value) != true)) {
                    this.LatField = value;
                    this.RaisePropertyChanged("Lat");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Lng {
            get {
                return this.LngField;
            }
            set {
                if ((this.LngField.Equals(value) != true)) {
                    this.LngField = value;
                    this.RaisePropertyChanged("Lng");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MarkerType {
            get {
                return this.MarkerTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.MarkerTypeField, value) != true)) {
                    this.MarkerTypeField = value;
                    this.RaisePropertyChanged("MarkerType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Number {
            get {
                return this.NumberField;
            }
            set {
                if ((object.ReferenceEquals(this.NumberField, value) != true)) {
                    this.NumberField = value;
                    this.RaisePropertyChanged("Number");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] Picture {
            get {
                return this.PictureField;
            }
            set {
                if ((object.ReferenceEquals(this.PictureField, value) != true)) {
                    this.PictureField = value;
                    this.RaisePropertyChanged("Picture");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Street {
            get {
                return this.StreetField;
            }
            set {
                if ((object.ReferenceEquals(this.StreetField, value) != true)) {
                    this.StreetField = value;
                    this.RaisePropertyChanged("Street");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserName {
            get {
                return this.UserNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNameField, value) != true)) {
                    this.UserNameField = value;
                    this.RaisePropertyChanged("UserName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CityWcf", Namespace="http://schemas.datacontract.org/2004/07/WcfGoogleMaps")]
    [System.SerializableAttribute()]
    public partial class CityWcf : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] CityAddressesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CityIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CityNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] CityAddresses {
            get {
                return this.CityAddressesField;
            }
            set {
                if ((object.ReferenceEquals(this.CityAddressesField, value) != true)) {
                    this.CityAddressesField = value;
                    this.RaisePropertyChanged("CityAddresses");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CityId {
            get {
                return this.CityIdField;
            }
            set {
                if ((this.CityIdField.Equals(value) != true)) {
                    this.CityIdField = value;
                    this.RaisePropertyChanged("CityId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CityName {
            get {
                return this.CityNameField;
            }
            set {
                if ((object.ReferenceEquals(this.CityNameField, value) != true)) {
                    this.CityNameField = value;
                    this.RaisePropertyChanged("CityName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MarkerTypeWcf", Namespace="http://schemas.datacontract.org/2004/07/WcfGoogleMaps")]
    [System.SerializableAttribute()]
    public partial class MarkerTypeWcf : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] MarkersField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] Markers {
            get {
                return this.MarkersField;
            }
            set {
                if ((object.ReferenceEquals(this.MarkersField, value) != true)) {
                    this.MarkersField = value;
                    this.RaisePropertyChanged("Markers");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/IsSuchAddress", ReplyAction="http://tempuri.org/IService1/IsSuchAddressResponse")]
        bool IsSuchAddress(string city, string street, string number);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/IsSuchAddress", ReplyAction="http://tempuri.org/IService1/IsSuchAddressResponse")]
        System.Threading.Tasks.Task<bool> IsSuchAddressAsync(string city, string street, string number);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddNewUserPlace", ReplyAction="http://tempuri.org/IService1/AddNewUserPlaceResponse")]
        void AddNewUserPlace(string name, string city, string street, string number, string markerType, double lat, double lng, byte[] picture, string userName, string description, string[] contacts);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddNewUserPlace", ReplyAction="http://tempuri.org/IService1/AddNewUserPlaceResponse")]
        System.Threading.Tasks.Task AddNewUserPlaceAsync(string name, string city, string street, string number, string markerType, double lat, double lng, byte[] picture, string userName, string description, string[] contacts);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddNewMarkerType", ReplyAction="http://tempuri.org/IService1/AddNewMarkerTypeResponse")]
        void AddNewMarkerType(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddNewMarkerType", ReplyAction="http://tempuri.org/IService1/AddNewMarkerTypeResponse")]
        System.Threading.Tasks.Task AddNewMarkerTypeAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetMarkersOfType", ReplyAction="http://tempuri.org/IService1/GetMarkersOfTypeResponse")]
        IDalForUi.ServiceReference1.MarkerWcf[] GetMarkersOfType(string markerType, string city);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetMarkersOfType", ReplyAction="http://tempuri.org/IService1/GetMarkersOfTypeResponse")]
        System.Threading.Tasks.Task<IDalForUi.ServiceReference1.MarkerWcf[]> GetMarkersOfTypeAsync(string markerType, string city);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetMarkersOfUser", ReplyAction="http://tempuri.org/IService1/GetMarkersOfUserResponse")]
        IDalForUi.ServiceReference1.MarkerWcf[] GetMarkersOfUser(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetMarkersOfUser", ReplyAction="http://tempuri.org/IService1/GetMarkersOfUserResponse")]
        System.Threading.Tasks.Task<IDalForUi.ServiceReference1.MarkerWcf[]> GetMarkersOfUserAsync(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddNewUser", ReplyAction="http://tempuri.org/IService1/AddNewUserResponse")]
        void AddNewUser(string userName, byte[] password, string city, string street, string number, string loginStatus);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddNewUser", ReplyAction="http://tempuri.org/IService1/AddNewUserResponse")]
        System.Threading.Tasks.Task AddNewUserAsync(string userName, byte[] password, string city, string street, string number, string loginStatus);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/IsSuchUserNameInDB", ReplyAction="http://tempuri.org/IService1/IsSuchUserNameInDBResponse")]
        bool IsSuchUserNameInDB(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/IsSuchUserNameInDB", ReplyAction="http://tempuri.org/IService1/IsSuchUserNameInDBResponse")]
        System.Threading.Tasks.Task<bool> IsSuchUserNameInDBAsync(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/IsPasswordsEquals", ReplyAction="http://tempuri.org/IService1/IsPasswordsEqualsResponse")]
        bool IsPasswordsEquals(string userName, byte[] password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/IsPasswordsEquals", ReplyAction="http://tempuri.org/IService1/IsPasswordsEqualsResponse")]
        System.Threading.Tasks.Task<bool> IsPasswordsEqualsAsync(string userName, byte[] password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllPlaceTypes", ReplyAction="http://tempuri.org/IService1/GetAllPlaceTypesResponse")]
        string[] GetAllPlaceTypes();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllPlaceTypes", ReplyAction="http://tempuri.org/IService1/GetAllPlaceTypesResponse")]
        System.Threading.Tasks.Task<string[]> GetAllPlaceTypesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllCities", ReplyAction="http://tempuri.org/IService1/GetAllCitiesResponse")]
        string[] GetAllCities();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllCities", ReplyAction="http://tempuri.org/IService1/GetAllCitiesResponse")]
        System.Threading.Tasks.Task<string[]> GetAllCitiesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetLoginStatusOfUser", ReplyAction="http://tempuri.org/IService1/GetLoginStatusOfUserResponse")]
        string GetLoginStatusOfUser(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetLoginStatusOfUser", ReplyAction="http://tempuri.org/IService1/GetLoginStatusOfUserResponse")]
        System.Threading.Tasks.Task<string> GetLoginStatusOfUserAsync(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetCityStreetAndNumberOfUser", ReplyAction="http://tempuri.org/IService1/GetCityStreetAndNumberOfUserResponse")]
        string[] GetCityStreetAndNumberOfUser(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetCityStreetAndNumberOfUser", ReplyAction="http://tempuri.org/IService1/GetCityStreetAndNumberOfUserResponse")]
        System.Threading.Tasks.Task<string[]> GetCityStreetAndNumberOfUserAsync(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDefaultPicture", ReplyAction="http://tempuri.org/IService1/GetDefaultPictureResponse")]
        byte[] GetDefaultPicture();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDefaultPicture", ReplyAction="http://tempuri.org/IService1/GetDefaultPictureResponse")]
        System.Threading.Tasks.Task<byte[]> GetDefaultPictureAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllMarkersDto", ReplyAction="http://tempuri.org/IService1/GetAllMarkersDtoResponse")]
        IDalForUi.ServiceReference1.MarkerWcf[] GetAllMarkersDto();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllMarkersDto", ReplyAction="http://tempuri.org/IService1/GetAllMarkersDtoResponse")]
        System.Threading.Tasks.Task<IDalForUi.ServiceReference1.MarkerWcf[]> GetAllMarkersDtoAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllCitiesDto", ReplyAction="http://tempuri.org/IService1/GetAllCitiesDtoResponse")]
        IDalForUi.ServiceReference1.CityWcf[] GetAllCitiesDto();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllCitiesDto", ReplyAction="http://tempuri.org/IService1/GetAllCitiesDtoResponse")]
        System.Threading.Tasks.Task<IDalForUi.ServiceReference1.CityWcf[]> GetAllCitiesDtoAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllMarkerTypesDto", ReplyAction="http://tempuri.org/IService1/GetAllMarkerTypesDtoResponse")]
        IDalForUi.ServiceReference1.MarkerTypeWcf[] GetAllMarkerTypesDto();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllMarkerTypesDto", ReplyAction="http://tempuri.org/IService1/GetAllMarkerTypesDtoResponse")]
        System.Threading.Tasks.Task<IDalForUi.ServiceReference1.MarkerTypeWcf[]> GetAllMarkerTypesDtoAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UpdateMarker", ReplyAction="http://tempuri.org/IService1/UpdateMarkerResponse")]
        void UpdateMarker(IDalForUi.ServiceReference1.MarkerWcf newMarker);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UpdateMarker", ReplyAction="http://tempuri.org/IService1/UpdateMarkerResponse")]
        System.Threading.Tasks.Task UpdateMarkerAsync(IDalForUi.ServiceReference1.MarkerWcf newMarker);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DeleteMarker", ReplyAction="http://tempuri.org/IService1/DeleteMarkerResponse")]
        void DeleteMarker(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DeleteMarker", ReplyAction="http://tempuri.org/IService1/DeleteMarkerResponse")]
        System.Threading.Tasks.Task DeleteMarkerAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : IDalForUi.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<IDalForUi.ServiceReference1.IService1>, IDalForUi.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool IsSuchAddress(string city, string street, string number) {
            return base.Channel.IsSuchAddress(city, street, number);
        }
        
        public System.Threading.Tasks.Task<bool> IsSuchAddressAsync(string city, string street, string number) {
            return base.Channel.IsSuchAddressAsync(city, street, number);
        }
        
        public void AddNewUserPlace(string name, string city, string street, string number, string markerType, double lat, double lng, byte[] picture, string userName, string description, string[] contacts) {
            base.Channel.AddNewUserPlace(name, city, street, number, markerType, lat, lng, picture, userName, description, contacts);
        }
        
        public System.Threading.Tasks.Task AddNewUserPlaceAsync(string name, string city, string street, string number, string markerType, double lat, double lng, byte[] picture, string userName, string description, string[] contacts) {
            return base.Channel.AddNewUserPlaceAsync(name, city, street, number, markerType, lat, lng, picture, userName, description, contacts);
        }
        
        public void AddNewMarkerType(string name) {
            base.Channel.AddNewMarkerType(name);
        }
        
        public System.Threading.Tasks.Task AddNewMarkerTypeAsync(string name) {
            return base.Channel.AddNewMarkerTypeAsync(name);
        }
        
        public IDalForUi.ServiceReference1.MarkerWcf[] GetMarkersOfType(string markerType, string city) {
            return base.Channel.GetMarkersOfType(markerType, city);
        }
        
        public System.Threading.Tasks.Task<IDalForUi.ServiceReference1.MarkerWcf[]> GetMarkersOfTypeAsync(string markerType, string city) {
            return base.Channel.GetMarkersOfTypeAsync(markerType, city);
        }
        
        public IDalForUi.ServiceReference1.MarkerWcf[] GetMarkersOfUser(string userName) {
            return base.Channel.GetMarkersOfUser(userName);
        }
        
        public System.Threading.Tasks.Task<IDalForUi.ServiceReference1.MarkerWcf[]> GetMarkersOfUserAsync(string userName) {
            return base.Channel.GetMarkersOfUserAsync(userName);
        }
        
        public void AddNewUser(string userName, byte[] password, string city, string street, string number, string loginStatus) {
            base.Channel.AddNewUser(userName, password, city, street, number, loginStatus);
        }
        
        public System.Threading.Tasks.Task AddNewUserAsync(string userName, byte[] password, string city, string street, string number, string loginStatus) {
            return base.Channel.AddNewUserAsync(userName, password, city, street, number, loginStatus);
        }
        
        public bool IsSuchUserNameInDB(string userName) {
            return base.Channel.IsSuchUserNameInDB(userName);
        }
        
        public System.Threading.Tasks.Task<bool> IsSuchUserNameInDBAsync(string userName) {
            return base.Channel.IsSuchUserNameInDBAsync(userName);
        }
        
        public bool IsPasswordsEquals(string userName, byte[] password) {
            return base.Channel.IsPasswordsEquals(userName, password);
        }
        
        public System.Threading.Tasks.Task<bool> IsPasswordsEqualsAsync(string userName, byte[] password) {
            return base.Channel.IsPasswordsEqualsAsync(userName, password);
        }
        
        public string[] GetAllPlaceTypes() {
            return base.Channel.GetAllPlaceTypes();
        }
        
        public System.Threading.Tasks.Task<string[]> GetAllPlaceTypesAsync() {
            return base.Channel.GetAllPlaceTypesAsync();
        }
        
        public string[] GetAllCities() {
            return base.Channel.GetAllCities();
        }
        
        public System.Threading.Tasks.Task<string[]> GetAllCitiesAsync() {
            return base.Channel.GetAllCitiesAsync();
        }
        
        public string GetLoginStatusOfUser(string userName) {
            return base.Channel.GetLoginStatusOfUser(userName);
        }
        
        public System.Threading.Tasks.Task<string> GetLoginStatusOfUserAsync(string userName) {
            return base.Channel.GetLoginStatusOfUserAsync(userName);
        }
        
        public string[] GetCityStreetAndNumberOfUser(string userName) {
            return base.Channel.GetCityStreetAndNumberOfUser(userName);
        }
        
        public System.Threading.Tasks.Task<string[]> GetCityStreetAndNumberOfUserAsync(string userName) {
            return base.Channel.GetCityStreetAndNumberOfUserAsync(userName);
        }
        
        public byte[] GetDefaultPicture() {
            return base.Channel.GetDefaultPicture();
        }
        
        public System.Threading.Tasks.Task<byte[]> GetDefaultPictureAsync() {
            return base.Channel.GetDefaultPictureAsync();
        }
        
        public IDalForUi.ServiceReference1.MarkerWcf[] GetAllMarkersDto() {
            return base.Channel.GetAllMarkersDto();
        }
        
        public System.Threading.Tasks.Task<IDalForUi.ServiceReference1.MarkerWcf[]> GetAllMarkersDtoAsync() {
            return base.Channel.GetAllMarkersDtoAsync();
        }
        
        public IDalForUi.ServiceReference1.CityWcf[] GetAllCitiesDto() {
            return base.Channel.GetAllCitiesDto();
        }
        
        public System.Threading.Tasks.Task<IDalForUi.ServiceReference1.CityWcf[]> GetAllCitiesDtoAsync() {
            return base.Channel.GetAllCitiesDtoAsync();
        }
        
        public IDalForUi.ServiceReference1.MarkerTypeWcf[] GetAllMarkerTypesDto() {
            return base.Channel.GetAllMarkerTypesDto();
        }
        
        public System.Threading.Tasks.Task<IDalForUi.ServiceReference1.MarkerTypeWcf[]> GetAllMarkerTypesDtoAsync() {
            return base.Channel.GetAllMarkerTypesDtoAsync();
        }
        
        public void UpdateMarker(IDalForUi.ServiceReference1.MarkerWcf newMarker) {
            base.Channel.UpdateMarker(newMarker);
        }
        
        public System.Threading.Tasks.Task UpdateMarkerAsync(IDalForUi.ServiceReference1.MarkerWcf newMarker) {
            return base.Channel.UpdateMarkerAsync(newMarker);
        }
        
        public void DeleteMarker(int id) {
            base.Channel.DeleteMarker(id);
        }
        
        public System.Threading.Tasks.Task DeleteMarkerAsync(int id) {
            return base.Channel.DeleteMarkerAsync(id);
        }
    }
}
