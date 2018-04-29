using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumFrameWorkDesign;
using TestSolution.Objects;

namespace TestSolution.Actions
{
    public class w3SchoolsPageActions
    {
        private readonly w3SchoolsPageObjects w3SchoolPageObject = new w3SchoolsPageObjects();

        public void GetContractPersonOfThirdRow()
        {
            var personName = w3SchoolPageObject.Table.GetTableCellValue(3, "Contract");
            Assert.AreEqual("Ernst Handel", personName);
        }
    }
}