using System;
using System.Collections.Generic;

namespace HW10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("abcba is palindrome: " + IsPalindrome("abcba"));
            Console.WriteLine("cat is palindrome: " + IsPalindrome("cat"));

            Console.WriteLine(IsSubsequence("hac", "cathartic"));
            Console.WriteLine(IsSubsequence("bat", "table"));

            KSubsets(new List<string> { "a", "b", "c" }, 2);
        }
        // Recursive problem #4

        static bool IsPalindrome(string s)
        {
            // Your code goes here
            if (s.Length == 1) return true;
            if (s.Length == 2 && s[0] == s[1])
            {
                return true;
            } else if (s.Length == 2)
            {
                return false;
            }
            if (s[0] != s[s.Length-1])
            {
                return false;
            }
            return IsPalindrome(s.Substring(1, s.Length - 2));
        }

        
        // Recursive problem #6

        static bool IsSubsequence(string s1, string s2)
        {
            // Your code goes here
            string newS1 = s1;
            string newS2 = s2;

            if (newS1 == "" && newS2 == "") return true;
            if (newS1 != "" && newS2 == "") return false;
            if (newS1[0] == newS2[0]) return IsSubsequence(newS1.Substring(1), newS2.Substring(1));
            return IsSubsequence(newS1, newS2.Substring(1));
        }


        // Recursive problem #9

        static void KSubsets(List<string> ls, int k, List<string> mustInclude)
        {
            // Your code goes here
            if (ls.Count == 0 && mustInclude.Count == k)
            {
                PrintList(mustInclude);
                return;
            } else if (ls.Count == 0)
            {
                return;
            }
            var newList = new List<string>(ls);
            var newMust = new List<string>(mustInclude);
            string s = newList[0];
            newList.RemoveAt(0);
            KSubsets(newList, k, newMust);
            newMust.Add(s);
            KSubsets(newList, k, newMust);
        }
        static void KSubsets(List<string> ls, int k)
        {
            var mustInclude = new List<string> { };
            KSubsets(ls, k, mustInclude);
        }

        private static void PrintList(List<string> list)
        {
            Console.Write("{ ");
            foreach (string s in list)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine("}");
        }
    }
}
