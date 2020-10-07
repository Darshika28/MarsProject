using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using AutoItX3Lib;

namespace MarsFramework.Pages
{
    internal class ShareSkill
    {
        public ShareSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on ShareSkill Button
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement ShareSkillButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

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

        //Find Service type one-off
        [FindsBy(How = How.XPath, Using = ".//input[@name='serviceType'][@value='1']")]
        private IWebElement ServiceOneOff { get; set; }

        //Find Service type one-off
        [FindsBy(How = How.XPath, Using = ".//input[@name='serviceType'][@value='0']")]
        private IWebElement ServiceHourly { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement LocationTypeOption { get; set; }

        //Select On-site for location
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[1]/div/input")]
        private IWebElement LocationOnSite { get; set; }

        //Select Online for location
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input")]
        private IWebElement LocationOnline { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateDropDown { get; set; }

        //Storing the table of available days
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]")]
        private IWebElement Days { get; set; }

        //select monDay check box
        [FindsBy(How = How.XPath, Using = ".//input[@index='1'][@type='checkbox']")]
        private IWebElement DayMon { get; set; }

        //Storing the starttime
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTime { get; set; }

        //Click on StartTime dropdown
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[2]/input")]
        private IWebElement StartTimeDropDown { get; set; }

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[3]/input")]
        private IWebElement EndTimeDropDown { get; set; }

        //Click on Skill Trade option
        [FindsBy(How = How.XPath, Using = "//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement SkillTradeOption { get; set; }

        //Select Skill Exchange 
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input")]
        private IWebElement SkillTradeExchange { get; set; }

        //Select Credit for skill exchange
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input")]
        private IWebElement SkillTradeCredit { get; set; }

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement SkillExchange { get; set; }

        //Enter Delete Skill Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement DeleteSkillExchange { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }

        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement Active { get; set; }
        
        //Click on Active
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input")]
        private IWebElement ActiveOption { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

        //Find File upload button
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i")]
        private IWebElement FileUpload { get; set; }

        //Function to navigate Shareskill Page
        internal void GoToShareSkill()
        {
            // GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.LinkText("Share Skill") , 10);
            Thread.Sleep(10000);
            ShareSkillButton.Click();
        }
        internal void InputText(int dataRow)
        {
          //  GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.Name("Title"), 10);
            Thread.Sleep(3000);
            //Enter all details
            Title.Clear();
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(dataRow, "Title"));
            Description.Clear();
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(dataRow, "Description"));

        }

        internal void InputDetails(int dataRow)
        {

            CategoryDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(dataRow, "Category"));
            SubCategoryDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(dataRow, "SubCategory"));
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(dataRow, "Tags") + Keys.Enter);
        }

        internal void clickRadioBtn(int dataRow)
        {
            string serviceType = GlobalDefinitions.ExcelLib.ReadData(dataRow, "ServiceType");
            if (serviceType == "One-off service")
            {
                ServiceOneOff.Click();
            }
            else
            {
                ServiceHourly.Click();
            }

            string LocationType = GlobalDefinitions.ExcelLib.ReadData(dataRow, "LocationType");
            if ( LocationType == "On-site")
            {
                LocationOnSite.Click();
            }
            else
            {
                LocationOnline.Click();
            }
        }

        internal void AddDayTimeDetails(int dataRow)
        {
            StartDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(dataRow, "Startdate") + Keys.Enter);
            EndDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(dataRow, "Enddate") + Keys.Enter);
            DayMon.Click();
            StartTimeDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(dataRow, "Starttime") + Keys.Enter);
            EndTimeDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(dataRow, "Endtime") + Keys.Enter);
            SkillTradeExchange.Click();
            SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(dataRow, "Skill-Exchange") + Keys.Enter);
           
        }

        internal void UploadFile()
        {
            FileUpload.Click();
            // FileUpload.SendKeys("D:\\Automation\\MarsProject\\marsframework\\MarsFramework\\ExcelData\\Testing.exe");

            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinActivate("Open");
            Thread.Sleep(2000);
            autoIt.Send(@"D:\Automation\MarsProject\marsframework\MarsFramework\ExcelData\QA.png");
            autoIt.Send("{Enter}");

        }

        internal void EnterShareSkill(int dataRow)
        {
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SkillDetails");

            //Wait for Element to find
            InputText(dataRow);

            InputDetails(dataRow);

            clickRadioBtn(dataRow);
            AddDayTimeDetails(dataRow);
            UploadFile();
            ActiveOption.Click();
            Save.Click();
        }

        internal void EditDetails(int dataRow)
        {
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SkillDetails");
            Thread.Sleep(3000);
            SkillTradeCredit.Click();
            CreditAmount.Clear();
            CreditAmount.SendKeys(GlobalDefinitions.ExcelLib.ReadData(dataRow, "Credit"));
        }

        internal void EditShareSkill(int dataRow)
        {
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SkillDetails");
            InputText(dataRow);
            InputDetails(dataRow);
            EditDetails(dataRow);
            Save.Click();
        }

       
    }
}
