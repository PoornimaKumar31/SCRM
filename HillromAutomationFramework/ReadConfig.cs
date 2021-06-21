using System;
using System.Collections.Generic;
using System.Text;

namespace HillromAutomationFramework
{
    public class ReadConfig
    {
        public string BaseURL { get; set; }

        public string BrowserName { get; set; }

        //Inputs
        public string validEmailID { get; set; }
        public string validPassword { get; set; }
        public string invalidEmailID { get; set; }
        public string invalidPassword { get; set; }
    }
}
