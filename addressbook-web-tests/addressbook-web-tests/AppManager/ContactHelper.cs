using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

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

            return this;
        }
        public ContactData GenerateContactData()
        {
            int rnd = new Random().Next(1, 50);
            ContactData contact = new ContactData("Uname" + rnd, "Ulastname" + rnd);

            return contact;
        }
        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GotoContactsPage();

            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name = entry]"));

            foreach (IWebElement element in elements)
            {
                var lastName = element.FindElement(By.XPath(".//td[2]"));
                var firstName = element.FindElement(By.XPath(".//td[3]"));
                contacts.Add(new ContactData(firstName.Text, lastName.Text){
                    Id = element.FindElement(By.TagName("input")).GetAttribute("id")
                });
            }

            return contacts;
        }
        public int GeContactsCount()
        {
            return driver.FindElements(By.CssSelector("tr[name = entry]")).Count;
        }

        public ContactHelper Modify(int id, ContactData newData)
        {
            manager.Navigator.GotoContactsPage();

            InitContactModification(id);
            FillContactForm(newData);
            ConfirmContactModification();
            manager.Navigator.GotoHomePage();

            return this;
        }
        public ContactHelper Remove(int index)
        {
            manager.Navigator.GotoContactsPage();

            SelectContact(index);
            DeleteSelectedAccount();
            ConfirmContactRemoval();

            Thread.Sleep(1000);

            return this;
        }
        public bool DoesTheContactExist(int index)
        {
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
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (index + 1) + "]")).Click();
            return this;
        }
        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);

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
    }
}
