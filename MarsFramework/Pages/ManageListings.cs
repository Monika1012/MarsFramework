using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsFramework.Pages
{
    public class ManageListings
    {
        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement manageListingsLink { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement view { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "//table[1]/tbody[1]")]
        private IWebElement delete { get; set; }

        

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement edit { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//div[@class='actions']")]
        private IWebElement clickActionsButton { get; set; }

        private IReadOnlyList<IWebElement> rows = GlobalDefinitions.driver.FindElements(By.CssSelector("table tbody tr"));
        internal void Listings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");
            this.ValidateListingCreated(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));


        }
        internal ManageListings ValidateListingCreated(string exclusiveContent) {
            var interstingRow = rows.First(r => r.Text.Contains(exclusiveContent));
            Assert.NotNull(interstingRow, "Form not saved successfully!!");
            return this;
        }

        public ManageListings ValidatePageLoaded() {
           
            Assert.NotNull(edit, "Listings Page did not load.");
            return this;
        }
    }
}
