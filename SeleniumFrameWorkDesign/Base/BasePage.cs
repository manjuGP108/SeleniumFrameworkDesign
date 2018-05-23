using System;

namespace SeleniumFrameWorkDesign.Base
{
    public class BasePage : Base
    {
        public BasePage()
        {
            _driver = DriverContext.Driver;
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(300);
        }
    }
}