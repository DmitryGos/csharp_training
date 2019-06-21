using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : ContactTestBase
    {
        [Test]
        public void ContactInformationTest()
        {
            int index = 0;

            ContactData fromTable = app.Contacts.GetContactInformationFromTable(index);
            ContactData fromEditForm = app.Contacts.GetContactInformationFromEditForm(index);

            // verification Table & Edit Form
            Assert.AreEqual(fromTable, fromEditForm);
            Assert.AreEqual(fromTable.Address, fromEditForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromEditForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromEditForm.AllEmails);

            string fromDetails = app.Contacts.GetContactInformationFromDetailsForm(index);
            string gluedData = app.Contacts.GlueDataFromEditForm(fromEditForm);

            // verification Details & Edit Form
            Assert.AreEqual(fromDetails, gluedData);

        }
    }
}
