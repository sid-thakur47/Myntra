using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Net;

namespace Myntra.ExtentReport
{
    public class ReportManager
    {
        private static ExtentReports extent;
        private static ExtentHtmlReporter htmlReporter;

        public static ExtentReports GetInstance()
        {
            if (extent == null)
            {
                string reportPath = @"C:\Users\Shivani\source\repos\Myntra\Myntra\ExtentReport\Report.html";
                htmlReporter = new ExtentHtmlReporter(reportPath);
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
                string hostname = Dns.GetHostName();
                extent.AddSystemInfo("OS", "Windows 10");
                extent.AddSystemInfo("Host Name", hostname);
                extent.AddSystemInfo("Browser", "Chrome");
                extent.AddSystemInfo("Environment", "QA");
            }
            return extent;
        }
    }
}