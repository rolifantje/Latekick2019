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
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace Latekick.BLL.latekick.com {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Data;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3062.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="Latekick2Soap", Namespace="http://tempuri.org/")]
    public partial class Latekick2 : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetRaceDetailsOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetProjectedRatingsOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetHistoricalRatingsOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetWorkoutsOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Latekick2() {
            this.Url = global::Latekick.BLL.Properties.Settings.Default.Latekick_BLL_latekick_com_Latekick2;
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
        public event GetRaceDetailsCompletedEventHandler GetRaceDetailsCompleted;
        
        /// <remarks/>
        public event GetProjectedRatingsCompletedEventHandler GetProjectedRatingsCompleted;
        
        /// <remarks/>
        public event GetHistoricalRatingsCompletedEventHandler GetHistoricalRatingsCompleted;
        
        /// <remarks/>
        public event GetWorkoutsCompletedEventHandler GetWorkoutsCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetRaceDetails", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable GetRaceDetails(System.DateTime racedate, string coursecode, int racenumber) {
            object[] results = this.Invoke("GetRaceDetails", new object[] {
                        racedate,
                        coursecode,
                        racenumber});
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public void GetRaceDetailsAsync(System.DateTime racedate, string coursecode, int racenumber) {
            this.GetRaceDetailsAsync(racedate, coursecode, racenumber, null);
        }
        
        /// <remarks/>
        public void GetRaceDetailsAsync(System.DateTime racedate, string coursecode, int racenumber, object userState) {
            if ((this.GetRaceDetailsOperationCompleted == null)) {
                this.GetRaceDetailsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetRaceDetailsOperationCompleted);
            }
            this.InvokeAsync("GetRaceDetails", new object[] {
                        racedate,
                        coursecode,
                        racenumber}, this.GetRaceDetailsOperationCompleted, userState);
        }
        
        private void OnGetRaceDetailsOperationCompleted(object arg) {
            if ((this.GetRaceDetailsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetRaceDetailsCompleted(this, new GetRaceDetailsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetProjectedRatings", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable GetProjectedRatings(System.DateTime racedate, string coursecode, int racenumber, string horsename) {
            object[] results = this.Invoke("GetProjectedRatings", new object[] {
                        racedate,
                        coursecode,
                        racenumber,
                        horsename});
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public void GetProjectedRatingsAsync(System.DateTime racedate, string coursecode, int racenumber, string horsename) {
            this.GetProjectedRatingsAsync(racedate, coursecode, racenumber, horsename, null);
        }
        
        /// <remarks/>
        public void GetProjectedRatingsAsync(System.DateTime racedate, string coursecode, int racenumber, string horsename, object userState) {
            if ((this.GetProjectedRatingsOperationCompleted == null)) {
                this.GetProjectedRatingsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetProjectedRatingsOperationCompleted);
            }
            this.InvokeAsync("GetProjectedRatings", new object[] {
                        racedate,
                        coursecode,
                        racenumber,
                        horsename}, this.GetProjectedRatingsOperationCompleted, userState);
        }
        
        private void OnGetProjectedRatingsOperationCompleted(object arg) {
            if ((this.GetProjectedRatingsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetProjectedRatingsCompleted(this, new GetProjectedRatingsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetHistoricalRatings", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable GetHistoricalRatings(System.DateTime racedate, string horsename) {
            object[] results = this.Invoke("GetHistoricalRatings", new object[] {
                        racedate,
                        horsename});
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public void GetHistoricalRatingsAsync(System.DateTime racedate, string horsename) {
            this.GetHistoricalRatingsAsync(racedate, horsename, null);
        }
        
        /// <remarks/>
        public void GetHistoricalRatingsAsync(System.DateTime racedate, string horsename, object userState) {
            if ((this.GetHistoricalRatingsOperationCompleted == null)) {
                this.GetHistoricalRatingsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetHistoricalRatingsOperationCompleted);
            }
            this.InvokeAsync("GetHistoricalRatings", new object[] {
                        racedate,
                        horsename}, this.GetHistoricalRatingsOperationCompleted, userState);
        }
        
        private void OnGetHistoricalRatingsOperationCompleted(object arg) {
            if ((this.GetHistoricalRatingsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetHistoricalRatingsCompleted(this, new GetHistoricalRatingsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetWorkouts", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable GetWorkouts(System.DateTime racedate, string horsename) {
            object[] results = this.Invoke("GetWorkouts", new object[] {
                        racedate,
                        horsename});
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public void GetWorkoutsAsync(System.DateTime racedate, string horsename) {
            this.GetWorkoutsAsync(racedate, horsename, null);
        }
        
        /// <remarks/>
        public void GetWorkoutsAsync(System.DateTime racedate, string horsename, object userState) {
            if ((this.GetWorkoutsOperationCompleted == null)) {
                this.GetWorkoutsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetWorkoutsOperationCompleted);
            }
            this.InvokeAsync("GetWorkouts", new object[] {
                        racedate,
                        horsename}, this.GetWorkoutsOperationCompleted, userState);
        }
        
        private void OnGetWorkoutsOperationCompleted(object arg) {
            if ((this.GetWorkoutsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetWorkoutsCompleted(this, new GetWorkoutsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3062.0")]
    public delegate void GetRaceDetailsCompletedEventHandler(object sender, GetRaceDetailsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3062.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetRaceDetailsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetRaceDetailsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataTable Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataTable)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3062.0")]
    public delegate void GetProjectedRatingsCompletedEventHandler(object sender, GetProjectedRatingsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3062.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetProjectedRatingsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetProjectedRatingsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataTable Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataTable)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3062.0")]
    public delegate void GetHistoricalRatingsCompletedEventHandler(object sender, GetHistoricalRatingsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3062.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetHistoricalRatingsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetHistoricalRatingsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataTable Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataTable)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3062.0")]
    public delegate void GetWorkoutsCompletedEventHandler(object sender, GetWorkoutsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3062.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetWorkoutsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetWorkoutsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataTable Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataTable)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591