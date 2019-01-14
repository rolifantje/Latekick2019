using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Profile;

namespace Latekick.BOL.AccountManagement
{


    public class ProfileCommon : System.Web.Profile.ProfileBase
    {

        public virtual System.DateTime Subscription_Start
        {
            get
            {
                return ((System.DateTime)(this.GetPropertyValue("Subscription_Start")));
            }
            set
            {
                this.SetPropertyValue("Subscription_Start", value);
            }
        }

        public virtual string Currency
        {
            get
            {
                return ((string)(this.GetPropertyValue("Currency")));
            }
            set
            {
                this.SetPropertyValue("Currency", value);
            }
        }

        public virtual int Subscription_Type
        {
            get
            {
                return ((int)(this.GetPropertyValue("Subscription_Type")));
            }
            set
            {
                this.SetPropertyValue("Subscription_Type", value);
            }
        }

        public virtual System.DateTime Subscription_LastChange
        {
            get
            {
                return ((System.DateTime)(this.GetPropertyValue("Subscription_LastChange")));
            }
            set
            {
                this.SetPropertyValue("Subscription_LastChange", value);
            }
        }

        public virtual System.DateTime Subscription_End
        {
            get
            {
                return ((System.DateTime)(this.GetPropertyValue("Subscription_End")));
            }
            set
            {
                this.SetPropertyValue("Subscription_End", value);
            }
        }

        public virtual double Balance
        {
            get
            {
                return ((double)(this.GetPropertyValue("Balance")));
            }
            set
            {
                this.SetPropertyValue("Balance", value);
            }
        }

        public virtual ProfileCommon GetProfile(string username)
        {
            return ((ProfileCommon)(ProfileBase.Create(username)));
        }
    }
}
