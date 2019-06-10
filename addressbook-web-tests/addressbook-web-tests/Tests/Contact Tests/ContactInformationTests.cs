using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void ContactInformationTestMainPage()
        {
            int index = 0;
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(index);
            ContactData fromEditForm = app.Contacts.GetContactInformationFromEditForm(index);

            // verification
            Assert.AreEqual(fromTable, fromEditForm);
            Assert.AreEqual(fromTable.Address, fromEditForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromEditForm.AllPhones);
        }

        [Test]
        public void ContactInformationTestDetailsPage()
        {
            int index = 0;
            ContactData fromEditForm = app.Contacts.GetContactInformationFromEditForm(index);
            string fromDetails = app.Contacts.GetContactInformationFromDetails(index);
            fromDetails = fromDetails.Replace("H: ", "").Replace("M: ", "").Replace("W: ", "").Replace("F: ", "");

            string compareTo = app.Contacts.GlueContactInformation(fromEditForm);

            // verification
            Assert.AreEqual(compareTo, fromDetails);
        }
    }
}
