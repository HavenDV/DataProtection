using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataProtectionLibrary.Tests
{
    [TestClass]
    public class PermutationsTests
    {
        [TestMethod]
        public void OneKeyTests()
        {
            BaseTest("ШИФРОВАНИЕ_ПЕРЕСТАНОВКОЙ", "ФНШОИАВР_СИЕЕЕРПНЙТВАОКО", "3-8-1-5-2-7-6-4"); // In labs ФНШОИАВР_СИЕЕЕРПННТВАОКО
            BaseTest("CТУКОВ_КОНСТАНТИН_МИХАЙЛОВИЧ", "ТОCУКВКС_ОНТННАТИ_ИЙМХАЛ", "2-5-1-3-4-6");
        }

        [TestMethod]
        public void TwoKeysTests()
        {
            BaseTest("ШИФРОВАНИЕ_ПЕРЕСТАНОВКОЙ", "ПСНОРЙЕРВАИК_ЕАНФОИЕОТШВ", "5-3-1-2-4-6", "4-2-3-1");
            BaseTest("CТУКОВ_КОНСТАНТИН_МИХАЙЛОВИЧ", "СУТМ_ЙИОCАНОХОНТН_ВАВТКИИКЛЧ", "2-5-1-3-4-6", "3-1-2-4");
        }

        private static void BaseTest(string text, string expected, string key1, string key2 = null)
        {
            var permutation = new Permutation(key1, key2);

            Assert.AreEqual(expected, permutation.Process(text));
        }
    }
}
