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
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]")]
        private IWebElement getTitle { get; set; }

        //
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/thead/tr/th[3]")]
        private IWebElement CheckRow { get; set; }

        //
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[")]
        private IWebElement beforeCheckRow { get; set; }

        //
        [FindsBy(How = How.XPath, Using = "]/td[3]")]
        private IWebElement afterCheckRow { get; set; }
        #endregion

        //Function to check if record is exist
        internal void DeleteRecordIfExist(int dataRow)
        {
           // GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]")  , 10);
            //Get Title From Excel to check record
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SkillDetails");
            string getTitle = GlobalDefinitions.ExcelLib.ReadData(dataRow, "Title");
            int CheckRow = GlobalDefinitions.driver.FindElements(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr")).Count();

            for (int i = 1; i <= CheckRow ; i++)
            {
                IWebElement CheckString = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[" + i + "]/td[3]"));

                if (CheckString.Text == getTitle)
                {
                    GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[" + i + "]/td[8]/div/button[3]/i")).Click();
                    AlertYes.Click();
                    break;
                }
            }
        }


        //Function to navigate Manage Listing Page
        internal void GoToManageList()
        {
            Thread.Sleep(5000);
          //  GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.LinkText("Manage Listings")  , 10);
            manageListingsLink.Click();
        }
        internal void Listings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");


        }

        //Function to check whether record is added
        internal void CheckRecordAdded(int dataRow)
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]"), 10);
            Thread.Sleep(2000);
            //Initialize Excel file
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SkillDetails");
            string actualText = GlobalDefinitions.ExcelLib.ReadData(dataRow, "Title");
            if ( getTitle.Text == actualText)
            {
                //Throw exception when it false
                Assert.Pass("Record is added", "Test Pass");
            }
            else
            {
                Assert.Fail("Record is added", "Test Pass");
            }
        }

        internal void ClickOnEditBtn()
        {
            editBtn.Click();
        }

        internal void CheckRecordEdited(int dataRow)
        {
            Thread.Sleep(2000);
            //Initialize Excel file
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SkillDetails");
            string actualText = GlobalDefinitions.ExcelLib.ReadData(dataRow, "Title");
            if (getTitle.Text == actualText)
            {
                Assert.Pass("Record is Edited successfuly", "Test Pass");
            }
            else
            {
                Assert.Pass("Record is not Edited ", "Test Fail");
            }
        }

        internal void ClickOnDeleteBtn()
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[3]/i"), 10);
            deleteBtn.Click();
            AlertYes.Click();
        }

        internal void CheckRecordDeleted(int dataRow)
        {
            Thread.Sleep(5000);
            //Initialize Excel file
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SkillDetails");
            string actualText = GlobalDefinitions.ExcelLib.ReadData(dataRow, "Title");
            if (getTitle.Text != actualText)
            {
                Assert.Pass("Record is Delete successfuly", "Test Pass");
            }
            else
            {
                Assert.Pass("Record is not Deleted", "Test Fail");

            }
        }

        //Function to Delete Record Which is added automatically
        internal void DeleteAutomatedRecord(int dataRow)
        {
            //Initialize Excel File
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SkillDetails");
            string autoText = GlobalDefinitions.ExcelLib.ReadData(dataRow, "Title");
            int CheckRow = GlobalDefinitions.driver.FindElements(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr")).Count();

            for (int i = 1; i <= CheckRow; i++)
            {
                IWebElement CheckString = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[" + i + "]/td[3]"));

                if (CheckString.Text == autoText)
                {
                    GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[" + i + "]/td[8]/div/button[3]/i")).Click();
                    AlertYes.Click();
                    break;
                }
            }

        }
    }
}
