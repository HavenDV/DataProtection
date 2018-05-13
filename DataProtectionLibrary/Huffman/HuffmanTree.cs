using System.Collections.Generic;

namespace DataProtectionLibrary.Huffman
{
    public static class HuffmanTree
    {
        public static BinaryTreeNode<CharFreq> Build(List<CharFreq> charFreq)
        {
            var queue = new PriorityQueue();

            for (var i = 0; i < charFreq.Count; i++)
            {
                queue.insert(new BinaryTreeNode<CharFreq>(charFreq[i]));
            }

            queue.buildHeap();

            for (var i = 0; i < charFreq.Count - 1; i++)
            {
                var x = queue.extractMin();
                var y = queue.extractMin();
                var chFreq = new CharFreq
                {
                    Ch = (char) (x.Value.Ch + y.Value.Ch),
                    Freq = x.Value.Freq + y.Value.Freq
                };

                queue.insert(new BinaryTreeNode<CharFreq>(chFreq)
                {
                    Left = x,
                    Right = y
                });
            }

            return queue.extractMin();
        }
    }
}