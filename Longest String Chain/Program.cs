using System;
using System.Collections.Generic;
using System.Text;

namespace Longest_String_Chain
{
  class Program
  {
    static void Main(string[] args)
    {
      var words = new string[] { "xbc", "pcxbcf", "xb", "cxbc", "pcxbc" };
      Solution s = new Solution();
      s.LongestStrChain(words);
    }
  }

  public class Solution
  {
    public int LongestStrChain(string[] words)
    {
      // We have to start from the smallest length word and we will try to check by removing one char at a time from the word
      // We will have a Dictionary<string, count> , this would help us to memorization
      // After removing a char from a word if we find the word is present in the dictionary then we can increment the count


      // Step 1 - Sorting O(N logN)

      Array.Sort(words, (a, b) => { return a.Length - b.Length; });
      int result = 0;
      // Step 2 - iterate the words 
      Dictionary<string, int> visited = new Dictionary<string, int>();
      foreach (var word in words)
      {
        if (!visited.ContainsKey(word))
          visited.Add(word, 1);
        for (int i = 0; i < word.Length; i++)
        {
          StringBuilder builder = new StringBuilder(word);
          var key = builder.Remove(i, 1).ToString();
          if (visited.ContainsKey(key))
          {
            var existing = visited[key];
            visited[word] = Math.Max(visited[word], 1 + existing);
          }
        }

        result = Math.Max(result, visited[word]);
      }

      return result;
    }
  }
}
