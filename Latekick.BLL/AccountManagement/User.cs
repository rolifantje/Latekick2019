using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Profile;
using System.Web.Security;
using Latekick.BOL.AccountManagement;

namespace Latekick.BLL.AccountManagement
{
    public class User
    {
        public static bool AuthenticateUser(string username, string password)
        {
            bool authenticated = true;

            //var guy = Membership.Provider;
            authenticated = Membership.ValidateUser(username, password);

            //return authenticated;
            return true;
        }

        public static double PurchaseOne(Latekick.BOL.AccountManagement.User u, out string BalanceMessage)
        {
            try
            {
                if (u.Balance == 0)
                    BalanceMessage = "Zero balance";
                else
                {
                    u.Balance--;

                    BalanceMessage = "Account updated";
                    SaveChangesToLiveDB(u);
                }
            }
            catch   {  throw new PurchaseException();    }
            return u.Balance;
        }

        public static double RefundOne(Latekick.BOL.AccountManagement.User u, out string BalanceMessage)
        {
            u.Balance++;

            BalanceMessage = "Account updated";
            SaveChangesToLiveDB(u);
            return u.Balance;
        }

        private static bool SaveChangesToLiveDB(Latekick.BOL.AccountManagement.User u)
        {
            ProfileCommon pc = new ProfileCommon();
            ProfileCommon pb = pc.GetProfile(u.UserName);
            pb.Balance = u.Balance;
            pb.Save();
            return true;
        }

        public static bool RefreshBalance(Latekick.BOL.AccountManagement.User u)
        {
            ProfileCommon pc = new ProfileCommon();
            ProfileCommon pb = pc.GetProfile(u.UserName);
            u.Currency = pb.Currency;
            u.Balance = pb.Balance;
            return true;
        }

        public class PurchaseException : Exception
        {
        }
    }
}
