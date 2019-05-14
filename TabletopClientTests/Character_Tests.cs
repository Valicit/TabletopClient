using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TabletopClient;
using TabletopClient.Controllers;

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

        [TestMethod]
        public void Character_Exp_String_Parsed_Correctly()
        {
            //Arrange
            CharaController testChara = new CharaController(0);
            string test1 = "1000";
            string[] result1 = new string[] { "1000" };
            string test2 = "500,500";
            string[] result2 = new string[] { "500", "500" };

            //Act
            string[] actual1 = testChara.GetClassExp(test1);
            string[] actual2 = testChara.GetClassExp(test2);

            //Assert
            Assert.AreEqual(result1[0], actual1[0]);
            Assert.AreEqual(result2[0], actual2[0]);
            Assert.AreEqual(result1.Length, actual1.Length);
            Assert.AreEqual(result2.Length, actual2.Length);
            Assert.AreEqual(Convert.ToInt32(result1[0]), 1000);
        }

        [TestMethod]
        public void Character_Level_Calculated_Correctly()
        {
            //Arrange
            int[] expValues = new int[] { 2, 150, 800, 2250, 4800, 8750, 14400, 22050, 32000, 44550, 56664 };
            int[] levelValues = new int[] { 1, 10, 20, 30, 40, 50, 60, 70, 80, 90, 98 };

            //Act
            int[] actualLevels = new int[expValues.Length];
            for (int i = 0; i < expValues.Length; i++)
            {
                actualLevels[i] = ClassController.GetExpToNext(levelValues[i]);
            }

            //Assert
            for (int i = 0; i < levelValues.Length; i++)
            {
                Assert.AreEqual(expValues[i], actualLevels[i], 1);
            }
        }
    }
}
