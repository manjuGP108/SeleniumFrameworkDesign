using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumFrameWorkDesign;

namespace TestSolution.Objects
{
    public class PracticeFormObjects
    {
        //public PracticeFormObjects()
        //{
        //    PageFactory.InitElements(PropertiesCollection.Driver, this);
        //}

        //[FindsBy(How = How.XPath, Using = "//*[@id='content']/div[1]/div/div/div/div[2]/div/form/fieldset/div[8]/input")]
        //public IWebElement FirstName { get; set; }

        //[FindsBy(How = How.Id, Using = "continents")]
        //public IWebElement Continents { get; set; }

        //[FindsBy(How = How.LinkText, Using = "Link Test")]
        //public IWebElement LinkTextElement { get; set; }

        private readonly RemoteWebDriver _driver;
        public PracticeFormObjects()
        {
            _driver = PropertiesCollection.Driver;
        }
        public IWebElement FirstName => _driver.FindElementByXPath("//*[@id='content']/div[1]/div/div/div/div[2]/div/form/fieldset/div[8]/input");

        public IWebElement Continents => _driver.FindElementById("continents");

        public IWebElement LinkTextElement => _driver.FindElementByLinkText("Link Test");

    }
}