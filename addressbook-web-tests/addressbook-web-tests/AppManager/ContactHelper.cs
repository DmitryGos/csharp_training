using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;


namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager)
            : base(manager)
        {
        }
        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GotoContactAddingPage();
            FillContactForm(contact);
            ConfirmContactCreation();
            manager.Navigator.GotoHomePage();

            contactCache = null;

            return this;
        }

        internal void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GotoHomePage();
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => driver.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        internal void RemoveContactFromGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GotoHomePage();
            SelectGroupFilter(group.Name);
            SelectContact(contact.Id);
            CommitRemovingContactFromGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => driver.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        private void CommitRemovingContactFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        private void SelectGroupFilter(string groupName)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(groupName);
        }

        public void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }
        public void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }
        public void SelectContact(string id)
        {
            driver.FindElement(By.Id(id)).Click();
        }
        public void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }
        public ContactData GenerateContactData()
        {
            int rnd = new Random().Next(1, 50);
            ContactData contact = new ContactData("Uname" + rnd, "Ulastname" + rnd);

            return contact;
        }
        private List<ContactData> contactCache = null;
        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GotoContactsPage();

                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name = entry]"));

                foreach (IWebElement element in elements)
                {
                    var lastName = element.FindElement(By.XPath(".//td[2]"));
                    var firstName = element.FindElement(By.XPath(".//td[3]"));
                    contactCache.Add(new ContactData(firstName.Text, lastName.Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("id")
                    });
                }
            }
            return new List<ContactData>(contactCache);
        }
        public int GeContactsCount()
        {
            return driver.FindElements(By.CssSelector("tr[name = entry]")).Count;
        }

        public ContactHelper Modify(int index, ContactData newData)
        {
            manager.Navigator.GotoContactsPage();

            InitContactModification(index);
            FillContactForm(newData);
            ConfirmContactModification();
            manager.Navigator.GotoHomePage();

            contactCache = null;

            return this;
        }
        public ContactHelper Remove(int index)
        {
            manager.Navigator.GotoContactsPage();

            SelectContact(index);
            DeleteSelectedAccount();
            ConfirmContactRemoval();

            Thread.Sleep(1000);

            contactCache = null;

            return this;
        }
        public bool DoesTheContactExist(int index)
        {
            manager.Navigator.GotoHomePage();
            return IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]"));
        }
        public ContactHelper MakeSureAContactExists(int index)
        {
            if (!DoesTheContactExist(index))
            {
                ContactData contact = GenerateContactData();

                Create(contact);
                manager.Navigator.GotoContactsPage();
            }

            return this;
        }
        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();

            return this;
        }
        private void DeleteSelectedAccount()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
        }
        private void ConfirmContactRemoval()
        {
            driver.SwitchTo().Alert().Accept();
        }

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            return this;
        }
        public ContactHelper OpenContactDetailsForm(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
            return this;
        }
        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);

            if (contact.MiddleName != null)
            {
                Type(By.Name("middlename"), contact.MiddleName);
            }
            if (contact.NickName != null)
            {
                Type(By.Name("nickname"), contact.NickName);
            }
            if (contact.Address != null)
            {
                Type(By.Name("address"), contact.Address);
            }
            if (contact.HomePhone != null)
            {
                Type(By.Name("home"), contact.HomePhone);
            }
            if (contact.WorkPhone != null)
            {
                Type(By.Name("work"), contact.WorkPhone);
            }
            if (contact.MobilePhone != null)
            {
                Type(By.Name("mobile"), contact.MobilePhone);
            }
            if (contact.Email != null)
            {
                Type(By.Name("email"), contact.Email);
            }
            if (contact.Email2 != null)
            {
                Type(By.Name("email2"), contact.Email2);
            }
            if (contact.Email3 != null)
            {
                Type(By.Name("email3"), contact.Email3);
            }

            return this;
        }
        public ContactHelper ConfirmContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }
        public ContactHelper ConfirmContactModification()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])")).Click();
            return this;
        }
        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GotoHomePage();

            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));

            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName.Trim(), lastName.Trim())
            {
                Address = address.Trim(),
                AllEmails = allEmails.Trim(),
                AllPhones = allPhones.Trim()
            };
        }
        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GotoHomePage();
            InitContactModification(index);

            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string middlename = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName.Trim(), lastName.Trim())
            {
                MiddleName = middlename.Trim(),
                NickName = nickname.Trim(),
                Address = address.Trim(),
                HomePhone = homePhone.Trim(),
                MobilePhone = mobilePhone.Trim(),
                WorkPhone = workPhone.Trim(),
                Email = email.Trim(),
                Email2 = email2.Trim(),
                Email3 = email3.Trim()
            };
        }
        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GotoHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }
        public string GlueDataFromEditForm(ContactData data)
        {
            string gluedData = "";
            string fullName = (data.FirstName + " " + data.MiddleName + " " + data.LastName).Trim().Replace("  ", " ");
            string allPhones = data.AllPhones.Trim().Replace("\r\n\r\n", "\r\n");
            string allEmails = data.AllEmails.Trim().Replace("\r\n\r\n", "\r\n"); 

            if (fullName != "")
            {
                gluedData = fullName + "\r\n";
            }
            if (data.NickName != "")
            {
                gluedData = (gluedData + data.NickName).Trim() + "\r\n";
            }
            if (data.Address != "")
            {
                gluedData = (gluedData + data.Address).Trim() + "\r\n\r\n";
            }
            if (allPhones != "")
            {
                gluedData = (gluedData + allPhones).Trim() + "\r\n\r\n";
            }
            if (allEmails != "")
            {
                gluedData = (gluedData + allEmails).Trim();
            }

            return gluedData;
        }

        public string GetContactInformationFromDetailsForm(int index)
        {
            manager.Navigator.GotoHomePage();
            OpenContactDetailsForm(index);

            string allDetails = driver.FindElement(By.CssSelector("div#container")).FindElement(By.CssSelector("div#content")).Text
                .Trim()
                .Replace("H: ", "").Replace("W: ", "").Replace("M: ", "");

            return allDetails;
        }
    }
}
