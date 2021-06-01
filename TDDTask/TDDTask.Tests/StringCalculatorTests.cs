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
            var testInput = string.Empty;

            var result = stringCalculator.Add(testInput);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void TDDTask_StringCalculator_Add_AnyQuantityOfNumbersWithDelimiterReturnNumbersSum()
        {
            var testInput = "1,2,3";

            var result = stringCalculator.Add(testInput);

            Assert.AreEqual(6, result);
        }

        [Test]
        public void TDDTask_StringCalculator_Add_NumbersWithTwoDelimitersReturnSumOfNumbers()
        {
            var testInput = "1\n2,3";

            var result = stringCalculator.Add(testInput);

            Assert.AreEqual(6, result);
        }

        [Test]
        public void TDDTask_StringCalculator_Add_ReturnNumbersSumWithCustomDelimiter()
        {
            var testInput = "//;\n1;2;3";

            var result = stringCalculator.Add(testInput);

            Assert.AreEqual(6, result);
        }

        [Test]
        public void TDDTask_StringCalculator_Add_ReturnExceptionIfNumsAreNegative()
        {
            var testInput = "1,-2,-3";

            var exceptionMessage = Assert.Catch(() => stringCalculator.Add(testInput)).Message;

            Assert.AreEqual("negatives not allowed -2 -3", exceptionMessage);
        }

        [Test]
        public void TDDTask_StringCalculator_Add_ReturnCountOfCallingMethod()
        {
            var testInput = string.Empty;
            var testInput2 = "1\n2,3";
            var testInput3 = "//;1\n2,3";

            stringCalculator.Add(testInput);
            stringCalculator.Add(testInput2);
            stringCalculator.Add(testInput3);

            Assert.AreEqual(3, stringCalculator.GetCalledCount());
        }

        [Test]
        public void TDDTask_StringCalculator_Add_ReturnSumOfNumbersAndSkipNumbersOver1000()
        {
            var testInput = "1,2,3,1001";

            var result = stringCalculator.Add(testInput);

            Assert.AreEqual(6, result);
        }

        [Test]
        public void TDDTask_StringCalculator_Add_ReturnSumOfNumbersWithCustomDelimiterLenght()
        {
            var testInput = "//***\n1***2***3";

            var result = stringCalculator.Add(testInput);

            Assert.AreEqual(6, result);
        }

        [Test]
        public void TDDTask_StringCalculator_Add_ReturnSumOfNumbersWithFewDelimiters()
        {
            var testInput = "//[*][%]\n1*2%3";

            var result = stringCalculator.Add(testInput);

            Assert.AreEqual(6, result);
        }
        [Test]
        public void TDDTask_StringCalculator_Add_ReturnSumOfNumbersWithFewDelimitersWithCustomLenght()
        {
            var testInput = "//[***][%%]\n1***2%%3";

            var result = stringCalculator.Add(testInput);

            Assert.AreEqual(6, result);
        }
    }
}