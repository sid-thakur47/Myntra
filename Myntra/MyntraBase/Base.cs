﻿//-----------------------------------------------------------------------
// <copyright file="MyntraBase.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using log4net;
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
        public string sale = ConfigurationManager.AppSettings["sale"];
        public static ExtentReports extent = ExtentReport.ReportManager.GetInstance();
        public static ExtentTest test;
        public static readonly ILog log =LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Initializes chrome driver
        /// </summary>
        [OneTimeSetUp]
        public void Initilize()
        {
            ChooseBrowser();
        }

        [SetUp]
        public void StartingLog()
        {
            Console.WriteLine("Check Internet Connection:"+ Utility.IsConnectedToInternet());
            log.Info(TestContext.CurrentContext.Test.Name + " Started");
        }

        private void ChooseBrowser()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-notifications", "--start-maximized");
            driver = new ChromeDriver(options);
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
                    log.Error(TestContext.CurrentContext.Test.Name+ "  Failed");
                    string path = Utility.TakeScreenshot(driver, TestContext.CurrentContext.Test.Name);
                    test.Log(Status.Fail, "Test Failed");
                    test.AddScreenCaptureFromPath(path);
                    test.Fail(MarkupHelper.CreateLabel(TestContext.CurrentContext.Test.Name, ExtentColor.Red));
                }
                else if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
                {
                    log.Info(TestContext.CurrentContext.Test.Name + " Finished");
                    test.Log(Status.Pass, "Test Sucessful");
                    test.Pass(MarkupHelper.CreateLabel(TestContext.CurrentContext.Test.Name, ExtentColor.Green));
                }
            extent.Flush();
        }
    }
}