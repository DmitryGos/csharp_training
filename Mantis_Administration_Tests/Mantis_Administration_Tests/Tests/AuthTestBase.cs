﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MantisAdministrationTests
{
    public class AuthTestBase : TestBase 
    {
        [SetUp]
        public void SetupLogin()
        {
            app.Auth.Login(new AccountData()
            {
                Username = "administrator",
                Password = "root"
            });
        }
    }
}
