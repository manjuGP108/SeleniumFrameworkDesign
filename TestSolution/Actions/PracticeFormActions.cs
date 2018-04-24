using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumFrameWorkDesign;
using TestSolution.Objects;

namespace TestSolution.Actions
{
    internal class PracticeFormActions
    {
        private readonly PracticeFormObjects _practiceFormObject = new PracticeFormObjects();

        public void EnterFirstName(string textBoxValue)
        {
            _practiceFormObject.FirstName.EnterTextBoxText(textBoxValue);
        }

        public void ValidateFirstName(string expectedFirstName)
        {
            string actualFirstName = _practiceFormObject.FirstName.GetTextBoxText();
            Assert.AreEqual(expectedFirstName, actualFirstName, "We are expecting Name as " + expectedFirstName + "but actual Name is " + actualFirstName);
        }

        public void SelectContinent(string continent)
        {
         _practiceFormObject.Continents.SelectDropDownListByValue(continent);
        }

        public void VerifyContinentDropDownListElements()
        {
            List<string> continentsValues = new List<string>(_practiceFormObject.Continents.GetDropDownListElements());
            Assert.AreEqual(7, continentsValues.Count);
        }

        public Practice_TableActions ClickOnLinkText()
        {
            _practiceFormObject.LinkTextElement.Click();
            return new Practice_TableActions();
        }
    }
}