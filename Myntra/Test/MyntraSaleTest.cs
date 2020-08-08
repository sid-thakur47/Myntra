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
        [Test, Order(1)]
        public void LoginTest()
        {
            Login login = new Login(driver);
            login.MyntraLogin();
            Assert.AreEqual(loginTitle, driver.Title);
        }

        [Test, Order(2)]
        public void BuyProductFromSaleTest()
        {
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
            Product product = new Product(driver);
            product.SelectProduct(1);
            //Assert.IsTrue(product.Validation().Displayed);
        }

        /// <summary>
        /// add shirt to shopping bag
        /// </summary>
        [Test, Order(4)]
        public void AddingSaleProductToShoppingBagTest()
        {
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
        }
    }
}
