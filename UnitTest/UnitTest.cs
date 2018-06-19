
using System;
using System.Collections.Generic;
using KommandoBogApp.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAfdelingToList()
        {
            Afdeling afdeling = new Afdeling("Test Afdeling", 3);

            User user = new User("12345","Frederik","42489902","Helsingevej 68","fwpdanmark@hotmail.com","123");

            afdeling.AddUserToList(user);

            CollectionAssert.Contains(afdeling.AfdelingList,user);


        }
    }
}
