using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace SeleniumFrameWorkDesign
{
    public static class TableUtility
    {
        private static readonly List<TableDatacollections> tableDataCollection = new List<TableDatacollections>();

        public static void ReadTable(IWebElement table)
        {
            var tableRowsElements = new List<IWebElement>(table.FindElement(By.TagName("tbody")).FindElements(By.TagName("tr")));
            var tableHeaderElements = new List<IWebElement>(table.FindElement(By.TagName("thead")).FindElements(By.TagName("th")));
            var rowIndex = 0;
            foreach (var rowElements in tableRowsElements)
            {
                var rowHeader = rowElements.FindElement(By.TagName("th"));
                var tableRowData = new List<IWebElement>(rowElements.FindElements(By.TagName("td")));
                if (rowHeader != null)
                    tableRowData.Insert(0, rowHeader);
                var columnIndex = 0;
                foreach (var tableElementData in tableRowData)
                {
                    var tableData = new TableDatacollections();
                    tableData.RowNumber = rowIndex;
                    tableData.ColumnName = tableHeaderElements[columnIndex].Text;
                    tableData.ColumnValue = tableElementData.Text;
                    tableDataCollection.Add(tableData);
                    columnIndex++;
                }
                rowIndex++;
            }
        }

        public static string GetTableCellValue(this IWebElement tableElement, int rowNo, string columnName)
        {
            ReadTable(tableElement);
            var tableCellValue = from cell in tableDataCollection
                where cell.RowNumber == rowNo - 1 && cell.ColumnName == columnName
                select cell.ColumnValue;
            return tableCellValue.ToList().FirstOrDefault();
        }
    }


    public class TableDatacollections
    {
        public int RowNumber { get; set; }
        public string ColumnName { get; set; }
        public string ColumnValue { get; set; }
    }
}