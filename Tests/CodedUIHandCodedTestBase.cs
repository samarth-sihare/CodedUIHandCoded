using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CodedUIHandCoded.Tests
{

    /// <summary>
    /// Base Class
    /// </summary>
    public class CodedUIHandCodedTestBase
    {

        protected BrowserWindow browser;
        protected GoogleHomePage homePage;

        #region Additional Test SetUp and CleanUp

        //Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            string ApplicationUnderTestURL = ConfigurationManager.AppSettings["ApplicationUnderTestURL"].ToString();

            //BrowserWindow.CurrentBrowser = "Chrome";
            browser = BrowserWindow.Launch(ApplicationUnderTestURL);
            browser.Maximized = true;

            homePage = new GoogleHomePage(browser);
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
            Playback.Cleanup();
        }

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;
    }

}

