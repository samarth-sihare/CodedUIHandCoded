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


        [TestMethod]
        [DeploymentItem("Data.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\DataFiles\\Data.csv", "Data#csv", DataAccessMethod.Sequential)]
        [Sequence(1)]
        public void CodedUITestOne()
        {
            string searchText = TestContext.DataRow["searchtext"].ToString();

            homePage.enterSearchText(searchText);
            // TODO: Add assertions
        }

        [TestMethod]
        [Sequence(2)]
        [Requires("CodedUITestOne")]
        public void CodedUITestTwo()
        {
            homePage.SearchGoogle("Hello again Google");
            // TODO: Add assertions 
        }

    }
}

