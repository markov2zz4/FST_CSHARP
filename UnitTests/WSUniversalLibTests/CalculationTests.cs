using Microsoft.VisualStudio.TestTools.UnitTesting;
using WSUniversalLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace WSUniversalLib.Tests
{
    [TestClass()]
    public class CalculationTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod()]
        public void GetQuantityForProduct_count15_producttype3_width20_length45_materialtype1_114148returned()
        {
            //arrange
            Calculation calculation = new Calculation(3, 1, 15, 20, 45);
            int excepted = 114148;
            //act
            int actual = calculation.GetQuantityForProduct();

            TestContext.WriteLine("End testing");
            //assert
            Assert.AreEqual(excepted, actual);

            

        }

        [TestMethod()]
        public void GetQuantityForProduct_count15_producttype4_width20_length45_materialtype1_minus1returned()
        {
            //arrange
            Calculation calculation = new Calculation(4, 1, 15, 20, 45);
            int excepted = -1;
            //act
            int actual = calculation.GetQuantityForProduct();

            //assert
            Assert.AreEqual(excepted, actual);

        }
    }
}