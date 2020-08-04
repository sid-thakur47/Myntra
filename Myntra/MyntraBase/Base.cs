using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Myntra.MyntraBase
{
    public class Base
    {
        public IWebDriver driver;

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
