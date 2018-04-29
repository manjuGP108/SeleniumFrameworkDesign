using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SeleniumFrameWorkDesign;

namespace TestSolution.Objects
{
    public class w3SchoolsPageObjects
    {
        private readonly RemoteWebDriver _driver;

        public w3SchoolsPageObjects()
        {
            _driver = PropertiesCollection.Driver;
        }

        public IWebElement Table => _driver.FindElementById("customers");
    }
}