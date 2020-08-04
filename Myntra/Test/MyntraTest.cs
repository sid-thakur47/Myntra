using Myntra.MyntraBase;
using Myntra.Pages;
using NUnit.Framework;

namespace Myntra.Test
{
    [TestFixture]
    public class MyntraTest : Base
    {

        [Test]
        public void LoginTest()
        {
            Login login = new Login(driver);
            login.MyntraLogin();
            Assert.AreEqual("Online Shopping for Women, Men, Kids Fashion & Lifestyle - Myntra", driver.Title);
        }

        [OneTimeTearDown]
        public void QuitBrowser()
        {
            driver.Quit();
        }
    }
}
