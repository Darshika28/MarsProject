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
        [Category("Sprint1")]
        class User : Global.Base
        {
            [Test]
            public void AddShareSkillDetails()
            {
                Thread.Sleep(3000);

                //Add Share skill details on page
                ShareSkill _shareSkill = new ShareSkill();
                _shareSkill.GoToShareSkill();
                _shareSkill.EnterShareSkill(2);

                //Check Record is add
                ManageListings _manageListing = new ManageListings();
                _manageListing.GoToManageList();
                _manageListing.CheckRecordAdded();

            }
        }
    }
}
