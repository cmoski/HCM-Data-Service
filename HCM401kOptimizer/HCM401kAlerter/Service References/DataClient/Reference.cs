﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HCM401kAlerter.DataClient {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserTickerItem", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class UserTickerItem : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LastNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DefaultTikerField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
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
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string LastName {
            get {
                return this.LastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LastNameField, value) != true)) {
                    this.LastNameField = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string FirstName {
            get {
                return this.FirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true)) {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string DefaultTiker {
            get {
                return this.DefaultTikerField;
            }
            set {
                if ((object.ReferenceEquals(this.DefaultTikerField, value) != true)) {
                    this.DefaultTikerField = value;
                    this.RaisePropertyChanged("DefaultTiker");
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
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ArrayOfString", Namespace="http://tempuri.org/", ItemName="string")]
    [System.SerializableAttribute()]
    public class ArrayOfString : System.Collections.Generic.List<string> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="HistoryRequest", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class HistoryRequest : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SymbolField;
        
        private HCM401kAlerter.DataClient.Periodicity periodicityField;
        
        private int periodField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IDField;
        
        private int MaxAmountField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Symbol {
            get {
                return this.SymbolField;
            }
            set {
                if ((object.ReferenceEquals(this.SymbolField, value) != true)) {
                    this.SymbolField = value;
                    this.RaisePropertyChanged("Symbol");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public HCM401kAlerter.DataClient.Periodicity periodicity {
            get {
                return this.periodicityField;
            }
            set {
                if ((this.periodicityField.Equals(value) != true)) {
                    this.periodicityField = value;
                    this.RaisePropertyChanged("periodicity");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=2)]
        public int period {
            get {
                return this.periodField;
            }
            set {
                if ((this.periodField.Equals(value) != true)) {
                    this.periodField = value;
                    this.RaisePropertyChanged("period");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string ID {
            get {
                return this.IDField;
            }
            set {
                if ((object.ReferenceEquals(this.IDField, value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=4)]
        public int MaxAmount {
            get {
                return this.MaxAmountField;
            }
            set {
                if ((this.MaxAmountField.Equals(value) != true)) {
                    this.MaxAmountField = value;
                    this.RaisePropertyChanged("MaxAmount");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Periodicity", Namespace="http://tempuri.org/")]
    public enum Periodicity : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Day = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Week = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Month = 2,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BarInfo", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class BarInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private HCM401kAlerter.DataClient.Bar[] BarsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private HCM401kAlerter.DataClient.HistoryRequest TokenField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public HCM401kAlerter.DataClient.Bar[] Bars {
            get {
                return this.BarsField;
            }
            set {
                if ((object.ReferenceEquals(this.BarsField, value) != true)) {
                    this.BarsField = value;
                    this.RaisePropertyChanged("Bars");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public HCM401kAlerter.DataClient.HistoryRequest Token {
            get {
                return this.TokenField;
            }
            set {
                if ((object.ReferenceEquals(this.TokenField, value) != true)) {
                    this.TokenField = value;
                    this.RaisePropertyChanged("Token");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Bar", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class Bar : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private double OpenField;
        
        private double HighField;
        
        private double LowField;
        
        private double CloseField;
        
        private double VolumeField;
        
        private System.DateTime TimeStampField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public double Open {
            get {
                return this.OpenField;
            }
            set {
                if ((this.OpenField.Equals(value) != true)) {
                    this.OpenField = value;
                    this.RaisePropertyChanged("Open");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=1)]
        public double High {
            get {
                return this.HighField;
            }
            set {
                if ((this.HighField.Equals(value) != true)) {
                    this.HighField = value;
                    this.RaisePropertyChanged("High");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=2)]
        public double Low {
            get {
                return this.LowField;
            }
            set {
                if ((this.LowField.Equals(value) != true)) {
                    this.LowField = value;
                    this.RaisePropertyChanged("Low");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=3)]
        public double Close {
            get {
                return this.CloseField;
            }
            set {
                if ((this.CloseField.Equals(value) != true)) {
                    this.CloseField = value;
                    this.RaisePropertyChanged("Close");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=4)]
        public double Volume {
            get {
                return this.VolumeField;
            }
            set {
                if ((this.VolumeField.Equals(value) != true)) {
                    this.VolumeField = value;
                    this.RaisePropertyChanged("Volume");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=5)]
        public System.DateTime TimeStamp {
            get {
                return this.TimeStampField;
            }
            set {
                if ((this.TimeStampField.Equals(value) != true)) {
                    this.TimeStampField = value;
                    this.RaisePropertyChanged("TimeStamp");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DataClient.HCM401kConnectorSoap")]
    public interface HCM401kConnectorSoap {
        
        // CODEGEN: Generating message contract since element name userName from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetUserTickerData", ReplyAction="*")]
        HCM401kAlerter.DataClient.GetUserTickerDataResponse GetUserTickerData(HCM401kAlerter.DataClient.GetUserTickerDataRequest request);
        
        // CODEGEN: Generating message contract since element name GetDefaultTickerResult from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetDefaultTicker", ReplyAction="*")]
        HCM401kAlerter.DataClient.GetDefaultTickerResponse GetDefaultTicker(HCM401kAlerter.DataClient.GetDefaultTickerRequest request);
        
        // CODEGEN: Generating message contract since element name GetAvailableTickersResult from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetAvailableTickers", ReplyAction="*")]
        HCM401kAlerter.DataClient.GetAvailableTickersResponse GetAvailableTickers(HCM401kAlerter.DataClient.GetAvailableTickersRequest request);
        
        // CODEGEN: Generating message contract since element name token from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetHistoricalDataX", ReplyAction="*")]
        HCM401kAlerter.DataClient.GetHistoricalDataXResponse GetHistoricalDataX(HCM401kAlerter.DataClient.GetHistoricalDataXRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetUserTickerDataRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetUserTickerData", Namespace="http://tempuri.org/", Order=0)]
        public HCM401kAlerter.DataClient.GetUserTickerDataRequestBody Body;
        
        public GetUserTickerDataRequest() {
        }
        
        public GetUserTickerDataRequest(HCM401kAlerter.DataClient.GetUserTickerDataRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetUserTickerDataRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string userName;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string password;
        
        public GetUserTickerDataRequestBody() {
        }
        
        public GetUserTickerDataRequestBody(string userName, string password) {
            this.userName = userName;
            this.password = password;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetUserTickerDataResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetUserTickerDataResponse", Namespace="http://tempuri.org/", Order=0)]
        public HCM401kAlerter.DataClient.GetUserTickerDataResponseBody Body;
        
        public GetUserTickerDataResponse() {
        }
        
        public GetUserTickerDataResponse(HCM401kAlerter.DataClient.GetUserTickerDataResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetUserTickerDataResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public HCM401kAlerter.DataClient.UserTickerItem[] GetUserTickerDataResult;
        
        public GetUserTickerDataResponseBody() {
        }
        
        public GetUserTickerDataResponseBody(HCM401kAlerter.DataClient.UserTickerItem[] GetUserTickerDataResult) {
            this.GetUserTickerDataResult = GetUserTickerDataResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetDefaultTickerRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetDefaultTicker", Namespace="http://tempuri.org/", Order=0)]
        public HCM401kAlerter.DataClient.GetDefaultTickerRequestBody Body;
        
        public GetDefaultTickerRequest() {
        }
        
        public GetDefaultTickerRequest(HCM401kAlerter.DataClient.GetDefaultTickerRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class GetDefaultTickerRequestBody {
        
        public GetDefaultTickerRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetDefaultTickerResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetDefaultTickerResponse", Namespace="http://tempuri.org/", Order=0)]
        public HCM401kAlerter.DataClient.GetDefaultTickerResponseBody Body;
        
        public GetDefaultTickerResponse() {
        }
        
        public GetDefaultTickerResponse(HCM401kAlerter.DataClient.GetDefaultTickerResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetDefaultTickerResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string GetDefaultTickerResult;
        
        public GetDefaultTickerResponseBody() {
        }
        
        public GetDefaultTickerResponseBody(string GetDefaultTickerResult) {
            this.GetDefaultTickerResult = GetDefaultTickerResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetAvailableTickersRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetAvailableTickers", Namespace="http://tempuri.org/", Order=0)]
        public HCM401kAlerter.DataClient.GetAvailableTickersRequestBody Body;
        
        public GetAvailableTickersRequest() {
        }
        
        public GetAvailableTickersRequest(HCM401kAlerter.DataClient.GetAvailableTickersRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class GetAvailableTickersRequestBody {
        
        public GetAvailableTickersRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetAvailableTickersResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetAvailableTickersResponse", Namespace="http://tempuri.org/", Order=0)]
        public HCM401kAlerter.DataClient.GetAvailableTickersResponseBody Body;
        
        public GetAvailableTickersResponse() {
        }
        
        public GetAvailableTickersResponse(HCM401kAlerter.DataClient.GetAvailableTickersResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetAvailableTickersResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public HCM401kAlerter.DataClient.ArrayOfString GetAvailableTickersResult;
        
        public GetAvailableTickersResponseBody() {
        }
        
        public GetAvailableTickersResponseBody(HCM401kAlerter.DataClient.ArrayOfString GetAvailableTickersResult) {
            this.GetAvailableTickersResult = GetAvailableTickersResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetHistoricalDataXRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetHistoricalDataX", Namespace="http://tempuri.org/", Order=0)]
        public HCM401kAlerter.DataClient.GetHistoricalDataXRequestBody Body;
        
        public GetHistoricalDataXRequest() {
        }
        
        public GetHistoricalDataXRequest(HCM401kAlerter.DataClient.GetHistoricalDataXRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetHistoricalDataXRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public HCM401kAlerter.DataClient.HistoryRequest token;
        
        public GetHistoricalDataXRequestBody() {
        }
        
        public GetHistoricalDataXRequestBody(HCM401kAlerter.DataClient.HistoryRequest token) {
            this.token = token;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetHistoricalDataXResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetHistoricalDataXResponse", Namespace="http://tempuri.org/", Order=0)]
        public HCM401kAlerter.DataClient.GetHistoricalDataXResponseBody Body;
        
        public GetHistoricalDataXResponse() {
        }
        
        public GetHistoricalDataXResponse(HCM401kAlerter.DataClient.GetHistoricalDataXResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetHistoricalDataXResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public HCM401kAlerter.DataClient.BarInfo GetHistoricalDataXResult;
        
        public GetHistoricalDataXResponseBody() {
        }
        
        public GetHistoricalDataXResponseBody(HCM401kAlerter.DataClient.BarInfo GetHistoricalDataXResult) {
            this.GetHistoricalDataXResult = GetHistoricalDataXResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface HCM401kConnectorSoapChannel : HCM401kAlerter.DataClient.HCM401kConnectorSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class HCM401kConnectorSoapClient : System.ServiceModel.ClientBase<HCM401kAlerter.DataClient.HCM401kConnectorSoap>, HCM401kAlerter.DataClient.HCM401kConnectorSoap {
        
        public HCM401kConnectorSoapClient() {
        }
        
        public HCM401kConnectorSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public HCM401kConnectorSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HCM401kConnectorSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HCM401kConnectorSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        HCM401kAlerter.DataClient.GetUserTickerDataResponse HCM401kAlerter.DataClient.HCM401kConnectorSoap.GetUserTickerData(HCM401kAlerter.DataClient.GetUserTickerDataRequest request) {
            return base.Channel.GetUserTickerData(request);
        }
        
        public HCM401kAlerter.DataClient.UserTickerItem[] GetUserTickerData(string userName, string password) {
            HCM401kAlerter.DataClient.GetUserTickerDataRequest inValue = new HCM401kAlerter.DataClient.GetUserTickerDataRequest();
            inValue.Body = new HCM401kAlerter.DataClient.GetUserTickerDataRequestBody();
            inValue.Body.userName = userName;
            inValue.Body.password = password;
            HCM401kAlerter.DataClient.GetUserTickerDataResponse retVal = ((HCM401kAlerter.DataClient.HCM401kConnectorSoap)(this)).GetUserTickerData(inValue);
            return retVal.Body.GetUserTickerDataResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        HCM401kAlerter.DataClient.GetDefaultTickerResponse HCM401kAlerter.DataClient.HCM401kConnectorSoap.GetDefaultTicker(HCM401kAlerter.DataClient.GetDefaultTickerRequest request) {
            return base.Channel.GetDefaultTicker(request);
        }
        
        public string GetDefaultTicker() {
            HCM401kAlerter.DataClient.GetDefaultTickerRequest inValue = new HCM401kAlerter.DataClient.GetDefaultTickerRequest();
            inValue.Body = new HCM401kAlerter.DataClient.GetDefaultTickerRequestBody();
            HCM401kAlerter.DataClient.GetDefaultTickerResponse retVal = ((HCM401kAlerter.DataClient.HCM401kConnectorSoap)(this)).GetDefaultTicker(inValue);
            return retVal.Body.GetDefaultTickerResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        HCM401kAlerter.DataClient.GetAvailableTickersResponse HCM401kAlerter.DataClient.HCM401kConnectorSoap.GetAvailableTickers(HCM401kAlerter.DataClient.GetAvailableTickersRequest request) {
            return base.Channel.GetAvailableTickers(request);
        }
        
        public HCM401kAlerter.DataClient.ArrayOfString GetAvailableTickers() {
            HCM401kAlerter.DataClient.GetAvailableTickersRequest inValue = new HCM401kAlerter.DataClient.GetAvailableTickersRequest();
            inValue.Body = new HCM401kAlerter.DataClient.GetAvailableTickersRequestBody();
            HCM401kAlerter.DataClient.GetAvailableTickersResponse retVal = ((HCM401kAlerter.DataClient.HCM401kConnectorSoap)(this)).GetAvailableTickers(inValue);
            return retVal.Body.GetAvailableTickersResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        HCM401kAlerter.DataClient.GetHistoricalDataXResponse HCM401kAlerter.DataClient.HCM401kConnectorSoap.GetHistoricalDataX(HCM401kAlerter.DataClient.GetHistoricalDataXRequest request) {
            return base.Channel.GetHistoricalDataX(request);
        }
        
        public HCM401kAlerter.DataClient.BarInfo GetHistoricalDataX(HCM401kAlerter.DataClient.HistoryRequest token) {
            HCM401kAlerter.DataClient.GetHistoricalDataXRequest inValue = new HCM401kAlerter.DataClient.GetHistoricalDataXRequest();
            inValue.Body = new HCM401kAlerter.DataClient.GetHistoricalDataXRequestBody();
            inValue.Body.token = token;
            HCM401kAlerter.DataClient.GetHistoricalDataXResponse retVal = ((HCM401kAlerter.DataClient.HCM401kConnectorSoap)(this)).GetHistoricalDataX(inValue);
            return retVal.Body.GetHistoricalDataXResult;
        }
    }
}
