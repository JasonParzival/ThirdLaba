﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var length = new Length("38", MeasureType.de);
            Assert.AreEqual("38(10)", length.Verbose());

            length = new Length("38", MeasureType.bi);
            Assert.AreEqual("38(2)", length.Verbose());

            length = new Length("38", MeasureType.oc);
            Assert.AreEqual("38(8)", length.Verbose());

            length = new Length("38", MeasureType.he);
            Assert.AreEqual("38(16)", length.Verbose());
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

        [TestMethod()]
        public void AddNumberTest()
        {
            var length = new Length("7", MeasureType.oc);
            length = length + 1;
            Assert.AreEqual("10(8)", length.Verbose());
        }

        [TestMethod()]
        public void SubNumberTest()
        {
            var length = new Length("22", MeasureType.de);
            length = length - 1;
            Assert.AreEqual("21(10)", length.Verbose());
        }

        [TestMethod()]
        public void MulByNumberTest()
        {
            var length = new Length("22", MeasureType.de);
            length = length * 2;
            Assert.AreEqual("44(10)", length.Verbose());
        }

        [TestMethod()]
        public void DivByNumberTest()
        {
            var length = new Length("22", MeasureType.de);
            length = length / 2;
            Assert.AreEqual("11(10)", length.Verbose());
        }

        [TestMethod()]
        public void DivByNumberValueTest()
        {
            var length = new Length("22", MeasureType.de);
            length = length / 2;
            Assert.AreEqual("11", length.GetValue());
        }

        [TestMethod()]
        public void AddDeBiTest()
        {
            var de = new Length("7", MeasureType.de);
            var bi = new Length("111", MeasureType.bi);

            Assert.AreEqual("14(10)", (de + bi).Verbose());
            Assert.AreEqual("1110(2)", (bi + de).Verbose());
        }

        [TestMethod()]
        public void SubDeBiTest()
        {
            var de = new Length("7", MeasureType.de);
            var bi = new Length("111", MeasureType.bi);

            Assert.AreEqual("0(2)", (bi - de).Verbose());
            Assert.AreEqual("0(10)", (de - bi).Verbose());
        }

        [TestMethod()]
        public void AddDeOcHeTest()
        {
            var de = new Length("7", MeasureType.de);
            var oc = new Length("7", MeasureType.oc);
            var he = new Length("7", MeasureType.he);

            Assert.AreEqual("16(8)", (oc + de).Verbose());
            Assert.AreEqual("E(16)", (he + de).Verbose());
        }

        [TestMethod()]
        public void OtherSubDeBiTest()
        {
            var de = new Length("5", MeasureType.de);
            var bi = new Length("111", MeasureType.bi);

            Assert.AreEqual("10(2)", (bi - de).Verbose());
        }
    }
}