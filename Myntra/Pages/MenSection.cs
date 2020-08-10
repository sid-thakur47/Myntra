//-----------------------------------------------------------------------
// <copyright file="MenSection.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace Myntra.Pages
{
    /// <summary>
    /// Store all web element of MenSection page
    /// </summary>
    public class MenSection
    {
        public  IWebDriver driver;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenSection"/> class
        /// </summary>
        /// <param name="driver">to control browser</param>
        public MenSection(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Web elements
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//a[@class='desktop-main'][contains(text(),'Men')]")]
        public IWebElement men;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Topwear')]")]
        public IWebElement topWear;

        /// <summary>
        /// Navigate to mens section 
        /// </summary>
        public void MensSection()
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(men).Build().Perform();
            Thread.Sleep(2000);
            topWear.Click();
        }
    }
}