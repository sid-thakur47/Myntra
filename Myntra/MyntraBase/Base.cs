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
using System;
using System.Configuration;

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
        public static ExtentReports extent = ExtentReport.ReportManager.GetInstance();
        public static ExtentTest test;

        /// <summary>
        /// Initializes chrome driver once
        /// </summary>
        [OneTimeSetUp]
        public void Initilize()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.myntra.com/login/password";
        }

        /// <summary>
        /// Takes screenshot and generate report of each test
        /// </summary>
        [TearDown]
        public void Close()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                string path = Utility.TakeScreenshot(driver, TestContext.CurrentContext.Test.Name + TestStatus.Failed);
                test.Log(Status.Fail, "Test Failed");
                test.AddScreenCaptureFromPath(path);
                test.Fail(MarkupHelper.CreateLabel(TestContext.CurrentContext.Test.Name, ExtentColor.Red));
            }
            else if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
            {
                string path = Utility.TakeScreenshot(driver, TestContext.CurrentContext.Test.Name + TestStatus.Passed);
                test.Log(Status.Pass, "Test Sucessful");
                test.AddScreenCaptureFromPath(path);
                test.Pass(MarkupHelper.CreateLabel(TestContext.CurrentContext.Test.Name, ExtentColor.Green));
            }
            extent.Flush();
        }
    }
}