using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split(new char[] {',','?','.','!',' '},StringSplitOptions.RemoveEmptyEntries).ToArray();
            List<string> palindromes = new List<string>();

            foreach (var word in words)
            {
                if (isPalindrome(word))
                    palindromes.Add(word);
            }

            palindromes.Sort();

            Console.WriteLine("[" + String.Join(", ", palindromes) + "]");
        }

        private static bool isPalindrome(string word)
        {
            for (int i = 0, j = word.Length - 1; i < word.Length / 2; i++, j--)
            {
                if (word[i] != word[j])
                    return false;
            }

            return true;
        }
    }
}
