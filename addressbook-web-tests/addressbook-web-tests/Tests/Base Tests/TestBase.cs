﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class TestBase
    {
        public static bool PERFORM_LONG_UI_CHECKS = false;

        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }
        public static Random rnd = new Random();
        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            char[] letters = "abcdefjhijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890~!@#$%^&*()-_=+".ToCharArray();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                //builder.Append(Convert.ToChar(33 + Convert.ToInt32(rnd.NextDouble() * 65)));
                builder.Append(letters[rnd.Next(letters.Length)]);

            }

            return builder.ToString();
        }

        public static string GenerateRandomNumber(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(48 + Convert.ToInt32(rnd.NextDouble() * 9)));
            }

            return builder.ToString();
        }
    }
}
