using System;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Diagnostics;
using System.Threading;
using Xunit;

namespace Selenium_Framework.util
{
    public class Utils : Constants
    {
        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }

        public static void wait() {
            Thread.Sleep(5000);
        }

        public static IWebElement getElement(IWebDriver driver, By locator) {
           return driver.FindElement(locator);
        }
        public static void clickElement(IWebElement element)
        {
            wait();
            element.Click();
        }
        public static void sendKeys(IWebElement element, string value)
        {
            wait();
            ClearElement(element);
            element.SendKeys(value);
        }

        public static void ClearElement(IWebElement element)
        {
            wait();
            element.Clear();
        }


        public static void scrollToElement(IWebDriver driver, IWebElement element)
        {
            wait();
            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;
            javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public void verifyEquals(Object expected, Object actual, string message)
        {
            try
            {
                Assert.Equal(expected, actual);
                print($"Expected : {expected} Actual {actual} {message}");
            }
            catch (Exception e) {
                print($"Failed : {message} Exception : {e.Message}");
            }
        }

        public void verifyTrue(bool value, string message)
        {
            try
            {
                Assert.True(value, message);
            }
            catch (Exception e)
            {
                print($"Failed : {message} Exception : {e.Message}" );
            }
        }

        public static void print(string message) {
            Console.WriteLine(message);
        }

        public static string getScreenShotPath() {
            return Constants.SCREENSHOT_PATH + "ScreenShot_" + GetTimestamp(DateTime.Now) + ".jpeg";
        }

    }
}
