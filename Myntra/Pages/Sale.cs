using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Myntra.Pages
{
    /// <summary>
    /// Store all web elements of sale page
    /// </summary>
    public class Sale
    {
        public IWebDriver driver;

        /// <summary>
        /// Initializes a new instance of the <see cref="Sale"/> class
        /// </summary>
        /// <param name="driver">to control browser</param>
        public Sale(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Web elements
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//div[3]//div[1]//div[1]//div[1]//div[1]//div[2]//div[1]" +
                                           "//div[1]//div[1]//div[1]//div[1]//a[1]//div[1]//picture[1]//img[1]")]
        public IWebElement men;

        [FindsBy(How = How.XPath, Using = "//div[3]//div[1]//div[1]//div[1]//div[1]//div[3]//div[1]" +
                                             "//div[1]//div[1]//div[1]//div[1]//a[1]//div[1]//picture[1]//img[1]")]
        public IWebElement viewAll;

        public void BuyFromSale()
        {
            men.Click();
            Thread.Sleep(5000);
            viewAll.Click();
            Thread.Sleep(1000);
        }
    }
}
