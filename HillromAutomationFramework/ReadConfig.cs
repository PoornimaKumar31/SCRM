using System;
using System.Collections.Generic;
using System.Text;

namespace HillromAutomationFramework
{
    public class ReadConfig
    {
        //Inputs
        //Admin with roll up page
        public string EmailIDAdminWithRollUp { get; set; }
        public string PasswordAdminWithRollUp { get; set; }
        //Admin without roll up page
        public string EmailAdminWithoutRollUp { get; set; }
        public string PasswordAdminWithoutRollUp { get; set; }
        //Standard User without roll up
        public string EmailStandardWithoutRollUp { get; set; }
        public string PasswordStandardWithoutRollUp { get; set; }
        //Invalid Credentials
        public string InvalidEmailID { get; set; }
        public string InvalidPassword { get; set; }
  
    }
}
