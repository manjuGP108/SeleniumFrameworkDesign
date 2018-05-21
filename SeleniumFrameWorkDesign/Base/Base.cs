using System;
using OpenQA.Selenium;

namespace SeleniumFrameWorkDesign.Base
{
    public class Base
    {
        public IWebDriver _driver { get; set; }

        public BasePage CurrentPage { get; set; }

        protected TPage GetInstance<TPage>() where TPage : BasePage, new()
        {
            return (TPage)Activator.CreateInstance(typeof(TPage));
        }

        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage)this;
        }
    }
}