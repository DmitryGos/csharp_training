using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void UnitTest1()
        {
            int unixTime = 0;
            for (int i = 0; i < 10; i++)
            {
                unixTime = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds; ;
                System.Console.Out.WriteLine("Res " + i + ": " + unixTime);
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
