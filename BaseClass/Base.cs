using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium_Framework.util;
using System;
using System.Collections.Generic;
using System.IO;

namespace Selenium_Framework.BaseClass
{
    public class Base : Utils
    {
        private IWebDriver baseDriver = null;
        public static ExtentReports extent = ExtentManager.createInstance(EXTENTREPORT_PATH);

        public void extentEnd()
        {
            extent.Flush();
        }

        public IWebDriver initTest()
        {
            print("In Chorme initializer");
            baseDriver = new ChromeDriver(DRIVER_PATH);
            print("ChromeDriver initialized");
            return baseDriver;
        }

        public void closeBrowser(IWebDriver driver)
        {
            driver.Close();
        }

        public void quitBrowser(IWebDriver driver)
        {
            extentEnd();
            driver.Quit();
        }

        /*public void captureScreenshot(IWebDriver driver)
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshot = ss.AsBase64EncodedString;
            byte[] screenshotAsByteArray = ss.AsByteArray;
            ss.SaveAsFile(Constants.SCREENSHOT_PATH + "Automation_" + GetTimestamp(DateTime.Now) + ".jpeg", OpenQA.Selenium.ScreenshotImageFormat.Jpeg);
        }*/

        public static string captureScreenshot(IWebDriver driver)
        {
            string path = getScreenShotPath();
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshot = ss.AsBase64EncodedString;
            byte[] screenshotAsByteArray = ss.AsByteArray;
            ss.SaveAsFile(path, OpenQA.Selenium.ScreenshotImageFormat.Jpeg);
            return path;
        }

        public static void AddTest_IntoReport(String TestName, List<string> test_steps, IWebDriver localDriver)
        {
            ExtentTest test = extent.CreateTest(TestName).Info("Test Started");

            foreach (var steps in test_steps)
            {
                if (steps.Contains("Failed") || steps.Contains("Assertion"))
                {
                    if (steps.ToLower().Contains("screenshot"))
                    {
                        print("Name" + steps);
                        try
                        {
                            test.Log(Status.Fail, "<b>" + "<font color=" + "black>" + "Screenshot" + "</font>" + "</b>",
                                    MediaEntityBuilder.CreateScreenCaptureFromPath(steps).Build());
                        }
                        catch (IOException e)
                        {
                            print(TestName + e.Message);
                        }
                    }
                    else
                    {
                        test.Log(Status.Fail, steps);
                    }
                }
                else
                {
                    if (steps.ToLower().Contains("screenshot"))
                    {
                        print("Name" + steps);
                        try
                        {
                            test.Log(Status.Pass, "<b>" + "<font color=" + "black>" + "Screenshot" + "</font>" + "</b>",
                                    MediaEntityBuilder.CreateScreenCaptureFromPath(steps).Build());
                        }
                        catch (IOException e)
                        {
                            // TODO Auto-generated catch block
                            print(TestName + e.Message);
                        }
                    }
                    else
                    {
                        test.Log(Status.Pass, steps);
                    }
                }
            }

            test_steps.Clear();
        }
    }
}