using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Myntra.Pages
{
    public class MenSection
    {
        public  IWebDriver driver;
        

        public MenSection(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[@class='desktop-main'][contains(text(),'Men')]")]
        public IWebElement men;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Topwear')]")]
        public IWebElement topWear;

        public void SelectProduct()
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(men).Build().Perform();
            Thread.Sleep(5000);
            topWear.Click();
            Thread.Sleep(1000);
        }
    }
}
