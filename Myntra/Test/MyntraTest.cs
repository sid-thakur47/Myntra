using Myntra.MyntraBase;
using Myntra.Pages;
using NUnit.Framework;

namespace Myntra.Test
{
    [TestFixture]
    public class MyntraTest : Base
    {
        [Test,Order(1)]
        public void LoginTest()
        {
            Login login = new Login(driver);
            login.MyntraLogin();
            Assert.AreEqual(loginTitle, driver.Title);
        }

        [Test, Order(2)]
        public void MensPageTest()
        {
            MenSection order = new MenSection(driver);
            order.SelectProduct();
            Assert.AreEqual(mensTitle, driver.Title);
        }

        [Test, Order(3)]
        public void SelectShirtTest()
        {
            Shirt shirt = new Shirt(driver);
            shirt.SelectShirt();
            Assert.AreEqual(shirtTitle, driver.Title);
        }

        [Test,Order(4)]
        public void ShoppingBagTest()
        {
            ShoppingBag shop = new ShoppingBag(driver);
            shop.AddToBag();
            Assert.AreEqual(shopping, driver.Url);
        }

        [Test, Order(5)]
        public void AddressTest()
        {
            Address addr = new Address(driver);
            addr.SelectAddress();
            Assert.AreEqual(addressTitle, driver.Title);
        }

        [Test, Order(6)]
        public void LogoutTest()
        {
            Logout log = new Logout(driver);
            log.LogoutMyntra();
            Assert.IsTrue(log.Validation().Displayed);
        }

        [OneTimeTearDown]
        public void QuitBrowser()
        {
            driver.Quit();
        }
    }
}
