using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Framework.util
{
    public class ExtentManager
    {
        public static ExtentReports extent = null;
        public static ExtentReports createInstance(String fileName)
        {
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(fileName);

            htmlReporter.LoadConfig(Constants.EXTENTCONFIG_PATH);
            htmlReporter.Config.Theme = Theme.Standard;
            htmlReporter.Config.DocumentTitle = fileName;
            htmlReporter.Config.Encoding = "utf-8";
            htmlReporter.Config.ReportName = fileName;

            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Automation Tester", "Investor tester");
            extent.AddSystemInfo("Organization", "Investor");
            extent.AddSystemInfo("Build no", "1234");

            return extent;
        }
    }
}
