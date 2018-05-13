using System.Collections.Generic;
using System.Linq;
using DataProtectionLibrary.Huffman;

namespace DataProtectionLibrary
{
    public static class HuffmanUtilities
    {
        private static void InorderTraversal(BinaryTreeNode<CharFreq> node, string label, ref int leafNodes, ref string output)
        {
            if (node == null)
            {
                return;
            }

            InorderTraversal(node.Left, label + "0", ref leafNodes, ref output);

            if (node.Left == null && node.Right == null)
            {
                leafNodes++;
                node.Value.Label = label;
                output += $"'{node.Value.Ch}' {node.Value.Freq} {node.Value.Label}\r\n";
            }
            else
            {
                node.Value.Label = label;
                output += $" - '{node.Value.Ch}' {node.Value.Freq} {node.Value.Label}\r\n";
            }

            InorderTraversal(node.Right, label + "1", ref leafNodes, ref output);
        }

        public static string Process(string text)
        {
            var n = text.Length;
            var list = new List<CharFreq>();

            for (var i = 0; i < n; ++i)
            {
                var c = text[i];
                var element = list.FirstOrDefault(v => v.Ch == c);
                if (element != null)
                {
                    ++element.Freq;
                    continue;
                }

                list.Add(new CharFreq
                {
                    Ch = c,
                    Freq = 1
                });
            }

            var root = HuffmanTree.Build(list);

            var leafNodes = 0;
            var output = string.Empty;
            InorderTraversal(root, string.Empty, ref leafNodes, ref output);
            output += $"\r\n# characters = {n}\r\n";
            output += $"# leaf nodes = {leafNodes}\r\n";
            output += $"% compressed = {100.0 - 100.0 * leafNodes / n:F2}\r\n";

            return string.Concat(text.Select(c => list.FirstOrDefault(value => value.Ch == c)?.Label ?? string.Empty));
        }
    }
}
