using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using SeleniumFrameWorkDesign.Base;
using SeleniumFrameWorkDesign.Config;
using SeleniumFrameWorkDesign.Helpers;
using TestSolution.Actions;

namespace TestSolution
{
    [DeploymentItem(@"Driver")]
    [TestClass]
    public class RegressionTestCases : Base
    {
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            LogHelpers.CreateLogFile();
            ConfigReader.SetFrameworkSettings();
            OpenBrowser();
            DriverContext.Browser.GoToUrl(Settings.AUT);
            DriverContext.Driver.Manage().Window.Maximize();
        }

        public void OpenBrowser(BrowserType browserType = BrowserType.Chrome)
        {
            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                    DriverContext.Driver = new InternetExplorerDriver();
                    // For initializing Browser. So that we can access the methods in Browser classs such as GoToUrl
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.FireFox:
                    DriverContext.Driver = new FirefoxDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.Chrome:
                    DriverContext.Driver = new ChromeDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
            }
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            DriverContext.Driver.Close();
        }

        [TestMethod]
        public void TestCase()
        {
            CurrentPage = GetInstance<PracticeFormActions>();
            CurrentPage.As<PracticeFormActions>().EnterFirstName(ConfigurationManager.AppSettings["UserName"]);
            CurrentPage.As<PracticeFormActions>().ValidateFirstName(ConfigurationManager.AppSettings["UserName"]);
            CurrentPage.As<PracticeFormActions>().SelectContinent("Africa");
            CurrentPage.As<PracticeFormActions>().VerifyContinentDropDownListElements();
            CurrentPage = CurrentPage.As<PracticeFormActions>().ClickOnLinkText();
            CurrentPage.As<PracticeTableActions>().ValidateTableHeaders();
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
            var fileName = Environment.CurrentDirectory;
            ExcelHelpers.PopulateInCollection(@"C:\GIT clone repository\SeleniumFramework\TestSolution\Objects\DataDrivenTesting.xlsx");
            var continent = ExcelHelpers.ReadData(1, "Name");
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
            //DriverContext.Driver.Close();
            DriverContext.Driver = new ChromeDriver();
            DriverContext.Driver.Navigate().GoToUrl("https://www.w3schools.com/html/html_tables.asp");
            var w3Schools = new w3SchoolsPageActions();
            w3Schools.GetContractPersonOfThirdRow();
        }
    }
}