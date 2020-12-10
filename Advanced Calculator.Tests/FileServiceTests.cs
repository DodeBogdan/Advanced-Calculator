using System;
using System.IO;
using NUnit.Framework;

namespace Advanced_Calculator.Tests
{
    public class FileServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetFromFileFileDoesNotExistGetException()
        {
            //arrange
            var fileService = new FileService();

            //act
            try
            {
                var result = fileService.GetInputFromFile("randomPath");

                Assert.Fail("Expected exception was not thrown.");
            }
            catch (Exception ex)
            {
                //assert
                Assert.AreEqual(typeof(FileNotFoundException), ex.GetType());
            }
        }

        [Test]
        public void GetFromFileFileExists()
        {
            //arrange
            var fileService = new FileService();

            //act
            var result = fileService.GetInputFromFile(@"../../../../CalculatorInput.txt");

            Assert.NotNull((result));
        }
    }
}