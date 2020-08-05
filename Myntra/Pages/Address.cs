//-----------------------------------------------------------------------
// <copyright file="Address.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace Myntra.Pages
{
    /// <summary>
    /// Stores all web elements of address page
    /// </summary>
    public class Address
    {
        public IWebDriver driver;

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class
        /// </summary>
        /// <param name="driver">to control browser</param>
        public Address(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Web elements
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//div[@id='placeOrderButton']")]
        public IWebElement continueButton;

        /// <summary>
        /// Select default address
        /// </summary>
        public void SelectAddress()
        {
            continueButton.Click();
            Thread.Sleep(5000);
        }
    }
}