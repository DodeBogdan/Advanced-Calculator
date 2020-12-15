using System;
using Moq;
using NUnit.Framework;

namespace Advanced_Calculator.Tests
{
    class CalculatorTests
    {
        private Mock<IFileService> _fileServiceMock;
        private Mock<ITextConvertor> _textConvertorMock;
        private Calculator calculator;

        [SetUp]
        public void Setup()
        {
            _fileServiceMock = new Mock<IFileService>();
            _textConvertorMock = new Mock<ITextConvertor>();

            _textConvertorMock.Setup(x => x.CheckCharacters(It.IsAny<string>()))
                .Returns(true);
            _textConvertorMock.Setup(x => x.CheckSequence(It.IsAny<string>()))
                .Returns(true);

            calculator = new Calculator(_textConvertorMock.Object);
        }

        [TestCase(3, "1+2")]
        [TestCase(3, "1 + 2")]
        [TestCase(3, "+ 1 + 2")]
        [TestCase(3, "+1+2")]
        [TestCase(3, "1+1+1")]
        [TestCase(3, "1+1+1+0")]
        [TestCase(3, "1.5+1.50")]
        [TestCase(0, "1+2-3")]
        [TestCase(4, "1+2-3+4")]
        [TestCase(-1.5, "1-10+5*3/2")]
        public void CalculateGiveGoodResult(double expected, string input)
        {
            _fileServiceMock.Setup(x => x.GetInputFromFile(It.IsAny<string>()))
                .Returns(input);
            _textConvertorMock.Setup(x => x.RemoveWhiteSpaces(input))
                .Returns(input.Replace(" ", ""));

            var result = calculator.Calculate("", _fileServiceMock.Object);

            Assert.AreEqual(expected, result);
        }

        [TestCase("1.5+1.50/0")]
        public void CalculatorZero(string input)
        {
            _fileServiceMock.Setup(x => x.GetInputFromFile(It.IsAny<string>()))
                .Returns(input);
            _textConvertorMock.Setup(x => x.RemoveWhiteSpaces(input))
                .Returns(input.Replace(" ", ""));

            try
            {
                calculator.Calculate("", _fileServiceMock.Object);

                Assert.Fail("Should not be considered valid");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(DivideByZeroException), ex.GetType());
            }
        }
    }
}
