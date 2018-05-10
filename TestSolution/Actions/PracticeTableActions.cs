using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumFrameWorkDesign;
using SeleniumFrameWorkDesign.Base;
using TestSolution.Objects;

namespace TestSolution.Actions
{
    public class PracticeTableActions : BasePage
    {
        private readonly PracticeTableObjects _practiceTableObject = new PracticeTableObjects();

        public void ValidateTableHeaders()
        {
            var tableHeaderElementValues = new List<string>();
            tableHeaderElementValues = _practiceTableObject.PracticeTable.GetTableHeaders();
            Assert.AreEqual(7, tableHeaderElementValues.Count);
        }

        public void ValidateTableCellValues()
        {
            var tableFirstRowSecondElement = _practiceTableObject.PracticeTable.GetTableCellValue(1, "Country");
            Assert.AreEqual("UAE", tableFirstRowSecondElement);
            var tableSecondRowSecondElement = _practiceTableObject.PracticeTable.GetTableCellValue(2, 2);
            Assert.AreEqual("Saudi Arabia", tableSecondRowSecondElement);
        }
    }
}