//-----------------------------------------------------------------------
// <copyright file="Shirt.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Myntra.Pages
{
    /// <summary>
    /// Store all elements of shirt page
    /// </summary>
    public class Product
    {
        private IWebDriver driver;

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class
        /// </summary>
        /// <param name="driver">to control browser</param>
        public Product(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Web elements
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Shirts')]")]
        public IWebElement filter;

        [FindsBy(How = How.XPath, Using = "//li[1]//a[1]//div[1]//div[1]//div[1]//div[1]//picture[1]//img[1]")]
        public IWebElement selectProduct;

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'40')]")]
        public IWebElement selectSize;     


        /// <summary>
        /// Apply filter and select shirt
        /// </summary>
        public void SelectProduct(int postion)
        {
            filter.Click();
            Thread.Sleep(5000);
            IList<IWebElement> products = driver.FindElements(By.ClassName("product-base"));
            Thread.Sleep(5000);
            products.ElementAt(postion).Click(); 
            Thread.Sleep(5000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Thread.Sleep(5000);
            selectSize.Click();
        }
    }
}