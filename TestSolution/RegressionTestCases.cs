using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using SeleniumFrameWorkDesign;
using TestSolution.Actions;

namespace TestSolution
{
    [DeploymentItem(@"Driver")]
    [TestClass]
    public class RegressionTestCases
    {
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            //PropertiesCollection.Driver = new ChromeDriver();
            //PropertiesCollection.Driver.Navigate().GoToUrl("http://toolsqa.com/automation-practice-form/");
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            PropertiesCollection.Driver.Close();
        }

        [TestMethod]
        public void TestCase()
        {
            var firstName = "Manjunath";
            PropertiesCollection.Driver.Manage().Window.Maximize();
            var practiceForm = new PracticeFormActions();
            practiceForm.EnterFirstName(firstName);
            practiceForm.ValidateFirstName(firstName);
            practiceForm.SelectContinent("Africa");
            practiceForm.VerifyContinentDropDownListElements();
            var practiceTable = practiceForm.ClickOnLinkText();
            practiceTable.ValidateTableHeaders();
        }

        [DeploymentItem("DataDrivenTesting.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\DataDrivenTesting.csv", "DataDrivenTesting#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void test_data_driven_testing()
        {
            var name = TestContext.DataRow["Name"].ToString();
            if (name == "Manju")
                Assert.AreEqual("Africa", TestContext.DataRow["Continents"].ToString());
            else if (name == "Satish")
                Assert.AreEqual("Asia", TestContext.DataRow["Continents"].ToString());
            else
                Assert.AreEqual("Europe", TestContext.DataRow["Continents"].ToString());
        }

        [TestMethod]
        public void data_driven_testing_from_excel_sheet()
        {
            ExcelUtility.PopulateInCollection(@"C:\GIT clone repository\SeleniumFramework\TestSolution\Objects\DataDrivenTesting.xlsx");
            var continent = ExcelUtility.ReadData(1, "Name");
            Assert.AreEqual("Manju", continent);
        }

        [TestMethod]
        public void tead_the_table_elements_from_table_utility()
        {
            var practiceForm = new PracticeFormActions();
            var practiceTable = practiceForm.ClickOnLinkText();
            practiceTable.ValidateTableCellValues();
        }

        [TestMethod]
        public void w3schools_table()
        {
            //PropertiesCollection.Driver.Close();
            PropertiesCollection.Driver = new ChromeDriver();
            PropertiesCollection.Driver.Navigate().GoToUrl("https://www.w3schools.com/html/html_tables.asp");
            var w3Schools = new w3SchoolsPageActions();
            w3Schools.GetContractPersonOfThirdRow();
        }
    }
}