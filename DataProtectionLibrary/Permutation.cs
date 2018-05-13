using System;
using System.Collections.Generic;
using System.Linq;

namespace DataProtectionLibrary
{
    public class Permutation
    {
        private string Key1 { get; }
        private string Key2 { get; }

        private List<int> Key1List { get; }
        private List<int> Key2List { get; }

        public Permutation(string key1, string key2 = null)
        {
            Key1 = key1 ?? throw new ArgumentNullException(nameof(key1));
            Key2 = key2;

            Key1List = ExtractKey(Key1);
            Key2List = ExtractKey(Key2);
        }

        public string Process(string text)
        {
            if (string.IsNullOrWhiteSpace(Key2))
            {
                return ProcessOneKey(text);
            }

            return ProcessTwoKeys(text);
        }

        private string ProcessOneKey(string text)
        {
            var result = string.Empty;
            foreach (var part in SplitText(text, Key1List.Count))
            {
                result += new string(Key1List.Select(i => part[i - 1]).ToArray());
            }

            return result;
        }

        private string ProcessTwoKeys(string text)
        {
            text = text.Substring(0, Key2List.Count * (text.Length / Key2List.Count));
            
            // Creating table
            var parts1 = SplitText(text, text.Length / Key1List.Count);
            var tableDictionary = new Dictionary<int, string>();
            for (var i = 0; i < parts1.Count; ++i)
            {
                var keyIndex = Key1List[i % Key1List.Count] - 1;
                tableDictionary[keyIndex + Key1List.Count * (i / Key1List.Count)] = parts1[i];
            }
            var table = string.Concat(tableDictionary.OrderBy(i => i.Key).Select(i => i.Value));

            // Reading
            var length = table.Length / Key2List.Count;
            var count = table.Length / length;
            var parts2 = new List<string>();
            for (var i = 0; i < count; ++i)
            {
                var part = string.Empty;
                for (var j = 0; j < length; j++)
                {
                    var c = table[j * count + i];
                    part += c;
                }

                parts2.Add(part);
            }

            return string.Concat(Key2List.Select(i => parts2[i - 1]));
        }

        private static List<int> ExtractKey(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return new List<int>();
            }

            text = text.Replace("-", string.Empty);

            return text.Select(i => int.TryParse(i.ToString(), out var result) ? result : 0).ToList();
        }

        private static List<string> SplitText(string text, int count)
        {
            var list = new List<string>();
            for (var i = 0; i < text.Length / count; ++i)
            {
                list.Add(text.Substring(i * count, count));
            }

            return list;
        }
    }
}
