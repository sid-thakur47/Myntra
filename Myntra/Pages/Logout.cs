using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace Myntra.Pages
{
    public class Logout
    {
        public IWebDriver driver;

        public Logout(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[@class='linkClean']//*[local-name()='svg']")]
        public IWebElement home;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Profile')]")]
        public IWebElement profile;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Logout')]")]
        public IWebElement logout;

        [FindsBy(How = How.XPath, Using = "//div[@class='desktop-getUserInLinks desktop-getInLinks']")]
        public IWebElement logoutvalidation; 

        public void LogoutMyntra()
        {
            home.Click();
            profile.Click();
            Thread.Sleep(1000);
            logout.Click();
            Thread.Sleep(1000);
            profile.Click();
            Thread.Sleep(5000);
        }
        public IWebElement Validation()
        {
            return logoutvalidation;
        }
    }
}
