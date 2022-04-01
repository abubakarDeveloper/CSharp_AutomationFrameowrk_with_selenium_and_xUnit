using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Chrome;
using System.Threading;
using AventStack.ExtentReports.Reporter;
using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using SpecFlow.Internal;
using Selenium_Framework.pages;
using NUnit.Framework;
namespace Selenium_Framework
{
    internal class Program
    {
       /* static void Main(string[] args)
        {
            IWebDriver driver = null;
            GettingStarted gettingStarted = null;
            Home home = null;
            Console.Write("test case started ");
            //create the reference for the browser  
            driver = new ChromeDriver(".");
            Console.WriteLine("In Chorme initializer");
            gettingStarted = new GettingStarted(driver);
            home = new Home(driver);

            // navigate to URL  
            driver.Navigate().GoToUrl("https://www.google.com/");
            Thread.Sleep(2000);
            // identify the Google search text box  
            IWebElement ele = driver.FindElement(By.Name("q"));
            //enter the value in the google search text box  
            ele.SendKeys("javatpoint tutorials");
            Thread.Sleep(2000);
            //identify the google search button  
            IWebElement ele1 = driver.FindElement(By.Name("btnK"));
            // click on the Google search button  
            ele1.Click();
            Thread.Sleep(3000);

            home.openHome("https://www.prestashop.com/en");
            *//*Console.WriteLine("App is launched successfully : " + home.isHomePageLoaded());

            home.openHome("https://www.prestashop.com/en");
            home.clickProductMenu();
            home.clickFeatureMenu();
            Console.WriteLine("Clicked on Feature Menu");

            home.openHome("https://www.prestashop.com/en");
            home.clickProductMenu();
            home.clickFeatureMenu();*//*
            gettingStarted.isFeaturePageLoaded().Equals(true);
            gettingStarted.clickLegalLink();
          //  gettingStarted.clickBackToTop().Equals(true);
            Console.WriteLine("Feature Page testing completed");

            //close the browser  
            driver.Close();
        }*/

    }
}
