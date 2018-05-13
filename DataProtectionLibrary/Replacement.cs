using System;
using System.Linq;

namespace DataProtectionLibrary
{
    public class VizhinerReplacement : BaseReplacement
    {
        public VizhinerReplacement(string key) : base(key, (x, k, n) => (x + k % n) % n)
        {
        }
    }

    public class BeaufortReplacement : BaseReplacement
    {
        public BeaufortReplacement(string key) : base(key, (x, k, n) => (x - k % n + n) % n)
        {
        }
    }

    public class BaseReplacement
    {
        private string Key { get; }
        private Func<int, int, int, int> Func { get; }

        protected BaseReplacement(string key, Func<int, int, int, int> func)
        {
            Key = key ?? throw new ArgumentNullException(nameof(key));
            Func = func ?? throw new ArgumentNullException(nameof(func));
        }

        public string Process(string text) => 
            new string(text.Select((c, i) => (char)(Func(c - 'А' + 1, Key[i % Key.Length] - 'А' + 1, 33) + 'А' - 1)).ToArray());
    }
}
