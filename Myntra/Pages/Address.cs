using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Myntra.Pages
{
    public class Address
    {
        public IWebDriver driver;

        public Address(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@id='placeOrderButton']")]
        public IWebElement continueButton;

        public void SelectAddress()
        {
            continueButton.Click();
        }
    }
}
