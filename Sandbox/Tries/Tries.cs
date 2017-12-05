using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Tries
{
    /// <summary>
    /// Are you building something akin to a spell-checker? You may be in luck here!
    /// These may be useful for other stuff, Idk???
    /// I doubt you'll ever be asked to write one of these from scratch for a job interview, it takes half an hour to write the requisite methods as is...?
    /// If you get asked to do all of it... godspeed bro...
    /// </summary>
    public class Tries
    {
        private TrieNode root = new TrieNode();

        public TrieNode Insert(string s)
        {
            char[] charArray = s.ToLower().ToCharArray();
            TrieNode node = root;
            //root.WordCount++;
            foreach (char c in charArray)
            {
                node.WordCount++;
                node = Insert(c, node);

            }
            node.isEnd = true;
            return root;
        }

        private TrieNode Insert(char c, TrieNode node)
        {
            if (node.Contains(c)) return node.GetChild(c);
            else
            {
                int n = Convert.ToByte(c) - TrieNode.ASCIIA;
                TrieNode t = new TrieNode();
                //t.WordCount = 1;
                node.nodes[n] = t;
                return t;
            }
        }

        public bool Contains(string s)
        {
            char[] charArray = s.ToLower().ToCharArray();
            TrieNode node = root;
            bool contains = true;
            foreach (char c in charArray)
            {
                node = Contains(c, node);
                if (node == null)
                {
                    contains = false;
                    break;
                }
            }
            if ((node == null) || (!node.isEnd))
                contains = false;
            return contains;
        }

        public int Count(string s)
        {
            char[] charArray = s.ToLower().ToCharArray();
            TrieNode node = root;
            int count = 0;
            foreach (char c in charArray)
            {
                node = Contains(c, node);
                if (node == null)
                {
                    return 0;
                }
            }
            if (node.isEnd)
                return node.WordCount + 1;
            else
                return node.WordCount;
        }

        private TrieNode Contains(char c, TrieNode node)
        {
            if (node.Contains(c))
            {
                return node.GetChild(c);
            }
            else
            {
                return null;
            }
        }
    }
}
