using OpenQA.Selenium;

namespace SeleniumFrameWorkDesign.Base
{
    public static class DriverContext
    {
        public static IWebDriver Driver { get; set; }

        public static Browser Browser { get; set; }
    }
}