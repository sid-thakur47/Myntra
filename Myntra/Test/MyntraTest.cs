using Myntra.MyntraBase;
using Myntra.Pages;
using NUnit.Framework;
using System.Linq.Expressions;

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
            Assert.AreEqual(menSectionTitle, driver.Title);
        }

        [Test, Order(3)]
        public void SelectShirtTest()
        {
            Shirt shirt = new Shirt(driver);
            shirt.SelectShirt();
            Assert.AreEqual(shirtSectionTitle, driver.Title);
        }

        [Test, Order(4)]
        public void LogoutTest()
        {
            Login login = new Login(driver);
            login.Logout();
            Assert.IsTrue(login.Validation().Displayed);
        }

        [OneTimeTearDown]
        public void QuitBrowser()
        {
            driver.Quit();
        }
    }
}
