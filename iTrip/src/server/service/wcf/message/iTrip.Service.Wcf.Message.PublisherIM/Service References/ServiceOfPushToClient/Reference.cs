﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18063
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace iTrip.Service.Wcf.Message.PublisherIM.ServiceOfPushToClient {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceOfPushToClient.IServerPushToClient")]
    public interface IServerPushToClient {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServerPushToClient/PushPackage")]
        void PushPackage(iTrip.iPP.Proxy.ipp_Package[] package, string receiver);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServerPushToClient/PushPackage")]
        System.Threading.Tasks.Task PushPackageAsync(iTrip.iPP.Proxy.ipp_Package[] package, string receiver);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServerPushToClientChannel : iTrip.Service.Wcf.Message.PublisherIM.ServiceOfPushToClient.IServerPushToClient, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServerPushToClientClient : System.ServiceModel.ClientBase<iTrip.Service.Wcf.Message.PublisherIM.ServiceOfPushToClient.IServerPushToClient>, iTrip.Service.Wcf.Message.PublisherIM.ServiceOfPushToClient.IServerPushToClient {
        
        public ServerPushToClientClient() {
        }
        
        public ServerPushToClientClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServerPushToClientClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServerPushToClientClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServerPushToClientClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void PushPackage(iTrip.iPP.Proxy.ipp_Package[] package, string receiver) {
            base.Channel.PushPackage(package, receiver);
        }
        
        public System.Threading.Tasks.Task PushPackageAsync(iTrip.iPP.Proxy.ipp_Package[] package, string receiver) {
            return base.Channel.PushPackageAsync(package, receiver);
        }
    }
}
