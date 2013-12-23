﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.18052.
// 
#pragma warning disable 1591

namespace RestaurantReservation.WebService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ReservationWebServiceSoap", Namespace="http://tempuri.org/")]
    public partial class ReservationWebService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetRestaurantNameOperationCompleted;
        
        private System.Threading.SendOrPostCallback InsertDetailsOperationCompleted;
        
        private System.Threading.SendOrPostCallback InsertBookingOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetTableNoOperationCompleted;
        
        private System.Threading.SendOrPostCallback CheckTimeOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ReservationWebService() {
            this.Url = "http://pbf93y1.sw.sherwin.com/ReservationWebService/ReservationWebService.asmx";
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event GetRestaurantNameCompletedEventHandler GetRestaurantNameCompleted;
        
        /// <remarks/>
        public event InsertDetailsCompletedEventHandler InsertDetailsCompleted;
        
        /// <remarks/>
        public event InsertBookingCompletedEventHandler InsertBookingCompleted;
        
        /// <remarks/>
        public event GetTableNoCompletedEventHandler GetTableNoCompleted;
        
        /// <remarks/>
        public event CheckTimeCompletedEventHandler CheckTimeCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetRestaurantName", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public List<RestaurantName> GetRestaurantName() {
            object[] results = this.Invoke("GetRestaurantName", new object[0]);
            return ((List<RestaurantName>)(results[0]));
        }
        
        /// <remarks/>
        public void GetRestaurantNameAsync() {
            this.GetRestaurantNameAsync(null);
        }
        
        /// <remarks/>
        public void GetRestaurantNameAsync(object userState) {
            if ((this.GetRestaurantNameOperationCompleted == null)) {
                this.GetRestaurantNameOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetRestaurantNameOperationCompleted);
            }
            this.InvokeAsync("GetRestaurantName", new object[0], this.GetRestaurantNameOperationCompleted, userState);
        }
        
        private void OnGetRestaurantNameOperationCompleted(object arg) {
            if ((this.GetRestaurantNameCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetRestaurantNameCompleted(this, new GetRestaurantNameCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/InsertDetails", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void InsertDetails(string bookname, string phoneno, string email, string bookstart, string bookend, int headcount) {
            this.Invoke("InsertDetails", new object[] {
                        bookname,
                        phoneno,
                        email,
                        bookstart,
                        bookend,
                        headcount});
        }
        
        /// <remarks/>
        public void InsertDetailsAsync(string bookname, string phoneno, string email, string bookstart, string bookend, int headcount) {
            this.InsertDetailsAsync(bookname, phoneno, email, bookstart, bookend, headcount, null);
        }
        
        /// <remarks/>
        public void InsertDetailsAsync(string bookname, string phoneno, string email, string bookstart, string bookend, int headcount, object userState) {
            if ((this.InsertDetailsOperationCompleted == null)) {
                this.InsertDetailsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnInsertDetailsOperationCompleted);
            }
            this.InvokeAsync("InsertDetails", new object[] {
                        bookname,
                        phoneno,
                        email,
                        bookstart,
                        bookend,
                        headcount}, this.InsertDetailsOperationCompleted, userState);
        }
        
        private void OnInsertDetailsOperationCompleted(object arg) {
            if ((this.InsertDetailsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.InsertDetailsCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/InsertBooking", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void InsertBooking(int tableid, System.DateTime confirmdate, string status) {
            this.Invoke("InsertBooking", new object[] {
                        tableid,
                        confirmdate,
                        status});
        }
        
        /// <remarks/>
        public void InsertBookingAsync(int tableid, System.DateTime confirmdate, string status) {
            this.InsertBookingAsync(tableid, confirmdate, status, null);
        }
        
        /// <remarks/>
        public void InsertBookingAsync(int tableid, System.DateTime confirmdate, string status, object userState) {
            if ((this.InsertBookingOperationCompleted == null)) {
                this.InsertBookingOperationCompleted = new System.Threading.SendOrPostCallback(this.OnInsertBookingOperationCompleted);
            }
            this.InvokeAsync("InsertBooking", new object[] {
                        tableid,
                        confirmdate,
                        status}, this.InsertBookingOperationCompleted, userState);
        }
        
        private void OnInsertBookingOperationCompleted(object arg) {
            if ((this.InsertBookingCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.InsertBookingCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetTableNo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public List<TableNo> GetTableNo(int restaurantid, string bookstart, string bookend, int headcount) {
            object[] results = this.Invoke("GetTableNo", new object[] {
                        restaurantid,
                        bookstart,
                        bookend,
                        headcount});
            return ((List<TableNo>)(results[0]));
        }
        
        /// <remarks/>
        public void GetTableNoAsync(int restaurantid, string bookstart, string bookend, int headcount) {
            this.GetTableNoAsync(restaurantid, bookstart, bookend, headcount, null);
        }
        
        /// <remarks/>
        public void GetTableNoAsync(int restaurantid, string bookstart, string bookend, int headcount, object userState) {
            if ((this.GetTableNoOperationCompleted == null)) {
                this.GetTableNoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetTableNoOperationCompleted);
            }
            this.InvokeAsync("GetTableNo", new object[] {
                        restaurantid,
                        bookstart,
                        bookend,
                        headcount}, this.GetTableNoOperationCompleted, userState);
        }
        
        private void OnGetTableNoOperationCompleted(object arg) {
            if ((this.GetTableNoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetTableNoCompleted(this, new GetTableNoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CheckTime", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool CheckTime(int restaurantid, System.DateTime bookstart, System.DateTime bookend) {
            object[] results = this.Invoke("CheckTime", new object[] {
                        restaurantid,
                        bookstart,
                        bookend});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void CheckTimeAsync(int restaurantid, System.DateTime bookstart, System.DateTime bookend) {
            this.CheckTimeAsync(restaurantid, bookstart, bookend, null);
        }
        
        /// <remarks/>
        public void CheckTimeAsync(int restaurantid, System.DateTime bookstart, System.DateTime bookend, object userState) {
            if ((this.CheckTimeOperationCompleted == null)) {
                this.CheckTimeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCheckTimeOperationCompleted);
            }
            this.InvokeAsync("CheckTime", new object[] {
                        restaurantid,
                        bookstart,
                        bookend}, this.CheckTimeOperationCompleted, userState);
        }
        
        private void OnCheckTimeOperationCompleted(object arg) {
            if ((this.CheckTimeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CheckTimeCompleted(this, new CheckTimeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18060")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class RestaurantName {
        
        private int residField;
        
        private string resnameField;
        
        /// <remarks/>
        public int Resid {
            get {
                return this.residField;
            }
            set {
                this.residField = value;
            }
        }
        
        /// <remarks/>
        public string Resname {
            get {
                return this.resnameField;
            }
            set {
                this.resnameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18060")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class TableNo {
        
        private int tableNumField;
        
        private int tableidField;
        
        /// <remarks/>
        public int TableNum {
            get {
                return this.tableNumField;
            }
            set {
                this.tableNumField = value;
            }
        }
        
        /// <remarks/>
        public int Tableid {
            get {
                return this.tableidField;
            }
            set {
                this.tableidField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void GetRestaurantNameCompletedEventHandler(object sender, GetRestaurantNameCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetRestaurantNameCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetRestaurantNameCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public RestaurantName[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((RestaurantName[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void InsertDetailsCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void InsertBookingCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void GetTableNoCompletedEventHandler(object sender, GetTableNoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetTableNoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetTableNoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public TableNo[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((TableNo[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void CheckTimeCompletedEventHandler(object sender, CheckTimeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CheckTimeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CheckTimeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591