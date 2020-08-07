//-----------------------------------------------------------------------
// <copyright file="ShoppingBag.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace Myntra.Pages
{
    /// <summary>
    /// Store all web elements of Shoppingbag page 
    /// </summary>
    public class ShoppingBag
    {
        public IWebDriver driver;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingBag"/> class
        /// </summary>
        /// <param name="driver">to control browser</param>
        public ShoppingBag(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Web elements
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'ADD TO BAG')]")]
        public IWebElement addToBag;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'GO TO BAG')]")]
        public IWebElement goToBag;

        [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/div/div/div/div/div/div[1]/div[4]/div/div/div/div/div[2]/div/div[4]/div[1]/div")]
        public IWebElement dPrice;

        [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/div/div/div/div/div/div[1]/div[4]/div/div/div/div/div[2]/div/div[4]/div[2]/span[1]/span")]
        public IWebElement oPrice;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Place Order')]")]
        public IWebElement placeOrder;

        /// <summary>
        /// Add shirt to bag
        /// </summary>
        public void AddToBag()
        {
            addToBag.Click();
            goToBag.Click();
            placeOrder.Click();
        }

        public void AddToBagWhenOffer()
        {
            addToBag.Click();
            Thread.Sleep(1000);
            goToBag.Click();
            Thread.Sleep(10000);

            string discount = dPrice.Text;
            string discountFilter = Regex.Replace(discount, "[^0-9]", "");
            string d = string.Join("", discountFilter.ToCharArray().Where(Char.IsDigit));

            string orignal = oPrice.Text;
            string orignalFilter = Regex.Replace(orignal, "[^0-9]", "");
            string o = string.Join("", orignalFilter.ToCharArray().Where(Char.IsDigit));

            int orignalPrice = int.Parse(o);
            Console.WriteLine("OrignalPrice:" + orignalPrice);

            int discountPrice = int.Parse(d);
            Console.WriteLine("discount:" + discountPrice);

            if (discountPrice < orignalPrice)
            {
                placeOrder.Click();
            }
        }
    }
}