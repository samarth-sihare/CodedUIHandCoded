using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodedUIHandCoded
{
    public class GoogleHomePage
    {
        private BrowserWindow browser;

        public GoogleHomePage(BrowserWindow browser){
            this.browser = browser;
        }

        private HtmlButton searchBtn()
        {
            //Search Btn
            HtmlButton searchBtn = new HtmlButton(browser);
            searchBtn.TechnologyName = "Web";
            searchBtn.SearchProperties.Add(HtmlButton.PropertyNames.Class, "lsb");
            searchBtn.SearchProperties.Add(HtmlButton.PropertyNames.Name, "btnG");

            return searchBtn;
        }

        private HtmlEdit searchTextBox()
        {
            HtmlEdit searchTextBox = new HtmlEdit(browser);
            searchTextBox.TechnologyName = "Web";
            searchTextBox.SearchProperties.Add(HtmlEdit.PropertyNames.ControlType, "Edit");
            searchTextBox.SearchProperties.Add(HtmlEdit.PropertyNames.Id, "lst-ib");

            return searchTextBox;
        }


        public void SearchGoogle(string searchText)
        {
            searchTextBox().Text = searchText;
            //Keyboard.SendKeys(searchTextBox, "Hello Google");
            Mouse.Click(searchBtn());
        }

        public void enterSearchText(string searchText)
        {
            searchTextBox().Text = searchText;
        }

        public void clickSearchBtn()
        {
            Mouse.Click(searchBtn());
        }
    }
}
