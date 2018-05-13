using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataProtectionLibrary.Tests
{
    [TestClass]
    public class HuffmanTests
    {
        [TestMethod]
        public void Tests()
        {
            BaseTest("СТУКОВ КОНСТАНТИН", "ТУФНВМУМПТРЛПУБШ");
        }

        private static void BaseTest(string text, string expected)
        {
            Assert.AreEqual(expected, Huffman.Process(text));
        }
    }
}
