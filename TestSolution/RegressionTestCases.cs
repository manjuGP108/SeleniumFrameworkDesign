using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumFrameWorkDesign;
using TestSolution.Actions;

namespace TestSolution
{
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
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\DataDrivenTesting.csv", "DataDrivenTesting#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        //[DeploymentItem("TextFile1.csv")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TextFile1.csv", "TextFile1#csv", DataAccessMethod.Sequential)]
        //[TestMethod]
        public void test_data_driven_testing()
        {
            var name = TestContext.DataRow["Name"].ToString();

            //testing test
        }
    }
}