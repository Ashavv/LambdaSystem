﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VisualClient.QueryServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="QueryServiceReference.IQueryService")]
    public interface IQueryService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQueryService/DoWork", ReplyAction="http://tempuri.org/IQueryService/DoWorkResponse")]
        string DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQueryService/DoWork", ReplyAction="http://tempuri.org/IQueryService/DoWorkResponse")]
        System.Threading.Tasks.Task<string> DoWorkAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQueryService/GetSales", ReplyAction="http://tempuri.org/IQueryService/GetSalesResponse")]
        int GetSales();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQueryService/GetSales", ReplyAction="http://tempuri.org/IQueryService/GetSalesResponse")]
        System.Threading.Tasks.Task<int> GetSalesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQueryService/GetNoOfSalesByYear", ReplyAction="http://tempuri.org/IQueryService/GetNoOfSalesByYearResponse")]
        int GetNoOfSalesByYear(int year);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IQueryService/GetNoOfSalesByYear", ReplyAction="http://tempuri.org/IQueryService/GetNoOfSalesByYearResponse")]
        System.Threading.Tasks.Task<int> GetNoOfSalesByYearAsync(int year);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IQueryServiceChannel : VisualClient.QueryServiceReference.IQueryService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class QueryServiceClient : System.ServiceModel.ClientBase<VisualClient.QueryServiceReference.IQueryService>, VisualClient.QueryServiceReference.IQueryService {
        
        public QueryServiceClient() {
        }
        
        public QueryServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public QueryServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public QueryServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public QueryServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string DoWork() {
            return base.Channel.DoWork();
        }
        
        public System.Threading.Tasks.Task<string> DoWorkAsync() {
            return base.Channel.DoWorkAsync();
        }
        
        public int GetSales() {
            return base.Channel.GetSales();
        }
        
        public System.Threading.Tasks.Task<int> GetSalesAsync() {
            return base.Channel.GetSalesAsync();
        }
        
        public int GetNoOfSalesByYear(int year) {
            return base.Channel.GetNoOfSalesByYear(year);
        }
        
        public System.Threading.Tasks.Task<int> GetNoOfSalesByYearAsync(int year) {
            return base.Channel.GetNoOfSalesByYearAsync(year);
        }
    }
}
