using NUnit.Framework;

namespace Advanced_Calculator.Tests
{
    class TextConvertorTest
    {
        [TestCase("friendly")]
        [TestCase(":")]
        [TestCase("#")]
        [TestCase("@")]
        [TestCase("!")]
        [TestCase("%")]
        [TestCase(">")]
        [TestCase("<")]
        [TestCase(";")]
        [TestCase("\\")]
        public void CheckCharactersDoesContainsInvalidCharacters(string input)
        {
            //arrange
            var convertor = new TextConvertor();
            //act
            var result = convertor.CheckCharacters(input);
            //asset
            Assert.IsFalse(result);
        }

        [TestCase("4+5*2/1-6 +  23,.")]
        public void CheckCharactersDoesContainsOnlyValidCharacters(string input)
        {
            //arrange
            var convertor = new TextConvertor();
            //act
            var result = convertor.CheckCharacters(input);
            //asset
            Assert.IsTrue(result);
        }

        [TestCase("1+2")]
        [TestCase("1 + 2")]
        [TestCase("+ 1 + 2")]
        [TestCase("+1+2")]
        [TestCase("1+1+1")]
        [TestCase("1+1+1+0")]
        [TestCase("1.5+1.50")]
        [TestCase("-1.5+1.50")]
        [TestCase("3/-1")]
        public void CheckSequenceValidInputReturnTrue(string input)
        {
            //arrange
            var convertor = new TextConvertor();
            //act
            var result = convertor.CheckSequence(input);
            //asset
            Assert.IsTrue(result);
        }

        [TestCase("2,.3-1")]
        [TestCase("/23+1")]
        [TestCase("+.3-1")]
        public void CheckSequenceInvalidInputReturnFalse(string input)
        {
            //arrange
            var convertor = new TextConvertor();
            //act
            var result = convertor.CheckSequence(input);
            //asset
            Assert.IsFalse(result);
        }

        [TestCase("+ 1 + 2")]
        [TestCase("+1+2")]
        public void RemoveWhiteSpaces(string input)
        {
            //arrange
            var convertor = new TextConvertor();
            //act
            string result = convertor.RemoveWhiteSpaces(input);
            //asset
            Assert.AreEqual("+1+2", result);
        }
    }
}
