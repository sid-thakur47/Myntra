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
        public string menSectionTitle = ConfigurationManager.AppSettings["menSection"];
        public string shirtSectionTitle = ConfigurationManager.AppSettings["shirt"];

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
