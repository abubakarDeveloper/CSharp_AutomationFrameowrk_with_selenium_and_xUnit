using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Selenium_Framework.util;
namespace Selenium_Framework.pages
{
    class GettingStarted : Utils
    {
        private IWebDriver driver = null;
        private By pageImageClass = By.ClassName("title-highlights");
        private By backToTop = By.CssSelector(".back-to-top-a");
        private By legalLink = By.LinkText("Legal");
        public GettingStarted(IWebDriver d)
        {
            driver = d;
        }
        public IWebElement getElement(By locator)
        {
            return driver.FindElement(locator);
        }
        public bool isFeaturePageLoaded()
        {
            return true;
        }
        public void clickLegalLink()
        {
            clickElement(getElement(legalLink));
        }
        public void clickBackToTop()
        {
           clickElement(getElement(legalLink));
        }
    }
}
