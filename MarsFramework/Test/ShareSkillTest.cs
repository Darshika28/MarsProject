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
                Thread.Sleep(3000);
                //Add Share skill details on page
                ShareSkill _shareSkill = new ShareSkill();
                _shareSkill.GoToShareSkill();
                _shareSkill.EnterShareSkill(2);

                //Check Record is add
                ManageListings _manageListing = new ManageListings();
                Thread.Sleep(3000);
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
                _manageListing.ClickOnEditBtn();

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
                _manageListing.ClickOnDeleteBtn();
                _manageListing.CheckRecordDeleted(3);
            }
        }
    }
}
