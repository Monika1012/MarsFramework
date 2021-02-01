using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace MarsFramework.Pages
{
    public class SignIn
    {
        public SignIn()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 
        //Finding the Sign Link
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Sign')]")]
        private IWebElement SignIntab { get; set; }

        // Finding the Email Field
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement Email { get; set; }

        //Finding the Password Field
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement Password { get; set; }

        //Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Login')]")]
        private IWebElement LoginBtn { get; set; }

        #endregion

        public void LoginSteps()
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");
            this.ClickTab()
                .EnterUserName(GlobalDefinitions.ExcelLib.ReadData(2, "Username"))
                .EnterPassword(GlobalDefinitions.ExcelLib.ReadData(2, "Password"))
                .ClickLoginButton();
        }
        private SignIn ClickTab() {
            Assert.True(SignIntab.Enabled,"Signin tab is not enabled.");
            this.SignIntab.Click();
            return this;
        }
        private SignIn EnterUserName(string userName) {
            Assert.True(Email.Enabled, "Email Field is not enabled.");
            this.Email.SendKeys(userName);
            return this;

        }
        private SignIn EnterPassword(string password) {
            Assert.True(Password.Enabled, "Password Field is not enabled.");
            this.Password.SendKeys(password);
            return this;

        }
        private SignIn ClickLoginButton() {
            Assert.True(LoginBtn.Enabled, "Login Button is not enabled.");
            this.LoginBtn.Click();
            return this;

        }
    }
}