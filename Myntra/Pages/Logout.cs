//-----------------------------------------------------------------------
// <copyright file="Logout.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace Myntra.Pages
{
    /// <summary>
    /// Stores all web elements of logout page
    /// </summary>
    public class Logout
    {
        public IWebDriver driver;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logout"/> class
        /// </summary>
        /// <param name="driver">to control browser</param>
        public Logout(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Web elements
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//a[@class='linkClean']//*[local-name()='svg']")]
        public IWebElement home;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Profile')]")]
        public IWebElement profile;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Logout')]")]
        public IWebElement logout;

        [FindsBy(How = How.XPath, Using = "//div[@class='desktop-getUserInLinks desktop-getInLinks']")]
        public IWebElement logoutvalidation; 

        /// <summary>
        /// Logout from myntra application
        /// </summary>
        public void LogoutMyntra()
        {
            home.Click();
            profile.Click();
            Thread.Sleep(1000);
            logout.Click();
            Thread.Sleep(1000);
            profile.Click();
            Thread.Sleep(5000);
        }

        /// <summary>
        /// Validate after logout 
        /// </summary>
        /// <returns></returns>
        public IWebElement Validation()
        {
            return logoutvalidation;
        }
    }
}