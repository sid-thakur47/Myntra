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
            Assert.AreEqual("Online Shopping for Women, Men, Kids Fashion & Lifestyle - Myntra", driver.Title);
        }

        [Test,Order(2)]
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
