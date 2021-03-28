using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bunny_Race;
using System;

namespace Bunny_RaceUnitTest
{
    [TestClass]
    public class Bunny_RaceUnitTest
    {
        Punter[] myPunter = new Punter[3];
        Bunny[] myBunny = new Bunny[4];
        Property myProperty = new Property();

        [TestMethod]
        public void Punter()
        {
            int id = 2;
            int result = Convert.ToInt16(Factory.GetAPunter(id).PunterID);
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void Number()
        {
            int result = Factory.Number();
            Assert.IsTrue(result > 0 && result < 50);
        }
    }
}
