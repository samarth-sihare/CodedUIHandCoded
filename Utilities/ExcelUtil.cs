using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excel;

namespace CodedUIHandCoded.Utilities
{
    public class ExcelUtil
    {

        //Do not miss adding System.Xml in Project References
        /// <summary>
        /// This class contain methods that read all data from the excel sheet and stores it in system memory
        /// later a function called ReadData can be used to read data from it n number of times 
        /// This enhances the speed of execution tremendously 
        /// </summary>


        public static DataTable ImportDataFromExcelToDataTable(string fileNameWtihPath, string sheetName)
        {
            //open file and returns as Stream
            FileStream stream = File.Open(fileNameWtihPath, FileMode.Open, FileAccess.Read);
            //Create openxmlreader via ExcelReaderDactory
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream); //for .xlsx file or use .CreateBinaryReader instead of CreateOpenXmlReader
            //Set first row as header/column name
            excelReader.IsFirstRowAsColumnNames = true;
            //Return as DataSet
            DataSet result = excelReader.AsDataSet();
            //Gets All the Tables
            DataTableCollection table = result.Tables;
            //Store it in DataTable
            DataTable requiredTable = result.Tables[sheetName];
            
            //Return Table
            return requiredTable;
        }

        public static List<Datacollection> dataColumn = new List<Datacollection>();

        //This method will populate all the data form excel in collection and will use ReadData method to read data from this collection
        public static void PopulateInCollection(string fileNameWtihPath, string sheetName)
        {
            DataTable table = ImportDataFromExcelToDataTable(fileNameWtihPath, sheetName);

            //Iterate through the rows and columns of the table
            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    Datacollection dtTable = new Datacollection()
                    {
                        rowNumber = row,
                        columnName = table.Columns[col].ColumnName,
                        columnValue = table.Rows[row - 1][col].ToString()
                    };

                    //Add all the details for each row
                    dataColumn.Add(dtTable);
                }
            }
        }

        //Reads data from the data collection and reads the data from memory 
        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                //Retriving Data using LINQ to reduce much of iterations
                string data = (from colData in dataColumn
                               where colData.columnName == columnName && colData.rowNumber == rowNumber
                               select colData.columnValue).SingleOrDefault();

                //Or second approach to above using extension method
                //var datas = dataColumn.Where(x => x.columnName == columnName && x.rowNumber == rowNumber).SingleOrDefault().columnValue;

                return data.ToString();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }

    public class Datacollection
    {
        public int rowNumber { get; set; }
        public string columnName { get; set; }
        public string columnValue { get; set; }
    }
}
