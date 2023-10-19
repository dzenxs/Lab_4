using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lab_4;
using System.Numerics;

namespace UnitTestLab_4
{
    [TestClass]
    public class MyNumberTest
    {
        [TestMethod]
        public void TestMyFracAPlusBSquare()
        {
            MyFrac a = new MyFrac(new BigInteger(1), new BigInteger(3));
            MyFrac b = new MyFrac(new BigInteger(1), new BigInteger(6));

            MyFrac aPlusB = a.Add(b);
            MyFrac result = aPlusB.Multiply(aPlusB);

            MyFrac twoTimesAB = a.Multiply(b).Multiply(new MyFrac(new BigInteger(2), new BigInteger(1)));
            MyFrac expected = a.Multiply(a).Add(twoTimesAB).Add(b.Multiply(b));

            Assert.AreEqual(expected.ToString(), result.ToString());
        }


        [TestMethod]
        public void TestMyComplexAPlusBSquare()
        {
            MyComplex a = new MyComplex(1, 3);
            MyComplex b = new MyComplex(1, 6);

            MyComplex aPlusB = a.Add(b);
            MyComplex result = aPlusB.Multiply(aPlusB);
            MyComplex expected = a.Multiply(a).Add(a.Multiply(b).Multiply(new MyComplex(2, 0))).Add(b.Multiply(b));



            Assert.AreEqual(expected.ToString(), result.ToString());
        }
        [TestMethod]
        public void TestMyFracSquaresDifference()
        {
            MyFrac a = new MyFrac(new BigInteger(3), new BigInteger(2));
            MyFrac b = new MyFrac(new BigInteger(1), new BigInteger(2));

            MyFrac diff = a.Subtract(b);
            MyFrac result = a.Multiply(a).Subtract(b.Multiply(b)).Divide(a.Add(b));

            Console.WriteLine("(a - b) = " + diff);
            Console.WriteLine("(a^2 - b^2) / (a + b) = " + result);

            Assert.AreEqual(diff.ToString(), result.ToString());
        }
        [TestMethod]
        public void TestMyComplexSquaresDifference()
        {
            MyComplex a = new MyComplex(3, 2);
            MyComplex b = new MyComplex(1, 2);

            MyComplex diff = a.Subtract(b);
            MyComplex result = a.Multiply(a).Subtract(b.Multiply(b)).Divide(a.Add(b));

            Console.WriteLine("(a - b) = " + diff);
            Console.WriteLine("(a^2 - b^2) / (a + b) = " + result);

            Assert.AreEqual(diff.ToString(), result.ToString());
        }

        [TestMethod]
        public void TestMyComplexDivideByZeroException()
        {
            MyComplex a = new MyComplex(3, 2);
            MyComplex b = new MyComplex(0, 0);

            try
            {
                MyComplex result = a.Divide(b);
                Assert.Fail("Expected DivideByZeroException was not thrown.");
            }
            catch (DivideByZeroException)
            {

            }
        }
        [TestMethod]
        public void CompareToReturnsNegative()
        {
            MyFrac frac1 = new MyFrac(1, 2);
            MyFrac frac2 = new MyFrac(3, 4);

            int result = frac1.CompareTo(frac2);

            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void CompareToReturnsZero()
        {
            MyFrac frac1 = new MyFrac(1, 2);
            MyFrac frac2 = new MyFrac(1, 2);

            int result = frac1.CompareTo(frac2);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CompareToReturnsPositive()
        {
            MyFrac frac1 = new MyFrac(3, 4);
            MyFrac frac2 = new MyFrac(1, 2);

            int result = frac1.CompareTo(frac2);

            Assert.IsTrue(result > 0);
        }
    }

}

