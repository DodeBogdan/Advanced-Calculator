using Moq;
using NUnit.Framework;

namespace Advanced_Calculator.Tests
{
    class CalculatorTests
    {
        private Mock<IFileService> _fileServiceMock;
        private Mock<ITextConvertor> _textConvertorMock;

        [TestCase("1+2")]
        [TestCase("1 + 2")]
        [TestCase("+ 1 + 2")]
        [TestCase("+1+2")]
        [TestCase("1+1+1")]
        [TestCase("1+1+1+0")]
        [TestCase("1.5+1.50")]
        public void CalculateGiveGoodResult(string input)
        {
            _fileServiceMock = new Mock<IFileService>();
            _textConvertorMock = new Mock<ITextConvertor>();

            _fileServiceMock.Setup(x => x.GetInputFromFile(It.IsAny<string>()))
                .Returns(input);
            _textConvertorMock.Setup(x => x.CheckCharacters(It.IsAny<string>()))
                .Returns(true);
            _textConvertorMock.Setup(x => x.CheckSequence(It.IsAny<string>()))
                .Returns(true);
            _textConvertorMock.Setup(x => x.RemoveWhiteSpaces(input))
                .Returns(input.Replace(" ", ""));

            Calculator calculator = new Calculator(_textConvertorMock.Object);
            var result = calculator.Calculate("", _fileServiceMock.Object);

            Assert.AreEqual(3,result);
        }
    }
}
