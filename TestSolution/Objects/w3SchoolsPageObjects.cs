using OpenQA.Selenium;
using SeleniumFrameWorkDesign.Base;

namespace TestSolution.Objects
{
    public class w3SchoolsPageObjects
    {
        private readonly IWebDriver _driver;

        public w3SchoolsPageObjects()
        {
            _driver = DriverContext.Driver;
        }

        public IWebElement Table => _driver.FindElement(By.Id("customers"));
    }
}