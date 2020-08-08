//-----------------------------------------------------------------------
// <copyright file="MyntraBase.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using Myntra.Utils;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Configuration;
using System.Threading;
using static Myntra.Utils.Utility;

namespace Myntra.MyntraBase
{
    /// <summary>
    /// Initialization of test classes
    /// </summary>
    [TestFixture]
    public class Base
    {
        public IWebDriver driver;
        public string loginTitle = ConfigurationManager.AppSettings["login"];
        public string mensTitle = ConfigurationManager.AppSettings["menSection"];
        public string shirtTitle = ConfigurationManager.AppSettings["shirt"];
        public string addressTitle = ConfigurationManager.AppSettings["address"];
        public string shopping = ConfigurationManager.AppSettings["shopping"];
        public string sale = ConfigurationManager.AppSettings["sale"];
        public static ExtentReports extent = ExtentReport.ReportManager.GetInstance();
        public static ExtentTest test;

        /// <summary>
        /// Initializes chrome driver
        /// </summary>
        [OneTimeSetUp]
        public void Initilize()
        {
            ChooseBrowser();
        }

        private IWebDriver ChooseBrowser()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-notifications","--start-maximized");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "https://www.myntra.com/login/password";
            return driver;
        }

        /// <summary>
        /// Takes screenshot and generate report of each test
        /// </summary>
        [TearDown]
        public void Close()
        {
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
                {
                    string path = Utility.TakeScreenshot(driver, TestContext.CurrentContext.Test.Name);
                    test.Log(Status.Fail, "Test Failed");
                    test.AddScreenCaptureFromPath(path);
                    test.Fail(MarkupHelper.CreateLabel(TestContext.CurrentContext.Test.Name, ExtentColor.Red));
                }
                else if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
                {
                    test.Log(Status.Pass, "Test Sucessful");
                    test.Pass(MarkupHelper.CreateLabel(TestContext.CurrentContext.Test.Name, ExtentColor.Green));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            Thread.Sleep(5000);
            extent.Flush();
        }
    }
}