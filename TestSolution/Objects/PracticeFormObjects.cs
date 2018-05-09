using OpenQA.Selenium;
using SeleniumFrameWorkDesign.Base;

namespace TestSolution.Objects
{
    public class PracticeFormObjects : BasePage
    {
        //public PracticeFormObjects()
        //{
        //    PageFactory.InitElements(DriverContext.Driver, this);
        //}

        //[FindsBy(How = How.XPath, Using = "//*[@id='content']/div[1]/div/div/div/div[2]/div/form/fieldset/div[8]/input")]
        //public IWebElement FirstName { get; set; }

        //[FindsBy(How = How.Id, Using = "continents")]
        //public IWebElement Continents { get; set; }

        //[FindsBy(How = How.LinkText, Using = "Link Test")]
        //public IWebElement LinkTextElement { get; set; }

        //public PracticeFormObjects()
        //{
        //    _driver = DriverContext.Driver;
        //}


        public IWebElement FirstName => _driver.FindElement(By.XPath("//*[@id='content']/div[1]/div/div/div/div[2]/div/form/fieldset/div[8]/input"));

        public IWebElement Continents => _driver.FindElement(By.Id("continents"));

        public IWebElement LinkTextElement => _driver.FindElement(By.LinkText("Link Test"));
    }
}