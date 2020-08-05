using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace Myntra.Pages
{
    public class ShoppingBag
    {
        public IWebDriver driver;

        public ShoppingBag(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'ADD TO BAG')]")]
        public IWebElement addToBag;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'GO TO BAG')]")]
        public IWebElement goToBag;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'itemComponents-base-quantity')]")]
        public IWebElement quantity;

        [FindsBy(How = How.XPath, Using = "//div[@id='2']")]
        public IWebElement changeQuantitiy;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Place Order')]")]
        public IWebElement placeOrder;

        public void AddToBag()
        {
            addToBag.Click();
            Thread.Sleep(1000);
            goToBag.Click();
            Thread.Sleep(1000);
            quantity.Click();
            Thread.Sleep(1000);
            changeQuantitiy.Click();
            Thread.Sleep(1000);
            placeOrder.Click();
        }
    }

}
