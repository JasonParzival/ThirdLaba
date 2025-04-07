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
            Assert.AreEqual("7", Length.AnyToDe("12AB", 16));
        }

        [TestMethod()]
        public void DeToAnyTest()
        {
            Length length;

            length = new Length("19", MeasureType.de);
            Assert.AreEqual("10011(2)", length.To(MeasureType.bi).Verbose());

            length = new Length("19", MeasureType.de);
            Assert.AreEqual("23(8)", length.To(MeasureType.oc).Verbose());

            length = new Length("19", MeasureType.de);
            Assert.AreEqual("13(16)", length.To(MeasureType.he).Verbose());
        }

        [TestMethod()]
        public void AnyToDeTest()
        {
            Length length;

            length = new Length("10011", MeasureType.bi);
            Assert.AreEqual("19(10)", length.To(MeasureType.de).Verbose());

            length = new Length("23", MeasureType.oc);
            Assert.AreEqual("19(10)", length.To(MeasureType.de).Verbose());

            length = new Length("13", MeasureType.he);
            Assert.AreEqual("19(10)", length.To(MeasureType.de).Verbose());
        }
    }
}