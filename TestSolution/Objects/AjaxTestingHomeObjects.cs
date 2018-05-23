using OpenQA.Selenium;
using SeleniumFrameWorkDesign.Base;

namespace TestSolution.Objects
{
    public class AjaxTestingHomeObjects : BasePage
    {
        public IWebElement ManListItem => DriverContext.Driver.FindElement(By.XPath(".//*[@id='menu-item-2212']/a"));

        public IWebElement MenWatchesItem => DriverContext.Driver.FindElement(By.XPath(".//*[@id='menu-item-2228']/a"));

        public IWebElement MenWatchesFirstWatch => DriverContext.Driver.FindElement(By.XPath("//*[@id='noo-site']/div[2]/div[2]/div[1]/div/div[1]/div/div[1]/a"));

        public IWebElement FirstWatchAddToCartButton => DriverContext.Driver.FindElement(By.XPath("//*[@id='noo-site']/div[2]/div[2]/div[1]/div/div[1]/div/div[3]/a"));

        public IWebElement ViewCartElement => DriverContext.Driver.FindElement(By.XPath("/html/body/div[2]/div/div[1]/div/div/a[2]"));
    }
}