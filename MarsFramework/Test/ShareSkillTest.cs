using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsFramework.Test
{
    class ShareSkillTest
    {
        [TestFixture]
        
        class User : Global.Base
        {
            [Test]
            [Category("1.Add Record")]
            public void AddShareSkillDetails()
            {
                ManageListings _manageListing = new ManageListings();
                _manageListing.GoToManageList();
                _manageListing.DeleteRecordIfExist(2);

                Thread.Sleep(3000);
                //Add Share skill details on page
                ShareSkill _shareSkill = new ShareSkill();
                _shareSkill.GoToShareSkill();
                _shareSkill.EnterShareSkill(2);

                //Check Record is add
                _manageListing.GoToManageList();
                _manageListing.CheckRecordAdded(2);

            }

            [Test]
            [Category("2.Edit Record")]
            public void EditShareSkillDetails()
            {
                //Navigate to ManageList
                ManageListings _manageListing = new ManageListings();
                _manageListing.GoToManageList();
                Thread.Sleep(2000);
                _manageListing.ClickOnEditBtn();
                Thread.Sleep(3000);

                ShareSkill _shareSkill = new ShareSkill();
                _shareSkill.EditShareSkill(3);

                _manageListing.GoToManageList();
                _manageListing.CheckRecordEdited(3);
            }

            [Test]
            [Category("3.Delete Record")]
            public void DeleteShareSkillDetails()
            {
                ManageListings _manageListing = new ManageListings();
                _manageListing.GoToManageList();
             //   _manageListing.ClickOnDeleteBtn();
                _manageListing.DeleteAutomatedRecord(2);
                _manageListing.CheckRecordDeleted(2);
            }
        }
    }
}
