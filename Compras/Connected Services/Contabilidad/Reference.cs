﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Contabilidad
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TiposCuentasLista", Namespace="http://tempuri.org/")]
    public partial class TiposCuentasLista : object
    {
        
        private int idCuentaField;
        
        private string cuentaField;
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int idCuenta
        {
            get
            {
                return this.idCuentaField;
            }
            set
            {
                this.idCuentaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string cuenta
        {
            get
            {
                return this.cuentaField;
            }
            set
            {
                this.cuentaField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Contabilidad.SSWSSoap")]
    public interface SSWSSoap
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AsientoContable", ReplyAction="*")]
        System.Threading.Tasks.Task<Contabilidad.AsientoContableResponse> AsientoContableAsync(Contabilidad.AsientoContableRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Cuentas", ReplyAction="*")]
        System.Threading.Tasks.Task<Contabilidad.CuentasResponse> CuentasAsync(Contabilidad.CuentasRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CuentasDebito", ReplyAction="*")]
        System.Threading.Tasks.Task<Contabilidad.CuentasDebitoResponse> CuentasDebitoAsync(Contabilidad.CuentasDebitoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CuentasCredito", ReplyAction="*")]
        System.Threading.Tasks.Task<Contabilidad.CuentasCreditoResponse> CuentasCreditoAsync(Contabilidad.CuentasCreditoRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AsientoContableRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="AsientoContable", Namespace="http://tempuri.org/", Order=0)]
        public Contabilidad.AsientoContableRequestBody Body;
        
        public AsientoContableRequest()
        {
        }
        
        public AsientoContableRequest(Contabilidad.AsientoContableRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class AsientoContableRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int idAuxiliarOrigen;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string descripcion;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public int cuentaDB;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public int cuentaCR;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public double monto;
        
        public AsientoContableRequestBody()
        {
        }
        
        public AsientoContableRequestBody(int idAuxiliarOrigen, string descripcion, int cuentaDB, int cuentaCR, double monto)
        {
            this.idAuxiliarOrigen = idAuxiliarOrigen;
            this.descripcion = descripcion;
            this.cuentaDB = cuentaDB;
            this.cuentaCR = cuentaCR;
            this.monto = monto;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AsientoContableResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="AsientoContableResponse", Namespace="http://tempuri.org/", Order=0)]
        public Contabilidad.AsientoContableResponseBody Body;
        
        public AsientoContableResponse()
        {
        }
        
        public AsientoContableResponse(Contabilidad.AsientoContableResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class AsientoContableResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int AsientoContableResult;
        
        public AsientoContableResponseBody()
        {
        }
        
        public AsientoContableResponseBody(int AsientoContableResult)
        {
            this.AsientoContableResult = AsientoContableResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CuentasRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Cuentas", Namespace="http://tempuri.org/", Order=0)]
        public Contabilidad.CuentasRequestBody Body;
        
        public CuentasRequest()
        {
        }
        
        public CuentasRequest(Contabilidad.CuentasRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class CuentasRequestBody
    {
        
        public CuentasRequestBody()
        {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CuentasResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CuentasResponse", Namespace="http://tempuri.org/", Order=0)]
        public Contabilidad.CuentasResponseBody Body;
        
        public CuentasResponse()
        {
        }
        
        public CuentasResponse(Contabilidad.CuentasResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class CuentasResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public Contabilidad.TiposCuentasLista[] CuentasResult;
        
        public CuentasResponseBody()
        {
        }
        
        public CuentasResponseBody(Contabilidad.TiposCuentasLista[] CuentasResult)
        {
            this.CuentasResult = CuentasResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CuentasDebitoRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CuentasDebito", Namespace="http://tempuri.org/", Order=0)]
        public Contabilidad.CuentasDebitoRequestBody Body;
        
        public CuentasDebitoRequest()
        {
        }
        
        public CuentasDebitoRequest(Contabilidad.CuentasDebitoRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class CuentasDebitoRequestBody
    {
        
        public CuentasDebitoRequestBody()
        {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CuentasDebitoResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CuentasDebitoResponse", Namespace="http://tempuri.org/", Order=0)]
        public Contabilidad.CuentasDebitoResponseBody Body;
        
        public CuentasDebitoResponse()
        {
        }
        
        public CuentasDebitoResponse(Contabilidad.CuentasDebitoResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class CuentasDebitoResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public Contabilidad.TiposCuentasLista[] CuentasDebitoResult;
        
        public CuentasDebitoResponseBody()
        {
        }
        
        public CuentasDebitoResponseBody(Contabilidad.TiposCuentasLista[] CuentasDebitoResult)
        {
            this.CuentasDebitoResult = CuentasDebitoResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CuentasCreditoRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CuentasCredito", Namespace="http://tempuri.org/", Order=0)]
        public Contabilidad.CuentasCreditoRequestBody Body;
        
        public CuentasCreditoRequest()
        {
        }
        
        public CuentasCreditoRequest(Contabilidad.CuentasCreditoRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class CuentasCreditoRequestBody
    {
        
        public CuentasCreditoRequestBody()
        {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CuentasCreditoResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CuentasCreditoResponse", Namespace="http://tempuri.org/", Order=0)]
        public Contabilidad.CuentasCreditoResponseBody Body;
        
        public CuentasCreditoResponse()
        {
        }
        
        public CuentasCreditoResponse(Contabilidad.CuentasCreditoResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class CuentasCreditoResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public Contabilidad.TiposCuentasLista[] CuentasCreditoResult;
        
        public CuentasCreditoResponseBody()
        {
        }
        
        public CuentasCreditoResponseBody(Contabilidad.TiposCuentasLista[] CuentasCreditoResult)
        {
            this.CuentasCreditoResult = CuentasCreditoResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public interface SSWSSoapChannel : Contabilidad.SSWSSoap, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public partial class SSWSSoapClient : System.ServiceModel.ClientBase<Contabilidad.SSWSSoap>, Contabilidad.SSWSSoap
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public SSWSSoapClient(EndpointConfiguration endpointConfiguration) : 
                base(SSWSSoapClient.GetBindingForEndpoint(endpointConfiguration), SSWSSoapClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SSWSSoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(SSWSSoapClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SSWSSoapClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(SSWSSoapClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SSWSSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Contabilidad.AsientoContableResponse> Contabilidad.SSWSSoap.AsientoContableAsync(Contabilidad.AsientoContableRequest request)
        {
            return base.Channel.AsientoContableAsync(request);
        }
        
        public System.Threading.Tasks.Task<Contabilidad.AsientoContableResponse> AsientoContableAsync(int idAuxiliarOrigen, string descripcion, int cuentaDB, int cuentaCR, double monto)
        {
            Contabilidad.AsientoContableRequest inValue = new Contabilidad.AsientoContableRequest();
            inValue.Body = new Contabilidad.AsientoContableRequestBody();
            inValue.Body.idAuxiliarOrigen = idAuxiliarOrigen;
            inValue.Body.descripcion = descripcion;
            inValue.Body.cuentaDB = cuentaDB;
            inValue.Body.cuentaCR = cuentaCR;
            inValue.Body.monto = monto;
            return ((Contabilidad.SSWSSoap)(this)).AsientoContableAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Contabilidad.CuentasResponse> Contabilidad.SSWSSoap.CuentasAsync(Contabilidad.CuentasRequest request)
        {
            return base.Channel.CuentasAsync(request);
        }
        
        public System.Threading.Tasks.Task<Contabilidad.CuentasResponse> CuentasAsync()
        {
            Contabilidad.CuentasRequest inValue = new Contabilidad.CuentasRequest();
            inValue.Body = new Contabilidad.CuentasRequestBody();
            return ((Contabilidad.SSWSSoap)(this)).CuentasAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Contabilidad.CuentasDebitoResponse> Contabilidad.SSWSSoap.CuentasDebitoAsync(Contabilidad.CuentasDebitoRequest request)
        {
            return base.Channel.CuentasDebitoAsync(request);
        }
        
        public System.Threading.Tasks.Task<Contabilidad.CuentasDebitoResponse> CuentasDebitoAsync()
        {
            Contabilidad.CuentasDebitoRequest inValue = new Contabilidad.CuentasDebitoRequest();
            inValue.Body = new Contabilidad.CuentasDebitoRequestBody();
            return ((Contabilidad.SSWSSoap)(this)).CuentasDebitoAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Contabilidad.CuentasCreditoResponse> Contabilidad.SSWSSoap.CuentasCreditoAsync(Contabilidad.CuentasCreditoRequest request)
        {
            return base.Channel.CuentasCreditoAsync(request);
        }
        
        public System.Threading.Tasks.Task<Contabilidad.CuentasCreditoResponse> CuentasCreditoAsync()
        {
            Contabilidad.CuentasCreditoRequest inValue = new Contabilidad.CuentasCreditoRequest();
            inValue.Body = new Contabilidad.CuentasCreditoRequestBody();
            return ((Contabilidad.SSWSSoap)(this)).CuentasCreditoAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.SSWSSoap))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            if ((endpointConfiguration == EndpointConfiguration.SSWSSoap12))
            {
                System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
                System.ServiceModel.Channels.TextMessageEncodingBindingElement textBindingElement = new System.ServiceModel.Channels.TextMessageEncodingBindingElement();
                textBindingElement.MessageVersion = System.ServiceModel.Channels.MessageVersion.CreateVersion(System.ServiceModel.EnvelopeVersion.Soap12, System.ServiceModel.Channels.AddressingVersion.None);
                result.Elements.Add(textBindingElement);
                System.ServiceModel.Channels.HttpTransportBindingElement httpBindingElement = new System.ServiceModel.Channels.HttpTransportBindingElement();
                httpBindingElement.AllowCookies = true;
                httpBindingElement.MaxBufferSize = int.MaxValue;
                httpBindingElement.MaxReceivedMessageSize = int.MaxValue;
                result.Elements.Add(httpBindingElement);
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.SSWSSoap))
            {
                return new System.ServiceModel.EndpointAddress("http://www.contabilidadws.somee.com/SSWS.asmx");
            }
            if ((endpointConfiguration == EndpointConfiguration.SSWSSoap12))
            {
                return new System.ServiceModel.EndpointAddress("http://www.contabilidadws.somee.com/SSWS.asmx");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        public enum EndpointConfiguration
        {
            
            SSWSSoap,
            
            SSWSSoap12,
        }
    }
}
