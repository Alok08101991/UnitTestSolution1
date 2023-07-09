using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace UnitTestProject1.Framework
{
    class DriverHelper
    {
        public IWebDriver InitializeDriver(IWebDriver driver)
        {
            //switch(KeyFunctions.GetConfigData("Browser").ToLower())
            string browser = "chrome";
            switch(browser)
            {
                case "chrome":
                    var chromeOpt = new ChromeOptions();
                    //chromeOpt.("useAutomationExtension", false);
                    string path = KeyFunctions.strProjectDir + "\\Drivers\\";
                    driver = new ChromeDriver(Path.Combine(KeyFunctions.strProjectDir, "Drivers"), chromeOpt);
                    break;

                case "ie":
                    var ieoptions = new InternetExplorerOptions();
                    ieoptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    ieoptions.RequireWindowFocus = true;
                    ieoptions.EnsureCleanSession = true;
                   //ieoptions.AddAdditionalCapability(CapabilityType.AcceptSslCertificates, true);                    
                    driver = new InternetExplorerDriver(Path.Combine(KeyFunctions.strProjectDir, "Drivers"), ieoptions);
                    break;

                
                default:
                    driver = new ChromeDriver(new ChromeOptions { Proxy = null });
                    break;
            }
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(45));
            return driver;
        }
    }
}
