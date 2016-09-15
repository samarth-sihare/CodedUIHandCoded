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

        [TestMethod]
        [Sequence(1)]
        public void CodedUITestOne()
        {
            homePage.SearchGoogle("Hello Google");
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

