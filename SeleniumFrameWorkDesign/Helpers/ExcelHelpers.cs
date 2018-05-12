using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using ExcelDataReader;

namespace SeleniumFrameWorkDesign.Helpers
{
    public class ExcelHelpers
    {
        private static readonly List<Datacollection> dataCol = new List<Datacollection>();

        // reference: http://executeautomation.com/blog/ddt-excel-cuit-part-2/
        private static DataTable ExcelToDataTable(string fileName)
        {
            //open file and returns as Stream
            var stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
            //Createopenxmlreader via ExcelReaderFactory
            var excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream); //.xlsx
            //Set the First Row as Column Name
            //excelReader.IsFirstRowAsColumnNames = true;

            //Return as DataSet
            var result = excelReader.AsDataSet(new ExcelDataSetConfiguration
            {
                ConfigureDataTable = data => new ExcelDataTableConfiguration
                {
                    UseHeaderRow = true
                }
            });

            ////Return as DataSet
            //DataSet result1 = excelReader.AsDataSet();
            //Get all the Tables
            var table = result.Tables;
            //Store it in DataTable
            var resultTable = table["Sheet1"];

            //return
            return resultTable;
        }

        public static void PopulateInCollection(string fileName)
        {
            var table = ExcelToDataTable(fileName);

            //Iterate through the rows and columns of the Table
            for (var row = 1; row <= table.Rows.Count; row++)
            for (var col = 0; col <= table.Columns.Count - 1; col++)
            {
                var dtTable = new Datacollection
                {
                    RowNumber = row,
                    ColumnName = table.Columns[col].ColumnName,
                    ColumnValue = table.Rows[row - 1][col].ToString()
                };
                //Add all the details for each row
                dataCol.Add(dtTable);
            }
        }

        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                //Retriving Data using LINQ to reduce much of iterations
                var data = (from colData in dataCol
                    where colData.ColumnName == columnName && colData.RowNumber == rowNumber
                    select colData.ColumnValue).SingleOrDefault();

                //var datas = dataCol.Where(x => x.ColumnName == columnName && x.RowNumber == rowNumber).SingleOrDefault().ColumnValue;
                return data;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }

    public class Datacollection
    {
        public int RowNumber { get; set; }
        public string ColumnName { get; set; }
        public string ColumnValue { get; set; }
    }
}