using OpenQA.Selenium;
using Selenium_Framework.BaseClass;
using Selenium_Framework.pages;
using System;
using System.Collections.Generic;
using Xunit;

namespace Selenium_Framework.Tests
{
    public class OpenWebPage : Base
    {
        private IWebDriver driver = null;
        private string keywordToSearch = "javatpoint tutorials";
        private Home home = null;
        private String tempSrc = "";

        [Fact]
        [Trait("Category", "Smoke")]
        public void LoadApplicationPage()
        {
            List<string> list = new List<string>();
            try
            {
                driver = initTest();
                list.Add("Initiate driver");
                //create the reference for the browser
                Console.Write("test case started ");

                //gettingStarted = new GettingStarted(driver);
                home = new Home(driver);

                home.openHome(BASE_URL);
                list.Add($"Navigate to url : {BASE_URL}");
                list.Add(captureScreenshot(driver));

                string pageTitle = driver.Title;
                verifyEquals("Google", pageTitle, "Title matched");
                home.enterKeysToSearch(keywordToSearch);
                list.Add($"Entered keywords to search  : {keywordToSearch}");

                home.clickSearchButton();
                list.Add("Clicked search button");
                list.Add(captureScreenshot(driver));
            }
            catch (Exception e)
            {
                print("Failed : " + e.Message);
                list.Add("Failed : " + e.Message);
                list.Add(captureScreenshot(driver));
            }
            finally
            {
                closeBrowser(driver);
                AddTest_IntoReport("LoadApplicationPage", list, driver);
                if (driver != null)
                {
                    quitBrowser(driver);
                }
            }
        }
    }
}