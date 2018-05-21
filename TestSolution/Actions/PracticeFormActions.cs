using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumFrameWorkDesign;
using SeleniumFrameWorkDesign.Base;
using SeleniumFrameWorkDesign.Extentions;
using TestSolution.Objects;

namespace TestSolution.Actions
{
    public class PracticeFormActions : BasePage
    {
        private readonly PracticeFormObjects _practiceFormObject = new PracticeFormObjects();

        public void EnterFirstName(string textBoxValue)
        {
            _driver.WaitForDocumentLoaded();
            _practiceFormObject.FirstName.EnterTextBoxText(textBoxValue);
        }

        public void ValidateFirstName(string expectedFirstName)
        {
            var actualFirstName = _practiceFormObject.FirstName.GetTextBoxText();
            Assert.AreEqual(expectedFirstName, actualFirstName, "We are expecting Name as " + expectedFirstName + "but actual Name is " + actualFirstName);
        }

        public void SelectContinent(string continent)
        {
            _practiceFormObject.Continents.SelectDropDownListByValue(continent);
        }

        public void VerifyContinentDropDownListElements()
        {
            var continentsValues = new List<string>(_practiceFormObject.Continents.GetDropDownListElements());
            Assert.AreEqual(7, continentsValues.Count);
        }

        public PracticeTableActions ClickOnLinkText()
        {
            _practiceFormObject.LinkTextElement.Click();
            return new PracticeTableActions();
        }
    }
}