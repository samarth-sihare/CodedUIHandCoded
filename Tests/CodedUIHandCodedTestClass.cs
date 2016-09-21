using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using CodedUIHandCoded.Tests;
using CodedUIHandCoded.Utilities;
using System.Data;


namespace CodedUIHandCoded
{
    /// <summary>
    /// Sample Coded UI Test Class
    /// </summary>


    [CodedUITest]
    public class CodedUIHandCodedTestClass : CodedUIHandCodedTestBase
    {


        //Make sure to save CSV data file as Unicode(UFT-8 without signature) - Codepage 65001 using File-->Advance Save Options...
        //Also rightclick on file-->properties and set "Copy to Output Directory" to always copy

        //Data Driven using csv file
        [TestMethod]
        [DeploymentItem("Data.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\DataFiles\\Data.csv", "Data#csv", DataAccessMethod.Sequential)]
        [Sequence(1)]
        public void CodedUITest1()
        {
            string searchText = TestContext.DataRow["searchtext"].ToString();

            homePage.enterSearchText(searchText);
            // TODO: Add assertions
        }

        //Data Driven using excel (using conventional DataSource attribute)
        /// <summary>
        /// If you get a connection error, it's most likely due to the fact that 
        /// you don't have the 2007 Office System Driver installed for the OLEDB provider. 
        /// You can download it from the following Microsoft link:
        /// http://www.microsoft.com/en-us/download/details.aspx?id=23734
        /// </summary>
        [TestMethod]
        [DeploymentItem("Data.xlsx")]
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xlsx)};dbq=|DataDirectory|\\DataFiles\\Data.xlsx;defaultdir=.;driverid=790;maxbuffersize=2048;pagetimeout=5;readonly=true", "GoogleHomePage$", DataAccessMethod.Sequential)]
        public void CodedUITest2()
        {
            string searchText = TestContext.DataRow["SearchText"].ToString();

            homePage.enterSearchText(searchText);
            // TODO: Add assertions
        }

        //Data Driven using excel (using custom methods for reading data from excel)
        [TestMethod]
        [Requires("CodedUITestOne")]
        public void CodedUITest3()
        {
            DataTable dt = ExcelUtil.ImportDataFromExcelToDataTable("../../../DataFiles/Data.xlsx", "GoogleHomePage");

            foreach (DataRow dataRow in dt.Rows)
            {
                string searchText = dataRow["SearchText"].ToString();
                homePage.SearchGoogle(searchText);

                // TODO: Add assertions 
            }
        }

        [TestMethod]
        [DeploymentItem("LoginData.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\DataFiles\\LoginData.csv", "LoginData#csv", DataAccessMethod.Sequential)]
        public void CoidedUITest4()
        {
            string user = TestContext.DataRow["Email"].ToString();
            string password = TestContext.DataRow["Password"].ToString();
            //Another way for .ToString()
            string expectedErrorMessage = TestContext.DataRow["ErrorMessage"].ToString();
            homePage.clickSignInBtn();
            signInPage.EnterCredentials(user, password);

            // TODO: Add assertions 
            Assert.AreEqual(expectedErrorMessage, signInPage.getLoginErrorMessage().Trim(), "The Error Message was not as expected");

        }

    }
}

