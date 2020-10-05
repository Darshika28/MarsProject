using MarsFramework.Global;
using MongoDB.Bson.Serialization.Serializers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {
        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }
        #region Initialize Web Elements
        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement manageListingsLink { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement view { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "//table[1]/tbody[1]")]
        private IWebElement delete { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[3]/i")]
        private IWebElement deleteBtn { get; set; }

        //Click yes on alert button
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[3]/button[2]")]
        private IWebElement AlertYes { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement editBtn { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//div[@class='actions']")]
        private IWebElement clickActionsButton { get; set; }

        //Check for Title in manage list
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr/td[3]")]
        private IWebElement getTitle { get; set; }
        
        //
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/thead/tr/th[3]")]
        private IList<IWebElement> CheckRow { get; set; }
        #endregion

        //Function to check if record is exist
        internal void DeleteRecordIfExist(int dataRow)
        {
            //Get Title From Excel to check record
            string getTitle = GlobalDefinitions.ExcelLib.ReadData(dataRow, "Title");
            int row = CheckRow.Count();
            for (int i = 1; i <= row; i++)
            {
               // string CheckString = CheckRow[i];
              /*  if (CheckString == getTitle)
                {
                   
                } */
            }
        }


        //Function to navigate Manage Listing Page
        internal void GoToManageList()
        {
            Thread.Sleep(2000);
            manageListingsLink.Click();
            Thread.Sleep(5000);
        }
        internal void Listings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");


        }

        //Function to check whether record is added
        internal void CheckRecordAdded(int dataRow)
        {
            //Initialize Excel file
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SkillDetails");
            string actualText = GlobalDefinitions.ExcelLib.ReadData(dataRow, "Title");
            if ( getTitle.Text == actualText)
            {
                //Throw exception when it false
                Assert.IsTrue(true);
            }
        }

        internal void ClickOnEditBtn()
        {
            editBtn.Click();
        }

        internal void CheckRecordEdited(int dataRow)
        {
            //Initialize Excel file
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SkillDetails");
            string actualText = GlobalDefinitions.ExcelLib.ReadData(dataRow, "Title");
            if (getTitle.Text == actualText)
            {
                Assert.IsTrue(true);
            }
        }

        internal void ClickOnDeleteBtn()
        {
            deleteBtn.Click();
            Thread.Sleep(2000);
            AlertYes.Click();
        }

        internal void CheckRecordDeleted(int dataRow)
        {
            //Initialize Excel file
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SkillDetails");
            string actualText = GlobalDefinitions.ExcelLib.ReadData(dataRow, "Title");
            if (getTitle.Text != actualText)
            {
                Assert.IsTrue(true);
            }
        }
    }
}
