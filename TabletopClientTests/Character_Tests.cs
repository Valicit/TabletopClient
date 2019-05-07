using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TabletopClient;

namespace TabletopClientTests
{
    [TestClass]
    public class Character_Tests
    {
        [TestMethod]
        public void Database_Access_Established()
        {
            //Arrange
            string num = "L'lai";
            string actual;

            //act
            using (var context = new TabletopEntities())
            {
                actual = context.Characters.First().name;
            }

            //assert
            Assert.AreEqual(num, actual);
        }
    }
}
