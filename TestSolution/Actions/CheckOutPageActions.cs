using SeleniumFrameWorkDesign.Base;
using SeleniumFrameWorkDesign.Extentions;
using TestSolution.Objects;

namespace TestSolution.Actions
{
    public class CheckOutPageActions : BasePage
    {
        private readonly CheckOutPageObjects _checkOutPageObject = new CheckOutPageObjects();

        public CheckOutPageActions ClickOnProceedToCheckOutButton()
        {
            _checkOutPageObject.ProceedToCheckOutElement.Click();
            return this;
        }

        public CheckOutPageActions ShipToDiffrentAdress()
        {
            _checkOutPageObject.ShipToDifferentAdressElement.Click();
            return this;
        }

        public CheckOutPageActions ClickOnPlaceOrderButton()
        {
            _driver.WaitForJQuerryToBeFinished();
            _checkOutPageObject.PlaceOrderButtonElement.Click();
            return this;
        }
    }
}