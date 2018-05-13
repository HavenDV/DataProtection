using System;
using System.Collections.Generic;
using System.Linq;

namespace DataProtectionLibrary
{
    public class Substitution
    {
        private string Key { get; }
        private Dictionary<(int, int), char> Matrix { get; }
        private int RowCount { get; } = 4;
        private int ColumnCount { get; } = 8;

        public Substitution(string key)
        {
            Key = key ?? throw new ArgumentNullException(nameof(key));
            Matrix = CreateMatrix(Key);
        }

        public string Process(string text)
        {
            text = text.Replace(" ", string.Empty).Substring(0, 2 * (text.Length / 2));

            var bigrams = new List<string>();
            for (var i = 0; i < text.Length / 2; ++i)
            {
                bigrams.Add(text.Substring(2 * i, 2));
            }

            foreach (var bigram in bigrams)
            {
                Console.WriteLine($"{bigram}: {ProcessBigram(bigram)}");
            }
            
            return string.Concat(bigrams.Select(ProcessBigram));
        }

        private string ProcessBigram(string text)
        {
            var first = text[0];
            var second = text[1];
            var firstPosition = GetPosition(first);
            var secondPosition = GetPosition(second);

            // If rows are equal
            if (firstPosition.Item1 == secondPosition.Item1)
            {
                return $"{GetRowsEqualValue(firstPosition)}{GetRowsEqualValue(secondPosition)}";
            }

            // If columns are equal
            if (firstPosition.Item2 == secondPosition.Item2)
            {
                return $"{GetColumnsEqualValue(firstPosition)}{GetColumnsEqualValue(secondPosition)}";
            }

            return $"{GetRectangleValue(firstPosition, secondPosition)}{GetRectangleValue(secondPosition, firstPosition)}";
        }

        private (int, int) GetPosition(char value) => Matrix.FirstOrDefault(i => i.Value == value).Key;
        private char GetRowsEqualValue((int, int) position) =>
            position.Item2 + 1 < ColumnCount ? Matrix[(position.Item1, position.Item2 + 1)] : Matrix[(position.Item1, 0)];
        private char GetColumnsEqualValue((int, int) position) =>
            position.Item1 + 1 < RowCount ? Matrix[(position.Item1 + 1, position.Item2)] : Matrix[(0, position.Item2)];
        private char GetRectangleValue((int, int) position1, (int, int) position2) =>
            Matrix[(position1.Item1, position2.Item2)];

        private Dictionary<(int, int), char> CreateMatrix(string key)
        {
            var keyChars = key.Distinct().ToList();
            var alphabetChars = Enumerable.Range(0, 33).Select(i => (char) ('А' + i)).Except(keyChars).Except(new []{'Ъ'}).ToList();
            alphabetChars.Insert(alphabetChars.IndexOf('Е') + 1, 'Ё');
            var matrixValues = keyChars.Concat(alphabetChars).ToList();

            var matrix = new Dictionary<(int, int), char>();
            for (var i = 0; i < RowCount; i++)
            {
                for (var j = 0; j < ColumnCount; j++)
                {
                    matrix[(i, j)] = matrixValues.ElementAt(i * ColumnCount + j);
                }
            }

            return matrix;
        }
    }
}
