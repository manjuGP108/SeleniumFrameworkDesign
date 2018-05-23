using OpenQA.Selenium;
using SeleniumFrameWorkDesign.Base;

namespace TestSolution.Objects
{
    public class CheckOutPageObjects : BasePage
    {
        public IWebElement ProceedToCheckOutElement => DriverContext.Driver.FindElement(By.XPath("//*[@id='noo-site']/div[2]/div/div/div/div/div/div/div/div[2]/div/div[2]/div/a"));

        public IWebElement ShipToDifferentAdressElement => DriverContext.Driver.FindElement(By.XPath("//*[@id='ship-to-different-address-checkbox']"));

        public IWebElement PlaceOrderButtonElement => DriverContext.Driver.FindElement(By.XPath("//*[@id='place_order']"));
    }
}