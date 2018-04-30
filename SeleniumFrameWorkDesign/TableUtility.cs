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
            var isFirstRowOfTableIsHeader = false;
            var tableRowsElements = new List<IWebElement>(table.FindElement(By.TagName("tbody")).FindElements(By.TagName("tr")));

            #region GetTableHeaders

            // To check weather table has header else take first row elements as TableHeaders 
            var tableHeaderElements = new List<IWebElement>();

            if (table.FindElements(By.TagName("thead")).Count != 0)
            {
                tableHeaderElements = new List<IWebElement>(table.FindElement(By.TagName("thead")).FindElements(By.TagName("th")));
            }
            else if (tableRowsElements.First().FindElements(By.TagName("th")).Count != 0)
            {
                tableHeaderElements = new List<IWebElement>(tableRowsElements.First().FindElements(By.TagName("th")));
                isFirstRowOfTableIsHeader = true;
            }

            else
            {
                tableHeaderElements = new List<IWebElement>(tableRowsElements.First().FindElements(By.TagName("td")));
                isFirstRowOfTableIsHeader = true;
            }

            #endregion

            var rowIndex = 0;
            foreach (var rowElements in tableRowsElements)
            {
                var rowHeader = rowElements.FindElements(By.TagName("th"));
                var tableRowData = new List<IWebElement>(rowElements.FindElements(By.TagName("td")));
                if (rowHeader.Count != 0)
                    tableRowData.Insert(0, rowHeader.First());
                var columnIndex = 0;
                foreach (var tableElementData in tableRowData)
                {
                    if (isFirstRowOfTableIsHeader)
                    {
                        isFirstRowOfTableIsHeader = false;
                        rowIndex--;
                        continue;
                    }
                    var tableData = new TableDatacollections();
                    tableData.RowNumber = rowIndex;
                    tableData.ColumnIndex = columnIndex;
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

        public static string GetTableCellValue(this IWebElement tableElement, int rowNo, int columnNo)
        {
            ReadTable(tableElement);
            var tableCellValue = from cell in tableDataCollection
                where cell.RowNumber == rowNo - 1 && cell.ColumnIndex == columnNo - 1
                select cell.ColumnValue;
            return tableCellValue.ToList().FirstOrDefault();
        }
    }


    public class TableDatacollections
    {
        public int RowNumber { get; set; }
        public string ColumnName { get; set; }
        public string ColumnValue { get; set; }
        public int ColumnIndex { get; set; }
    }
}