using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using SeleniumFrameWorkDesign.Config;
using SeleniumFrameWorkDesign.Helpers;

namespace SeleniumFrameWorkDesign.Base
{
    public abstract class TestInitializeHook : Base
    {
        public readonly BrowserType _browser;

        public TestInitializeHook(BrowserType browser)
        {
            _browser = browser;
        }

        public void InitializeSettings()
        {
            // Set all the settings for Framework
            ConfigReader.SetFrameworkSettings();

            // Set a Log file
            LogHelpers.CreateLogFile();

            // Open Browser
            OpenBrowser(_browser);

            // Maximize the Window
            DriverContext.Driver.Manage().Window.Maximize();
        }

        private void OpenBrowser(BrowserType browserType = BrowserType.Chrome)
        {
            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                    DriverContext.Driver = new InternetExplorerDriver();
                    // For initializing Browser. So that we can access the methods in Browser classs such as GoToUrl
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.FireFox:
                    DriverContext.Driver = new FirefoxDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.Chrome:
                    DriverContext.Driver = new ChromeDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
            }
        }

        public void NavigateSite()
        {
            // Set URL
            DriverContext.Browser.GoToUrl(Settings.AUT);
        }
    }
}