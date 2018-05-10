using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumFrameWorkDesign.Base
{
    public class Base
    {
        public IWebDriver _driver { get; set; }

        public BasePage CurrentPage { get; set; }

        protected TPage GetInstance<TPage>() where TPage : BasePage, new()
        {
            var pageInstance = new TPage
            {
                _driver = DriverContext.Driver
            };

            return pageInstance;
        }

        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage)this;
        }
    }
}