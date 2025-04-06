using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThirdLaba;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ThirdLaba.Tests
{
    [TestClass()]
    public class LengthTests
    {
        [TestMethod()]
        public void VerboseTest()
        {
            //int CoolValue = int.Parse("-5");
            //Length.DeToAny("-5", 2)
            Assert.AreEqual("-5", Length.DeToAny("5.5", 2));
        }
    }
}