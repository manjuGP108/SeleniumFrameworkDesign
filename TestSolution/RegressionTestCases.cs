using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using SeleniumFrameWorkDesign;
using TestSolution.Actions;

namespace TestSolution
{
    [TestClass]
    public class RegressionTestCases
    {
        [TestInitialize]
        public void TestInitialize()
        {
            PropertiesCollection.Driver = new ChromeDriver();
            PropertiesCollection.Driver.Navigate().GoToUrl("http://toolsqa.com/automation-practice-form/");
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            PropertiesCollection.Driver.Close();
        }

        [TestMethod]
        public void TestCase()
        {
            string firstName = "Manjunath";
            PropertiesCollection.Driver.Manage().Window.Maximize();
            PracticeFormActions practiceForm = new PracticeFormActions();
            practiceForm.EnterFirstName(firstName);
            practiceForm.ValidateFirstName(firstName);
            practiceForm.SelectContinent("Africa");
            practiceForm.VerifyContinentDropDownListElements();
            Practice_TableActions practiceTable = practiceForm.ClickOnLinkText();
            practiceTable.ValidateTableHeaders();
        }
    }
}