using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Selenium_Framework.BaseClass;
namespace Selenium_Framework.pages
{
    public class Home : Base
    {
        //########## Setup ############
        private IWebDriver driver = null;
        public Home(IWebDriver d)
        {
            this.driver = d;
        }
        //########### Element Definition #############
        private By getprestaShop = By.CssSelector(".popup-link.prestashop-link.primary-link");
        private By productMenuXpath = By.XPath("//*[@id='header-menu']/ul/div[1]/div[1]/a");
        private By featureMenuXpath = By.XPath("//*[@id='more-submenus-column-4093']/ul/li[3]/a");
        private By searchBar = By.Name("q");
        private By btnSearch = By.Name("btnK");
        public IWebElement getElement(By locator)
        {
            return driver.FindElement(locator);
        }
        public void openHome(string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.FullScreen();
            captureScreenshot(driver);
        }

        public void enterKeysToSearch(string value) {
            sendKeys(getElement(searchBar), value);
        }

        public void clickSearchButton()
        {
            clickElement(getElement(btnSearch));
        }


    }
}
