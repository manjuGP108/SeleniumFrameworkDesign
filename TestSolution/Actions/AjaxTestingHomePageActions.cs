using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumFrameWorkDesign.Base;
using SeleniumFrameWorkDesign.Extentions;
using TestSolution.Objects;

namespace TestSolution.Actions
{
    public class AjaxTestingHomePageActions : BasePage
    {
        private readonly AjaxTestingHomeObjects _ajxTestingHomeObjects = new AjaxTestingHomeObjects();

        public AjaxTestingHomePageActions ClickOnMenWatchesItem()
        {
            _ajxTestingHomeObjects.ManListItem.Hover();
            _ajxTestingHomeObjects.MenWatchesItem.Click();
            return this;
        }

        public AjaxTestingHomePageActions ClickOnAddToCartButtonForFirstWatch()
        {
            _ajxTestingHomeObjects.MenWatchesFirstWatch.Hover();
            Thread.Sleep(1000);
            //var wait = new WebDriverWait(_driver, TimeSpan.FromMinutes(2));
            //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='noo-site']/div[2]/div[2]/div[1]/div/div[1]/div/div[3]/a")));
            //wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='noo-site']/div[2]/div[2]/div[1]/div/div[1]/div/div[3]/a")));
            _ajxTestingHomeObjects.FirstWatchAddToCartButton.Click();
            return this;
        }

        public CheckOutPageActions ClickOnViewCartInAlertWindow()
        {
            //Thread.Sleep(10000);
            var wait = new WebDriverWait(_driver, TimeSpan.FromMinutes(2));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div/div[1]/div/div/a[2]")));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[2]/div/div[1]/div/div/a[2]")));
            //_driver.WaitForDocumentLoaded();
            _driver.SwitchTo().ActiveElement();
            _ajxTestingHomeObjects.ViewCartElement.Click();
            return Activator.CreateInstance<CheckOutPageActions>();
        }
    }
}