using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Linq;

namespace MarsFramework.Pages {
    public class ShareSkill {
        public ShareSkill() {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on ShareSkill Button

        private IWebElement ShareSkillButton {
            get {
                System.Threading.Thread.Sleep(5000);
                return GlobalDefinitions.driver.FindElement(By.CssSelector("a.ui.basic.green.button"));
            }

        }

        //Enter the Title in textbox

        private IWebElement Title => GlobalDefinitions.driver.FindElement(By.CssSelector("input[name=\"title\"]"));



        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        private IWebElement Tags { get; set; }

        //Select the Service type
        [FindsBy(How = How.XPath, Using = "//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']")]
        private IWebElement ServiceTypeOptions { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement LocationTypeOption { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateDropDown { get; set; }

        //Storing the table of available days
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]")]
        private IWebElement Days { get; set; }

        //Storing the starttime
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTime { get; set; }

        //Click on StartTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTimeDropDown { get; set; }

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[3]/input[1]")]
        private IWebElement EndTimeDropDown { get; set; }

        //Click on Skill Trade option
        [FindsBy(How = How.XPath, Using = "//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement SkillTradeOption { get; set; }

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement SkillExchange { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }

        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement ActiveOption { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }



        private void ClickSave() {
            Assert.True(Save.Enabled, "Save button is not enabled.");
            this.Save.Click();
        }

        private ShareSkill EnterTitle(string title) {
            Assert.True(Title.Enabled, "Title is not enabled.");
            this.Title.Click();
            return this;
        }
        private ShareSkill EnterDescription(string description) {
            Assert.True(Description.Enabled, "Description Field is not enabled.");
            this.Description.SendKeys(description);
            return this;

        }
        private bool SelectOption(string option, IWebElement root) {
            SelectElement rootElement = new SelectElement(root);
            Assert.True(rootElement.Options.First(x => x.Text.Contains(option)) != null, $"Didn't find option {option} in selector.");
            rootElement.SelectByText(option, true);
            return true;
        }
        private ShareSkill SelectCategory(string category) {
            Assert.True(CategoryDropDown.Enabled, "Category Field is not enabled.");
            SelectOption(category, this.CategoryDropDown);
            return this;

        }
        private ShareSkill SelectSubCategory(string subCategory) {
            Assert.True(SubCategoryDropDown.Enabled, "Subcategory Field is not enabled.");
            SelectOption(subCategory, this.SubCategoryDropDown);
            return this;

        }
        private ShareSkill EnterTags(params string[] tags) {
            Assert.True(Tags.Enabled, "Tags field is not enabled.");
            this.Tags.SendKeys(tags[0]);
            return this;


        }
        private ShareSkill EnterSkillExchangeTag(params string[] skillExchangeTag) {
            Assert.True(SkillExchange.Enabled, "Skill Exchange Tag is not enabled.");
            this.SkillExchange.SendKeys(skillExchangeTag[0]);
            return this;

        }
        private ShareSkill ClickShareSkill() {
            Assert.True(ShareSkillButton.Enabled, "Share Skill Button not enabled.");
            this.ShareSkillButton.Click();
            return this;
        }
        private void EnterSharedSkillFromDataRow(int rowNum) {
            this.ClickShareSkill()
                .EnterTitle(GlobalDefinitions.ExcelLib.ReadData(rowNum, "Title"))
                .EnterDescription(GlobalDefinitions.ExcelLib.ReadData(rowNum, "Description"))
                .SelectCategory(GlobalDefinitions.ExcelLib.ReadData(rowNum, "Category"))
                .SelectSubCategory(GlobalDefinitions.ExcelLib.ReadData(rowNum, "SubCategory"))
                .EnterTags(GlobalDefinitions.ExcelLib.ReadData(rowNum, "Tags"))
                .EnterSkillExchangeTag(GlobalDefinitions.ExcelLib.ReadData(rowNum, "Skill-Exchange"))
                .ClickSave();
        }
        internal ShareSkill EnterShareSkill() {
            GlobalDefinitions.ExcelLib.PopulateInCollection(Path.Combine(Base.basePath, "ExcelData", "TestDataShareSkill.xlsx"), "ShareSkill");
            EnterSharedSkillFromDataRow(2);


            return this;


        }
        internal void EditShareSkill() {
            GlobalDefinitions.ExcelLib.PopulateInCollection(Path.Combine(Base.basePath, "TestDataShareSkill.xlsx"), "ShareSkill");
            EnterSharedSkillFromDataRow(3);
        }
        internal ShareSkill ValidateIfLoaded() {
            ClickShareSkill();
            Assert.True(Title != null, "Share skill page did not load successfully");
            return this;
        }
    }
}
