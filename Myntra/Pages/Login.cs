//-----------------------------------------------------------------------
// <copyright file="Login.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using Myntra.Reader;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace Myntra.Pages
{
    /// <summary>
    /// Stores all web elements of login page
    /// </summary>
    public class Login
    {
        readonly JsonReader reader = new JsonReader();
        public IWebDriver driver;

        /// <summary>
        /// Initializes a new instance of the <see cref="Login"/> class
        /// </summary>
        /// <param name="driver">to control browser</param>
        public Login(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Web elements
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//input[@id='mobileNumberPass']")]
        public IWebElement username;

        [FindsBy(How = How.XPath, Using = "//input[@class='form-control has-feedback']")]
        public IWebElement password;

        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'lg block submitButton')]")]
        public IWebElement loginbutton; 

        /// <summary>
        /// To login into myntra account
        /// </summary>
        public void MyntraLogin()
        {
            username.SendKeys(reader.email);
            password.SendKeys(reader.password);
            loginbutton.Click();
            Thread.Sleep(2000);
        }
    }
}
