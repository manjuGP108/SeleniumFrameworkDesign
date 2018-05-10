using OpenQA.Selenium;

namespace SeleniumFrameWorkDesign.Base
{
    public class BasePage : Base
    {
        public BasePage()
        {
            _driver = DriverContext.Driver;
        }

    }
}