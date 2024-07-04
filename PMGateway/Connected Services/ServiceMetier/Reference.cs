﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceMetier
{
    using System;
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/MetierPM")]
    public partial class CompositeType : object
    {
        
        private bool BoolValueField;
        
        private string StringValueField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool BoolValue
        {
            get
            {
                return this.BoolValueField;
            }
            set
            {
                this.BoolValueField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue
        {
            get
            {
                return this.StringValueField;
            }
            set
            {
                this.StringValueField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Expert", Namespace="http://schemas.datacontract.org/2004/07/MetierPM.Model")]
    public partial class Expert : ServiceMetier.Personne
    {
        
        private string SpecialiteField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Specialite
        {
            get
            {
                return this.SpecialiteField;
            }
            set
            {
                this.SpecialiteField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Personne", Namespace="http://schemas.datacontract.org/2004/07/MetierPM.Model")]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ServiceMetier.Expert))]
    public partial class Personne : object
    {
        
        private int IdField;
        
        private string NomField;
        
        private string PrenomField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nom
        {
            get
            {
                return this.NomField;
            }
            set
            {
                this.NomField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Prenom
        {
            get
            {
                return this.PrenomField;
            }
            set
            {
                this.PrenomField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceMetier.IService1")]
    public interface IService1
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<ServiceMetier.CompositeType> GetDataUsingDataContractAsync(ServiceMetier.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetExperts", ReplyAction="http://tempuri.org/IService1/GetExpertsResponse")]
        System.Threading.Tasks.Task<ServiceMetier.Expert[]> GetExpertsAsync(string Nom, string Prenom, string Specialite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllExpert", ReplyAction="http://tempuri.org/IService1/GetAllExpertResponse")]
        System.Threading.Tasks.Task<ServiceMetier.Expert[]> GetAllExpertAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetExpert", ReplyAction="http://tempuri.org/IService1/GetExpertResponse")]
        System.Threading.Tasks.Task<ServiceMetier.Expert> GetExpertAsync(System.Nullable<int> IdExpert);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddExpert", ReplyAction="http://tempuri.org/IService1/AddExpertResponse")]
        System.Threading.Tasks.Task<bool> AddExpertAsync(ServiceMetier.Expert expert);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UpdateExpert", ReplyAction="http://tempuri.org/IService1/UpdateExpertResponse")]
        System.Threading.Tasks.Task<bool> UpdateExpertAsync(ServiceMetier.Expert expert);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DeleteExpert", ReplyAction="http://tempuri.org/IService1/DeleteExpertResponse")]
        System.Threading.Tasks.Task<bool> DeleteExpertAsync(System.Nullable<int> Idexpert);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public interface IService1Channel : ServiceMetier.IService1, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public partial class Service1Client : System.ServiceModel.ClientBase<ServiceMetier.IService1>, ServiceMetier.IService1
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public Service1Client() : 
                base(Service1Client.GetDefaultBinding(), Service1Client.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IService1.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public Service1Client(EndpointConfiguration endpointConfiguration) : 
                base(Service1Client.GetBindingForEndpoint(endpointConfiguration), Service1Client.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public Service1Client(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(Service1Client.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public Service1Client(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(Service1Client.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value)
        {
            return base.Channel.GetDataAsync(value);
        }
        
        public System.Threading.Tasks.Task<ServiceMetier.CompositeType> GetDataUsingDataContractAsync(ServiceMetier.CompositeType composite)
        {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public System.Threading.Tasks.Task<ServiceMetier.Expert[]> GetExpertsAsync(string Nom, string Prenom, string Specialite)
        {
            return base.Channel.GetExpertsAsync(Nom, Prenom, Specialite);
        }
        
        public System.Threading.Tasks.Task<ServiceMetier.Expert[]> GetAllExpertAsync()
        {
            return base.Channel.GetAllExpertAsync();
        }
        
        public System.Threading.Tasks.Task<ServiceMetier.Expert> GetExpertAsync(System.Nullable<int> IdExpert)
        {
            return base.Channel.GetExpertAsync(IdExpert);
        }
        
        public System.Threading.Tasks.Task<bool> AddExpertAsync(ServiceMetier.Expert expert)
        {
            return base.Channel.AddExpertAsync(expert);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateExpertAsync(ServiceMetier.Expert expert)
        {
            return base.Channel.UpdateExpertAsync(expert);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteExpertAsync(System.Nullable<int> Idexpert)
        {
            return base.Channel.DeleteExpertAsync(Idexpert);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IService1))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IService1))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:60005/Service1.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return Service1Client.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IService1);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return Service1Client.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IService1);
        }

        internal bool AddExpert(Expert expert)
        {
            throw new NotImplementedException();
        }

        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IService1,
        }
    }
}