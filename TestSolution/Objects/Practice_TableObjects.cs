using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumFrameWorkDesign;

namespace TestSolution.Objects
{
    public class Practice_TableObjects
    {
        //public Practice_TableObjects()
        //{
        //    PageFactory.InitElements(PropertiesCollection.Driver, this);
        //}

        //[FindsBy(How = How.XPath, Using = "//*[@id='content']/table")]
        //public IWebElement PracticeTable { get; set; }

        //[FindsBy(How = How.XPath, Using = "//*[@id='content']/table/thead")]
        //public IWebElement PracticeTableHeader { get; set; }

        private readonly RemoteWebDriver _driver;
        public Practice_TableObjects()
        {
            _driver = PropertiesCollection.Driver;
        }
        public IWebElement PracticeTable => _driver.FindElementByXPath("//*[@id='content']/table");

        public IWebElement PracticeTableHeader => _driver.FindElementByXPath("//*[@id='content']/table/thead");
    }
}
