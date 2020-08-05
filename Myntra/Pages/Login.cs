using Myntra.Reader;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace Myntra.Pages
{
    public class Login
    {
        readonly JsonReader reader = new JsonReader();
        public IWebDriver driver;

        public Login(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='mobileNumberPass']")]
        public IWebElement username;

        [FindsBy(How = How.XPath, Using = "//input[@class='form-control has-feedback']")]
        public IWebElement password;

        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'lg block submitButton')]")]
        public IWebElement loginbutton; 

        public void MyntraLogin()
        {
            username.SendKeys(reader.email);
            Thread.Sleep(5000);
            password.SendKeys(reader.password);
            Thread.Sleep(5000);
            loginbutton.Click();
            Thread.Sleep(5000);
        }
    }
}
