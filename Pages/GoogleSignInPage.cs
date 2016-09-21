using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodedUIHandCoded.Pages
{
    public class GoogleSignInPage
    {

        private BrowserWindow browser;
        public GoogleSignInPage(BrowserWindow browser)
        {
            this.browser = browser;
        }

        private HtmlEdit emailTextBox()
        {
            HtmlEdit emailTextBox = new HtmlEdit(browser);
            emailTextBox.TechnologyName = "Web";
            emailTextBox.SearchProperties.Add(HtmlEdit.PropertyNames.Id, "Email");
            return emailTextBox;
        }

        private HtmlEdit passwordTextBox()
        {
            HtmlEdit passwordTextBox = new HtmlEdit(browser);
            passwordTextBox.TechnologyName = "Web";
            passwordTextBox.SearchProperties.Add(HtmlEdit.PropertyNames.Id, "Passwd");
            return passwordTextBox;
        }

        private HtmlInputButton nextBtn()
        {
            HtmlInputButton nextBtn = new HtmlInputButton(browser);
            nextBtn.TechnologyName = "Web";
            nextBtn.SearchProperties.Add(HtmlButton.PropertyNames.Id, "next");
            //nextBtn.SearchProperties.Add(HtmlButton.PropertyNames.Name, "signIn");
            return nextBtn;
        }

        private HtmlInputButton signInBtn()
        {
            HtmlInputButton signInBtn = new HtmlInputButton(browser);
            signInBtn.TechnologyName = "Web";
            signInBtn.SearchProperties.Add(HtmlButton.PropertyNames.Id, "signIn");
            return signInBtn;
        }

        private HtmlSpan loginErrorMessage()
        {
            HtmlSpan loginErrorMessage = new HtmlSpan(browser);
            loginErrorMessage.TechnologyName = "Web";
            loginErrorMessage.SearchProperties.Add(HtmlSpan.PropertyNames.Id, "errormsg_0_Passwd");
            return loginErrorMessage;
        }
        public void EnterCredentials(string email, string password)
        {
            emailTextBox().Text = email;
            Mouse.Click(nextBtn());
            passwordTextBox().Text = password;
            Mouse.Click(signInBtn());
        }

        public string getLoginErrorMessage()
        {
            //return loginErrorMessage().GetProperty("InnerText").ToString();
            return loginErrorMessage().InnerText;
        }
    }
}
