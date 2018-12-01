using AdventOfCodeSolvings;
using NUnit.Framework;

namespace Tests
{
    public class FileLoaderTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LoadLinesFromFile_Test()
        {
            var result = FileLoader.LoadLinesFromFile("../../../../Data/test_input.txt");

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Hello", result[0]);
            Assert.AreEqual("World", result[1]);
        }
    }
}