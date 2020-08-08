//-----------------------------------------------------------------------
// <copyright file="Myntra.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using Myntra.MyntraBase;
using Myntra.Pages;
using Myntra.Utils;
using NUnit.Framework;
using System;
using static Myntra.Utils.Utility;

namespace Myntra.Test
{
    /// <summary>
    /// Test cases
    /// </summary>
    [TestFixture]
    [Parallelizable]
    public class MyntraTest : Base
    {

        /// <summary>
        /// Login to myntra account
        /// </summary>
        [Test,Order(1)]
        public void LoginTest()
        {
            Login login = new Login(driver);
            login.MyntraLogin();
            Assert.AreEqual(loginTitle, driver.Title);
        }

        /// <summary>
        /// Navigate to men's section
        /// </summary>
        [Test, Order(2)]
        public void MensPageTest()
        {
            MenSection order = new MenSection(driver);
            order.MensSection();
            Assert.AreEqual(mensTitle, driver.Title);
        }

        /// <summary>
        /// Select shirt
        /// </summary>
       [Test, Order(3)]
        public void SelectProductTest()
        {
            Product product = new Product(driver);
            product.SelectProduct(3);
        }

        /// <summary>
        /// add shirt to shopping bag
        /// </summary>
       [Test,Order(4)]
       public void AddingProductToShoppingBagTest()
       {
           ShoppingBag shop = new ShoppingBag(driver);
           shop.AddToBag();
           Assert.AreEqual(shopping, driver.Url);
       }

        /// <summary>
        /// Select address
        /// </summary>
        [Test, Order(5)]
       public void SelectingAddressTest()
       {
           Address addr = new Address(driver);
            addr.SelectAddress();
           Assert.AreEqual(addressTitle, driver.Title);
       }
       
        /// <summary>
        /// Logout from application
        /// </summary>
        [Test, Order(6)]
        public void LogoutTest()
        {
            Logout log = new Logout(driver);
            log.LogoutMyntra();
            Assert.IsTrue(log.Validation().Displayed);
        }

        /// <summary>
        /// Close the browser
        /// </summary>
        [OneTimeTearDown]
        public void QuitBrowser()
        {
            driver.Quit();
            //Utility.SendEmail();
        }
    }
}
