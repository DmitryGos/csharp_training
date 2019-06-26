using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : GroupTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(TestContext.CurrentContext.TestDirectory + @"\groups.csv");

            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }

            return groups;
        }
        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            return (List<GroupData>)
                new XmlSerializer(typeof(List<GroupData>))
                .Deserialize(new StreamReader(TestContext.CurrentContext.TestDirectory + @"\groups.xml"));
        }
        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(
                File.ReadAllText(TestContext.CurrentContext.TestDirectory + @"\groups.json"));
        }
        public static IEnumerable<GroupData> GroupDataFromExcelFile()
        {
            List<GroupData> groups = new List<GroupData>();
            //string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "groups.xlsx");

            Excel.Application app = new Excel.Application
            {
                Visible = true
            };
            Excel.Workbook wb = app.Workbooks.Open(TestContext.CurrentContext.TestDirectory + @"\groups.xlsx");
            Excel.Worksheet sheet = wb.ActiveSheet;

            Excel.Range range = sheet.UsedRange;
            for (int i = 1; i <= range.Count; i++)
            {
                groups.Add(new GroupData()
                {
                    Name = range.Cells[i, 1].Value,
                    Header = range.Cells[i, 2].Value,
                    Footer = range.Cells[i, 3].Value,
                });
            }
            wb.Close();
            app.Visible = false;
            app.Quit();
            return groups;
        }

        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void GroupCreationTest(GroupData group)
        {
            //Генерируем данные для новой группы
            //group = app.Groups.GenerateGroupData();

            //Считываем текущий список групп
            List<GroupData> oldGroups = GroupData.GetAll();

            app.Groups.Create(group);

            //Считываем новый список групп
            List<GroupData> newGroups = GroupData.GetAll();

            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count());

            //Добавляем данные новой группы в старый список
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void BadNameGroupCreationTest()
        {
            //Генерируем данные для новой группы
            GroupData group = new GroupData("a'a")
            {
                Header = "",
                Footer = ""
            };

            //Считываем текущий список групп
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupsCount());

            //Считываем новый список групп
            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void TestDBConnectivity()
        {
            foreach (ContactData contact in ContactData.GetAll())
            {
                System.Console.Out.WriteLine("Contact: " + contact + "\nGroups:");
                foreach (GroupData group in contact.GetGroups())
                {
                    System.Console.Out.WriteLine("--" + group.Name);
                }
                System.Console.Out.WriteLine("");
            }
        }
    }
}

