//-----------------------------------------------------------------------
// <copyright file="Shirt.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Linq;
using System.Threading;

namespace Myntra.Pages
{
    /// <summary>
    /// Store all elements of shirt page
    /// </summary>
    public class Shirt
    {
        private IWebDriver driver;

        /// <summary>
        /// Initializes a new instance of the <see cref="Shirt"/> class
        /// </summary>
        /// <param name="driver">to control browser</param>
        public Shirt(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Web elements
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Shirts')]")]
        public IWebElement filterShirt;

        [FindsBy(How = How.XPath, Using = "//li[1]//a[1]//div[1]//div[1]//div[1]//div[1]//picture[1]//img[1]")]
        public IWebElement selectShirt;

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'40')]")]
        public IWebElement selectSize;

        /// <summary>
        /// Apply filter and select shirt
        /// </summary>
        public void SelectShirt()
        {
            filterShirt.Click();
            Thread.Sleep(1000);
            selectShirt.Click();
            Thread.Sleep(1000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            selectSize.Click();
            Thread.Sleep(5000);
        }
    }
}