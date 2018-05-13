using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataProtectionLibrary.Tests
{
    [TestClass]
    public class ReplacementTests
    {
        [TestMethod]
        public void VizhinerTests()
        {
            BaseVizhinerTest("ЗАМЕНА", "ТМКЭШМ", "КЛЮЧ");
            BaseVizhinerTest("СТУКОВ", "ЬААЬАГ", "КОНСТАНТИН");
        }

        [TestMethod]
        public void BeaufortTests()
        {
            BaseBeaufortTest("СТУКОВ", "ЖГЕЩЬБ", "КОНСТАНТИН");
        }

        private static void BaseVizhinerTest(string text, string expected, string key)
        {
            var replacement = new VizhinerReplacement(key);

            Assert.AreEqual(expected, replacement.Process(text));
        }

        private static void BaseBeaufortTest(string text, string expected, string key)
        {
            var replacement = new BeaufortReplacement(key);

            Assert.AreEqual(expected, replacement.Process(text));
        }
    }
}
