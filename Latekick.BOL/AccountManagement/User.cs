using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Latekick.BOL.AccountManagement
{
    public class User
    {
        #region Variables
        string userName, password, emailAddress, currency;
        double balance;
        bool authenticated;
        #endregion

        #region Properties
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }
        public string Currency
        {
            get { return currency; }
            set { currency = value; }
        }
        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        public bool Authenticated
        {
            get { return authenticated; }
            set { authenticated = value; }
        }
        #endregion

        #region Constructors
        public User() { }
        public User(string username)
        {
            this.userName = username;
        }
        #endregion
    }
}
