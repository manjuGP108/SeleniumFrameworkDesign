using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumFrameWorkDesign;
using TestSolution.Objects;

namespace TestSolution.Actions
{
    internal class Practice_TableActions
    {
        private readonly Practice_TableObjects _practiceTableObject = new Practice_TableObjects(); 
        public void ValidateTableHeaders()
        {
            List<string> tableHeaderElementValues = new List<string>();
            tableHeaderElementValues = _practiceTableObject.PracticeTableHeader.GetTableHeaders();
            Assert.AreEqual(7, tableHeaderElementValues.Count);
        }
    }
}
