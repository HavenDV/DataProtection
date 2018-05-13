using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataProtectionLibrary.Tests
{
    [TestClass]
    public class SubstitutionTests
    {
        [TestMethod]
        public void Tests()
        {
            BaseTest("СТУКОВ КОНСТАНТИН", "ТУФНВМУМПТРЛПУБШ", "МИХАЙЛОВИЧ");
        }

        private static void BaseTest(string text, string expected, string key)
        {
            var substitution = new Substitution(key);

            Assert.AreEqual(expected, substitution.Process(text));
        }
    }
}
