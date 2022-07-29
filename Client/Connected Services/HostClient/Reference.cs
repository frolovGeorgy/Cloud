﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.HostClient {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="StringCollection", Namespace="http://nlog-project.org/ws/", ItemName="l")]
    [System.SerializableAttribute()]
    public class StringCollection : System.Collections.Generic.List<string> {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://nlog-project.org/ws/", ConfigurationName="HostClient.ILogReceiverServer")]
    public interface ILogReceiverServer {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://nlog-project.org/ws/ILogReceiverServer/ProcessLogMessages", ReplyAction="http://nlog-project.org/ws/ILogReceiverServer/ProcessLogMessagesResponse")]
        void ProcessLogMessages(NLog.LogReceiverService.NLogEvents events);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://nlog-project.org/ws/ILogReceiverServer/ProcessLogMessages", ReplyAction="http://nlog-project.org/ws/ILogReceiverServer/ProcessLogMessagesResponse")]
        System.Threading.Tasks.Task ProcessLogMessagesAsync(NLog.LogReceiverService.NLogEvents events);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILogReceiverServerChannel : Client.HostClient.ILogReceiverServer, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LogReceiverServerClient : System.ServiceModel.ClientBase<Client.HostClient.ILogReceiverServer>, Client.HostClient.ILogReceiverServer {
        
        public LogReceiverServerClient() {
        }
        
        public LogReceiverServerClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public LogReceiverServerClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LogReceiverServerClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LogReceiverServerClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void ProcessLogMessages(NLog.LogReceiverService.NLogEvents events) {
            base.Channel.ProcessLogMessages(events);
        }
        
        public System.Threading.Tasks.Task ProcessLogMessagesAsync(NLog.LogReceiverService.NLogEvents events) {
            return base.Channel.ProcessLogMessagesAsync(events);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="HostClient.IServiceCloud")]
    public interface IServiceCloud {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCloud/GetCloudFileWithContent", ReplyAction="http://tempuri.org/IServiceCloud/GetCloudFileWithContentResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(MyCloud.Faults.MissingFileFault), Action="http://tempuri.org/IServiceCloud/GetCloudFileWithContentMissingFileFaultFault", Name="MissingFileFault", Namespace="http://schemas.datacontract.org/2004/07/MyCloud.Faults")]
        MyCloud.Model.CloudFileDTO GetCloudFileWithContent(int fileId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCloud/GetCloudFileWithContent", ReplyAction="http://tempuri.org/IServiceCloud/GetCloudFileWithContentResponse")]
        System.Threading.Tasks.Task<MyCloud.Model.CloudFileDTO> GetCloudFileWithContentAsync(int fileId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCloud/UploadFile", ReplyAction="http://tempuri.org/IServiceCloud/UploadFileResponse")]
        void UploadFile(MyCloud.Model.CloudFileDTO cloudFileDTO);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCloud/UploadFile", ReplyAction="http://tempuri.org/IServiceCloud/UploadFileResponse")]
        System.Threading.Tasks.Task UploadFileAsync(MyCloud.Model.CloudFileDTO cloudFileDTO);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCloud/DeleteFile", ReplyAction="http://tempuri.org/IServiceCloud/DeleteFileResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(MyCloud.Faults.MissingFileFault), Action="http://tempuri.org/IServiceCloud/DeleteFileMissingFileFaultFault", Name="MissingFileFault", Namespace="http://schemas.datacontract.org/2004/07/MyCloud.Faults")]
        void DeleteFile(int fileId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCloud/DeleteFile", ReplyAction="http://tempuri.org/IServiceCloud/DeleteFileResponse")]
        System.Threading.Tasks.Task DeleteFileAsync(int fileId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCloud/UserFilesArray", ReplyAction="http://tempuri.org/IServiceCloud/UserFilesArrayResponse")]
        MyCloud.Model.CloudFileDTO[] UserFilesArray(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCloud/UserFilesArray", ReplyAction="http://tempuri.org/IServiceCloud/UserFilesArrayResponse")]
        System.Threading.Tasks.Task<MyCloud.Model.CloudFileDTO[]> UserFilesArrayAsync(string username);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceCloudChannel : Client.HostClient.IServiceCloud, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceCloudClient : System.ServiceModel.ClientBase<Client.HostClient.IServiceCloud>, Client.HostClient.IServiceCloud {
        
        public ServiceCloudClient() {
        }
        
        public ServiceCloudClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceCloudClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceCloudClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceCloudClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public MyCloud.Model.CloudFileDTO GetCloudFileWithContent(int fileId) {
            return base.Channel.GetCloudFileWithContent(fileId);
        }
        
        public System.Threading.Tasks.Task<MyCloud.Model.CloudFileDTO> GetCloudFileWithContentAsync(int fileId) {
            return base.Channel.GetCloudFileWithContentAsync(fileId);
        }
        
        public void UploadFile(MyCloud.Model.CloudFileDTO cloudFileDTO) {
            base.Channel.UploadFile(cloudFileDTO);
        }
        
        public System.Threading.Tasks.Task UploadFileAsync(MyCloud.Model.CloudFileDTO cloudFileDTO) {
            return base.Channel.UploadFileAsync(cloudFileDTO);
        }
        
        public void DeleteFile(int fileId) {
            base.Channel.DeleteFile(fileId);
        }
        
        public System.Threading.Tasks.Task DeleteFileAsync(int fileId) {
            return base.Channel.DeleteFileAsync(fileId);
        }
        
        public MyCloud.Model.CloudFileDTO[] UserFilesArray(string username) {
            return base.Channel.UserFilesArray(username);
        }
        
        public System.Threading.Tasks.Task<MyCloud.Model.CloudFileDTO[]> UserFilesArrayAsync(string username) {
            return base.Channel.UserFilesArrayAsync(username);
        }
    }
}
