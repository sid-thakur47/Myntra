using Myntra.MyntraBase;
using Myntra.Pages;
using NUnit.Framework;
using static Myntra.Utils.Utility;

namespace Myntra.Test
{
    [TestFixture]
    [Parallelizable]
    public class MyntraSaleTest : Base
    {

        /// <summary>
        /// Login to myntra account 
        /// </summary>
       /* [Test, Order(1)]
        public void LoginTestSale()
        {
            log.Info("Starting login test");
            Login login = new Login(driver);
            login.MyntraLogin();
            Assert.AreEqual(loginTitle, driver.Title);
        }

        [Test, Order(2)]
        public void BuyProductFromSaleTest()
        {
            log.Info("Starting BuyProductFromSale test");
            Sale sal = new Sale(driver);
            sal.BuyFromSale();
            Assert.AreEqual(sale, driver.Title);
        }

        /// <summary>
        /// Select product
        /// </summary>
        [Test, Order(3)]
        public void SelectProductFromSaleTest()
        {
            log.Info("Starting Select Product From Sale test");
            Product product = new Product(driver);
            product.SelectProduct(3);
            //Assert.IsTrue(product.Validation().Displayed);
        }

        /// <summary>
        /// add shirt to shopping bag
        /// </summary>
        [Test, Order(4)]
        public void AddingSaleProductToShoppingBagTest()
        {
            log.Info("Starting Adding Product To ShoppingBag test");
            ShoppingBag shop = new ShoppingBag(driver);
            shop.AddToBagWhenOffer();
            Assert.AreEqual(shopping, driver.Url);
        }

        /// <summary>
        /// Select address
        /// </summary>
        [Test, Order(5)]
        public void AddressTest()
        {
            log.Info("Starting selecting Address test");
            Address addr = new Address(driver);
            addr.SelectAddress();
            Assert.AreEqual(addressTitle, driver.Title);
        }

        /// <summary>
        /// Logout from application
        /// </summary>
        [Test, Order(6)]
        public void LogoutFromSaleTest()
        {
            log.Info("Starting logout test");
            Logout logout = new Logout(driver);
            logout.LogoutMyntra();
            Assert.IsTrue(logout.Validation().Displayed);
        }

        /// <summary>
        /// Close the browser
        /// </summary>
        [OneTimeTearDown]
        public void QuitBrowser()
        {
            driver.Quit();
            log.Info("Browser closed");
        }*/
    }
}
