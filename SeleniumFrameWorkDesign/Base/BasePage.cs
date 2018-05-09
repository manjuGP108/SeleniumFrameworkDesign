using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumFrameWorkDesign.Base
{
    public class BasePage
    {
        public static IWebDriver _driver;
        public BasePage()
        {
            _driver = DriverContext.Driver;
        }
    }
}
