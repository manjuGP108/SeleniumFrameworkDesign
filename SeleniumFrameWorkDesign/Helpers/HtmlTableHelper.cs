using System.Collections;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace SeleniumFrameWorkDesign.Helpers
{
    public static class HtmlTableHelper
    {
        private static List<TableDatacollection> _tableDatacollections;

        public static void ReadTable(this IWebElement table)
        {
            //Initialize the table
            _tableDatacollections = new List<TableDatacollection>();

            //Get all the columns from the table
            var columns = table.FindElements(By.TagName("th"));

            //Get all the rows
            var rows = table.FindElements(By.TagName("tr"));

            //Create row index
            var rowIndex = 0;
            foreach (var row in rows)
            {
                var colIndex = 0;

                var colDatas = row.FindElements(By.TagName("td"));
                //Store data only if it has value in row
                if (colDatas.Count != 0)
                    foreach (var colValue in colDatas)
                    {
                        _tableDatacollections.Add(new TableDatacollection
                        {
                            RowNumber = rowIndex,
                            ColumnName = columns[colIndex].Text != "" ? columns[colIndex].Text : colIndex.ToString(),
                            ColumnValue = colValue.Text,
                            ColumnIndex = colIndex,
                            ColumnSpecialValues = GetControl(colValue)
                        });

                        //Move to next column
                        colIndex++;
                    }
                rowIndex++;
            }
        }

        public static void ReadTableWhenFirstColumnIsHeader(IWebElement table)
        {
            _tableDatacollections = new List<TableDatacollection>();
            var isFirstRowOfTableIsHeader = false;
            var tableRowsElements = new List<IWebElement>(table.FindElement(By.TagName("tbody")).FindElements(By.TagName("tr")));

            #region GetTableHeaders

            // To check weather table has header else take first row elements as TableHeaders 
            var columns = new List<IWebElement>();

            if (table.FindElements(By.TagName("thead")).Count != 0)
            {
                columns = new List<IWebElement>(table.FindElement(By.TagName("thead")).FindElements(By.TagName("th")));
            }
            else if (tableRowsElements.First().FindElements(By.TagName("th")).Count != 0)
            {
                columns = new List<IWebElement>(tableRowsElements.First().FindElements(By.TagName("th")));
                isFirstRowOfTableIsHeader = true;
            }

            else
            {
                columns = new List<IWebElement>(tableRowsElements.First().FindElements(By.TagName("td")));
                isFirstRowOfTableIsHeader = true;
            }

            #endregion

            var rowIndex = 0;
            foreach (var rowElements in tableRowsElements)
            {
                var rowHeader = rowElements.FindElements(By.TagName("th"));
                var colDatas = new List<IWebElement>(rowElements.FindElements(By.TagName("td")));
                if (rowHeader.Count != 0)
                    colDatas.Insert(0, rowHeader.First());
                var colIndex = 0;
                foreach (var colValue in colDatas)
                {
                    if (isFirstRowOfTableIsHeader)
                    {
                        isFirstRowOfTableIsHeader = false;
                        rowIndex--;
                        continue;
                    }
                    _tableDatacollections.Add(new TableDatacollection
                    {
                        RowNumber = rowIndex,
                        ColumnName = columns[colIndex].Text != "" ? columns[colIndex].Text : colIndex.ToString(),
                        ColumnValue = colValue.Text,
                        ColumnIndex = colIndex,
                        ColumnSpecialValues = GetControl(colValue)
                    });
                    colIndex++;
                }
                rowIndex++;
            }
        }

        private static ColumnSpecialValue GetControl(IWebElement columnValue)
        {
            ColumnSpecialValue columnSpecialValue = null;
            //Check if the control has specfic tags like input/hyperlink etc
            if (columnValue.FindElements(By.TagName("a")).Count > 0)
                columnSpecialValue = new ColumnSpecialValue
                {
                    ElementCollection = columnValue.FindElements(By.TagName("a")),
                    ControlType = "hyperLink"
                };
            if (columnValue.FindElements(By.TagName("input")).Count > 0)
                columnSpecialValue = new ColumnSpecialValue
                {
                    ElementCollection = columnValue.FindElements(By.TagName("input")),
                    ControlType = "input"
                };

            return columnSpecialValue;
        }


        public static void PerformActionOnCell(string columnIndex, string refColumnName, string refColumnValue, string controlToOperate = null)
        {
            foreach (int rowNumber in GetDynamicRowNumber(refColumnName, refColumnValue))
            {
                var cell = (from e in _tableDatacollections
                    where e.ColumnName == columnIndex && e.RowNumber == rowNumber
                    select e.ColumnSpecialValues).SingleOrDefault();

                //Need to operate on those controls
                if (controlToOperate != null && cell != null)
                {
                    //Since based on the control type, the retriving of text changes
                    //created this kind of control
                    if (cell.ControlType == "hyperLink")
                    {
                        var returnedControl = (from c in cell.ElementCollection
                            where c.Text == controlToOperate
                            select c).SingleOrDefault();

                        //ToDo: Currenly only click is supported, future is not taken care here 
                        returnedControl?.Click();
                    }
                    if (cell.ControlType == "input")
                    {
                        var returnedControl = (from c in cell.ElementCollection
                            where c.GetAttribute("value") == controlToOperate
                            select c).SingleOrDefault();

                        //ToDo: Currenly only click is supported, future is not taken care here
                        returnedControl?.Click();
                    }
                }
                else
                {
                    cell.ElementCollection?.First().Click();
                }
            }
        }

        private static IEnumerable GetDynamicRowNumber(string columnName, string columnValue)
        {
            //dynamic row
            foreach (var table in _tableDatacollections)
                if (table.ColumnName == columnName && table.ColumnValue == columnValue)
                    yield return table.RowNumber;
        }

        public static string GetTableCellValue(this IWebElement tableElement, int rowNo, string columnName)
        {
            ReadTable(tableElement);
            var tableCellValue = from cell in _tableDatacollections
                where cell.RowNumber == rowNo && cell.ColumnName == columnName
                select cell.ColumnValue;
            return tableCellValue.ToList().FirstOrDefault();
        }

        public static string GetTableCellValue(this IWebElement tableElement, int rowNo, int columnNo)
        {
            ReadTable(tableElement);
            var tableCellValue = from cell in _tableDatacollections
                where cell.RowNumber == rowNo && cell.ColumnIndex == columnNo
                select cell.ColumnValue;
            return tableCellValue.ToList().FirstOrDefault();
        }

        public static string GetTableCellValueWhenTableFirstColumnIsHeader(this IWebElement tableElement, int rowNo, string columnName)
        {
            ReadTableWhenFirstColumnIsHeader(tableElement);
            var tableCellValue = from cell in _tableDatacollections
                where cell.RowNumber == rowNo - 1 && cell.ColumnName == columnName
                select cell.ColumnValue;
            return tableCellValue.ToList().FirstOrDefault();
        }

        public static string GetTableCellValueWhenTableFirstColumnIsHeader(this IWebElement tableElement, int rowNo, int columnNo)
        {
            ReadTableWhenFirstColumnIsHeader(tableElement);
            var tableCellValue = from cell in _tableDatacollections
                where cell.RowNumber == rowNo - 1 && cell.ColumnIndex == columnNo
                select cell.ColumnValue;
            return tableCellValue.ToList().FirstOrDefault();
        }
    }


    public class TableDatacollection
    {
        public int RowNumber { get; set; }
        public string ColumnName { get; set; }
        public string ColumnValue { get; set; }
        public int ColumnIndex { get; set; }
        public ColumnSpecialValue ColumnSpecialValues { get; set; }
    }

    public class ColumnSpecialValue
    {
        public IEnumerable<IWebElement> ElementCollection { get; set; }
        public string ControlType { get; set; }
    }
}