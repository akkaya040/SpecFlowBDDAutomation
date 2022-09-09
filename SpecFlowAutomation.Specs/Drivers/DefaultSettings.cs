using System.Collections.Generic;
using System.Net;

namespace SpecFlowAutomation.Specs.Drivers
{
    public class DefaultSettings
    {
        public static readonly string HOSTNAME = Dns.GetHostName();

        //Driver Wait Timeouts
        public static readonly int DEFAULT_WEBDRIVER_WAIT = 30; //sec
        public static readonly int DEFAULT_PAGELOAD_WAIT = 30; //sec

        /// <summary>
        /// Browser Types
        /// Browser.Firefox
        /// Browser.Chrome
        /// Browser.Edge
        /// 
        /// Browser.Random : Return randomly browser which is given above.
        /// </summary>
        public static readonly Browsers BROWSER_TYPE = Browsers.Chrome;

        public static bool IS_BROWSER_HEADLESS = false;

        //Environment Details
        public static readonly string ENV_URL = "https://www.saucedemo.com/";
        public static readonly string ENV_URL_DEV = "https://www.saucedemo.com/";
        public static readonly string ENV_URL_QA = "https://www.saucedemo.com/";
        public static readonly string ENV_URL_LIVE = "https://www.saucedemo.com/";
        public static readonly string ENV_LANG = "";

        //Global Data Array
        public static Dictionary<string, string> GLOBALS = new Dictionary<string, string>() { };

        //Database Connection String
        public static readonly string DB_TEST = "connectionStringAsOurNeed";
    }
}