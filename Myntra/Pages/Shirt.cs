using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Linq;
using System.Threading;

namespace Myntra.Pages
{
    public class Shirt
    {
        private IWebDriver driver;
        public Shirt(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Shirts')]")]
        public IWebElement filterShirt;

        [FindsBy(How = How.XPath, Using = "//li[1]//a[1]//div[1]//div[1]//div[1]//div[1]//picture[1]//img[1]")]
        public IWebElement selectShirt;

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'40')]")]
        public IWebElement selectSize;

        public void SelectShirt()
        {
            filterShirt.Click();
            Thread.Sleep(1000);
            selectShirt.Click();
            Thread.Sleep(1000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            selectSize.Click();
        }
    }
}
