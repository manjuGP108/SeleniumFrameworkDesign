﻿using OpenQA.Selenium;

namespace SeleniumFrameWorkDesign.Base
{
    public class Browser
    {
        private readonly IWebDriver _driver;

        public Browser(IWebDriver driver)
        {
            _driver = driver;
        }

        public BrowserType Type { get; set; }

        public void GoToUrl(string url)
        {
            DriverContext.Driver.Url = url;
        }
    }

    public enum BrowserType
    {
        InternetExplorer,
        Chrome,
        FireFox,
        Opera
    }

    public enum Applications
    {
        ToolsQA,
        AjaXTest
    }
}