﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.VisualStudio.ServiceReference.Platforms, version 14.0.23107.0
// 
namespace CFIProjectUWP.DBServiceRef {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Subject", Namespace="http://schemas.datacontract.org/2004/07/CFIWCFServiceLiabrary.Model")]
    public partial class Subject : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string NameField;
        
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SubjectDetail", Namespace="http://schemas.datacontract.org/2004/07/CFIWCFServiceLiabrary.Model")]
    public partial class SubjectDetail : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string CRNField;
        
        private string CampusField;
        
        private string CompetencyNameField;
        
        private string DayOfWeekField;
        
        private string EndDateField;
        
        private string LecturerField;
        
        private string RoomField;
        
        private string StartDateField;
        
        private string SubjectCodeField;
        
        private string TimeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CRN {
            get {
                return this.CRNField;
            }
            set {
                if ((object.ReferenceEquals(this.CRNField, value) != true)) {
                    this.CRNField = value;
                    this.RaisePropertyChanged("CRN");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Campus {
            get {
                return this.CampusField;
            }
            set {
                if ((object.ReferenceEquals(this.CampusField, value) != true)) {
                    this.CampusField = value;
                    this.RaisePropertyChanged("Campus");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CompetencyName {
            get {
                return this.CompetencyNameField;
            }
            set {
                if ((object.ReferenceEquals(this.CompetencyNameField, value) != true)) {
                    this.CompetencyNameField = value;
                    this.RaisePropertyChanged("CompetencyName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DayOfWeek {
            get {
                return this.DayOfWeekField;
            }
            set {
                if ((object.ReferenceEquals(this.DayOfWeekField, value) != true)) {
                    this.DayOfWeekField = value;
                    this.RaisePropertyChanged("DayOfWeek");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EndDate {
            get {
                return this.EndDateField;
            }
            set {
                if ((object.ReferenceEquals(this.EndDateField, value) != true)) {
                    this.EndDateField = value;
                    this.RaisePropertyChanged("EndDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Lecturer {
            get {
                return this.LecturerField;
            }
            set {
                if ((object.ReferenceEquals(this.LecturerField, value) != true)) {
                    this.LecturerField = value;
                    this.RaisePropertyChanged("Lecturer");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Room {
            get {
                return this.RoomField;
            }
            set {
                if ((object.ReferenceEquals(this.RoomField, value) != true)) {
                    this.RoomField = value;
                    this.RaisePropertyChanged("Room");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StartDate {
            get {
                return this.StartDateField;
            }
            set {
                if ((object.ReferenceEquals(this.StartDateField, value) != true)) {
                    this.StartDateField = value;
                    this.RaisePropertyChanged("StartDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SubjectCode {
            get {
                return this.SubjectCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.SubjectCodeField, value) != true)) {
                    this.SubjectCodeField = value;
                    this.RaisePropertyChanged("SubjectCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Time {
            get {
                return this.TimeField;
            }
            set {
                if ((object.ReferenceEquals(this.TimeField, value) != true)) {
                    this.TimeField = value;
                    this.RaisePropertyChanged("Time");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DBServiceRef.ICFIDBService")]
    public interface ICFIDBService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICFIDBService/GetValidSubject", ReplyAction="http://tempuri.org/ICFIDBService/GetValidSubjectResponse")]
        System.Threading.Tasks.Task<CFIProjectUWP.DBServiceRef.GetValidSubjectResponse> GetValidSubjectAsync(CFIProjectUWP.DBServiceRef.GetValidSubjectRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICFIDBService/GetSubjectDetails", ReplyAction="http://tempuri.org/ICFIDBService/GetSubjectDetailsResponse")]
        System.Threading.Tasks.Task<CFIProjectUWP.DBServiceRef.GetSubjectDetailsResponse> GetSubjectDetailsAsync(CFIProjectUWP.DBServiceRef.GetSubjectDetailsRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetValidSubject", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetValidSubjectRequest {
        
        public GetValidSubjectRequest() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetValidSubjectResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetValidSubjectResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public System.Collections.ObjectModel.ObservableCollection<CFIProjectUWP.DBServiceRef.Subject> GetValidSubjectResult;
        
        public GetValidSubjectResponse() {
        }
        
        public GetValidSubjectResponse(System.Collections.ObjectModel.ObservableCollection<CFIProjectUWP.DBServiceRef.Subject> GetValidSubjectResult) {
            this.GetValidSubjectResult = GetValidSubjectResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetSubjectDetails", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetSubjectDetailsRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public CFIProjectUWP.DBServiceRef.Subject subject;
        
        public GetSubjectDetailsRequest() {
        }
        
        public GetSubjectDetailsRequest(CFIProjectUWP.DBServiceRef.Subject subject) {
            this.subject = subject;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetSubjectDetailsResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetSubjectDetailsResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public System.Collections.ObjectModel.ObservableCollection<CFIProjectUWP.DBServiceRef.SubjectDetail> GetSubjectDetailsResult;
        
        public GetSubjectDetailsResponse() {
        }
        
        public GetSubjectDetailsResponse(System.Collections.ObjectModel.ObservableCollection<CFIProjectUWP.DBServiceRef.SubjectDetail> GetSubjectDetailsResult) {
            this.GetSubjectDetailsResult = GetSubjectDetailsResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICFIDBServiceChannel : CFIProjectUWP.DBServiceRef.ICFIDBService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CFIDBServiceClient : System.ServiceModel.ClientBase<CFIProjectUWP.DBServiceRef.ICFIDBService>, CFIProjectUWP.DBServiceRef.ICFIDBService {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public CFIDBServiceClient() : 
                base(CFIDBServiceClient.GetDefaultBinding(), CFIDBServiceClient.GetDefaultEndpointAddress()) {
            this.Endpoint.Name = EndpointConfiguration.MybasicHttpBinding.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CFIDBServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(CFIDBServiceClient.GetBindingForEndpoint(endpointConfiguration), CFIDBServiceClient.GetEndpointAddress(endpointConfiguration)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CFIDBServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(CFIDBServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CFIDBServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(CFIDBServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CFIDBServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Threading.Tasks.Task<CFIProjectUWP.DBServiceRef.GetValidSubjectResponse> GetValidSubjectAsync(CFIProjectUWP.DBServiceRef.GetValidSubjectRequest request) {
            return base.Channel.GetValidSubjectAsync(request);
        }
        
        public System.Threading.Tasks.Task<CFIProjectUWP.DBServiceRef.GetSubjectDetailsResponse> GetSubjectDetailsAsync(CFIProjectUWP.DBServiceRef.GetSubjectDetailsRequest request) {
            return base.Channel.GetSubjectDetailsAsync(request);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.MybasicHttpBinding)) {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.MybasicHttpBinding)) {
                return new System.ServiceModel.EndpointAddress("http://localhost:1988/MybasicHttpBinding");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding() {
            return CFIDBServiceClient.GetBindingForEndpoint(EndpointConfiguration.MybasicHttpBinding);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress() {
            return CFIDBServiceClient.GetEndpointAddress(EndpointConfiguration.MybasicHttpBinding);
        }
        
        public enum EndpointConfiguration {
            
            MybasicHttpBinding,
        }
    }
}