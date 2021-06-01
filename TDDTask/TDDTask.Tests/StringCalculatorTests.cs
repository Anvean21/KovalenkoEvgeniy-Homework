using NUnit.Framework;
using System;

namespace TDDTask.Tests
{
    public class Tests
    {
        readonly StringCalculator stringCalculator = new StringCalculator();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TDDTask_StringCalculator_Add_EmptyInputReturnZero()
        {
            var result = stringCalculator.Add(string.Empty);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void TDDTask_StringCalculator_Add_AnyQuantityOfNumbersWithDelimiter()
        {
            var result = stringCalculator.Add("1,2,3");
            Assert.AreEqual(6, result);
        }

        [Test]
        public void TDDTask_StringCalculator_Add_NumsWithDelimiterReturnValidResult()
        {
            var result = stringCalculator.Add("1\n2,3");
            Assert.AreEqual(6, result);
        }

        [Test]
        public void TDDTask_StringCalculator_Add_NumsWithCustomDelimeter()
        {
            var result = stringCalculator.Add("//;\n1;2;3");
            Assert.AreEqual(6, result);
        }

        [Test]
        public void TDDTask_StringCalculator_Add_NegativeNumberException()
        {
            Assert.AreEqual("negatives not allowed -2 -3",
                Assert.Catch(() => stringCalculator.Add("1,-2,-3")).Message);
        }

        [Test]
        public void TDDTask_StringCalculator_Add_CountOfCallingMethod()
        {
            stringCalculator.Add(string.Empty);
            stringCalculator.Add("1\n2,3");
            stringCalculator.Add("//;\n1;2;3");

            Assert.AreEqual(3, stringCalculator.GetCalledCount()-1);
        }

        [Test]
        public void TDDTask_StringCalculator_Add_SkipNumsOver1000()
        {
            var result = stringCalculator.Add("1,2,3,1001");
            Assert.AreEqual(6, result);
        }

        [Test]
        public void TDDTask_StringCalculator_Add_CustomDelimetrLenght()
        {
            var result = stringCalculator.Add("//***\n1***2***3");
            Assert.AreEqual(6, result);
        }

        [Test]
        public void TDDTask_StringCalculator_Add_FewDelimeters()
        {
            var result = stringCalculator.Add("//[*][%]\n1*2%3");
            Assert.AreEqual(6, result);
        }
    }
}