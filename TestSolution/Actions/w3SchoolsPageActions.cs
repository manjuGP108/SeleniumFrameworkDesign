using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumFrameWorkDesign.Helpers;
using TestSolution.Objects;

namespace TestSolution.Actions
{
    public class w3SchoolsPageActions
    {
        private readonly w3SchoolsPageObjects w3SchoolPageObject = new w3SchoolsPageObjects();

        public void GetContractPersonOfThirdRow()
        {
            var personName = w3SchoolPageObject.Table.GetTableCellValue(3, "Contact");
            Assert.AreEqual("Roland Mendel", personName);
            var secondPersonName = w3SchoolPageObject.Table.GetTableCellValue(4, 1);
            Assert.AreEqual("Helen Bennett", secondPersonName);
        }
    }
}