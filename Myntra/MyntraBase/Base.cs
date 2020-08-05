using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Configuration;

namespace Myntra.MyntraBase
{
    public class Base
    {
        public IWebDriver driver;
        public string loginTitle = ConfigurationManager.AppSettings["login"];
        public string mensTitle = ConfigurationManager.AppSettings["menSection"];
        public string shirtTitle = ConfigurationManager.AppSettings["shirt"];
        public string addressTitle = ConfigurationManager.AppSettings["address"];
        public string shopping = ConfigurationManager.AppSettings["shopping"];

        [OneTimeSetUp]
        public void Initilize()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.myntra.com/login/password";
        }
    }
}
