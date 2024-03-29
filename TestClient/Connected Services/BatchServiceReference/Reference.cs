﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestClient.BatchServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BatchServiceReference.IBatchService")]
    public interface IBatchService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBatchService/DoWork", ReplyAction="http://tempuri.org/IBatchService/DoWorkResponse")]
        string DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBatchService/DoWork", ReplyAction="http://tempuri.org/IBatchService/DoWorkResponse")]
        System.Threading.Tasks.Task<string> DoWorkAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBatchService/HandleNewSale", ReplyAction="http://tempuri.org/IBatchService/HandleNewSaleResponse")]
        void HandleNewSale(Core.SalesOrderHeader sale);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBatchService/HandleNewSale", ReplyAction="http://tempuri.org/IBatchService/HandleNewSaleResponse")]
        System.Threading.Tasks.Task HandleNewSaleAsync(Core.SalesOrderHeader sale);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBatchService/ComputeSalesByYearBatchView", ReplyAction="http://tempuri.org/IBatchService/ComputeSalesByYearBatchViewResponse")]
        void ComputeSalesByYearBatchView();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBatchService/ComputeSalesByYearBatchView", ReplyAction="http://tempuri.org/IBatchService/ComputeSalesByYearBatchViewResponse")]
        System.Threading.Tasks.Task ComputeSalesByYearBatchViewAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBatchServiceChannel : TestClient.BatchServiceReference.IBatchService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BatchServiceClient : System.ServiceModel.ClientBase<TestClient.BatchServiceReference.IBatchService>, TestClient.BatchServiceReference.IBatchService {
        
        public BatchServiceClient() {
        }
        
        public BatchServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BatchServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BatchServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BatchServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string DoWork() {
            return base.Channel.DoWork();
        }
        
        public System.Threading.Tasks.Task<string> DoWorkAsync() {
            return base.Channel.DoWorkAsync();
        }
        
        public void HandleNewSale(Core.SalesOrderHeader sale) {
            base.Channel.HandleNewSale(sale);
        }
        
        public System.Threading.Tasks.Task HandleNewSaleAsync(Core.SalesOrderHeader sale) {
            return base.Channel.HandleNewSaleAsync(sale);
        }
        
        public void ComputeSalesByYearBatchView() {
            base.Channel.ComputeSalesByYearBatchView();
        }
        
        public System.Threading.Tasks.Task ComputeSalesByYearBatchViewAsync() {
            return base.Channel.ComputeSalesByYearBatchViewAsync();
        }
    }
}
