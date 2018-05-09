using OpenQA.Selenium;
using SeleniumFrameWorkDesign.Base;

namespace TestSolution.Objects
{
    public class PracticeTableObjects : BasePage
    {
        //public Practice_TableObjects()
        //{
        //    PageFactory.InitElements(DriverContext.Driver, this);
        //}

        //[FindsBy(How = How.XPath, Using = "//*[@id='content']/table")]
        //public IWebElement PracticeTable { get; set; }

        //[FindsBy(How = How.XPath, Using = "//*[@id='content']/table/thead")]
        //public IWebElement PracticeTableHeader { get; set; }

        //private readonly RemoteWebDriver Driver;

        public IWebElement PracticeTable => _driver.FindElement(By.XPath("//*[@id='content']/table"));

        public IWebElement PracticeTableHeader => _driver.FindElement(By.XPath("//*[@id='content']/table/thead"));
    }
}