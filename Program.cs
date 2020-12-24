using System;
using System.Collections.Generic;

namespace ListHexaName
{
  class Program
  {
    static void Main()
    {
      Action<string> display = Console.WriteLine;
      display("List all names possible with hexa characters");
      string[] voyelles = new string[] { "A", "E" };
      string[] consonnes = new string[] { "B", "C", "D", "F" };
      List<string> syllabes = new List<string>();
      List<string> words = new List<string>();
      foreach (string consonne in consonnes)
      {
        foreach (string voyelle in voyelles)
        {
          display($"{consonne}{voyelle}");
          syllabes.Add($"{consonne}{voyelle}");
        }
      }

      // BA BE CA CE DA DE FA FE
      // 1  2  3  4  5  6  7  8
      char[] hexaCharacters = new char[] { 'A', 'B', 'C', 'D', 'E', 'F' };
      GetPermutations(hexaCharacters);
      var listOfwords = new List<string>();
      listOfwords = GetWords(syllabes, 4);
      int numberOfSyllable = 8;
      int numberOfWords = 1;
      for (int i = 0; i < numberOfWords; i++)
      {
        string oneWord = "";
        for (int j = 0; j < numberOfSyllable; j++)
        {
          oneWord += syllabes[j];
        }

        words.Add(oneWord);
        display($"{oneWord}");
      }

      display("");
      display("Press any key to exit:");
      Console.ReadKey();
    }

    private static List<string> GetWords(List<string> syllabes, int numberOfSyllables)
    {
      List<string> result = new List<string>();
      string oneWord = string.Empty;
      Random aleatoire = new Random();
      int numberOfWords = 48;
      switch (numberOfSyllables)
      {
        case 2:
          numberOfWords = 48; // should be 64
          break;
        case 3:
          numberOfWords = 342; // should be 512
          break;
        case 4:
          numberOfWords = 342; // should be 4096
          break;
        default:
          numberOfWords = 48;
          break;
      }
      do
      {
        for (int i = 0; i < numberOfSyllables; i++)
        {
          oneWord += syllabes[aleatoire.Next(1, syllabes.Count)];
        }

        if (!result.Contains(oneWord))
        {
          result.Add(oneWord);
        }

        oneWord = string.Empty;
      } while (result.Count <= numberOfWords);


      return result;
    }

    private static void Swap(ref char a, ref char b)
    {
      if (a == b) return;

      var temp = a;
      a = b;
      b = temp;
    }

    public static void GetPermutations(char[] list)
    {
      int x = list.Length - 1;
      GetPermutations(list, 0, x);
    }

    private static void GetPermutations(char[] list, int k, int m)
    {
      if (k == m)
      {
        Console.WriteLine(list);
      }
      else
        for (int i = k; i <= m; i++)
        {
          Swap(ref list[k], ref list[i]);
          GetPermutations(list, k + 1, m);
          Swap(ref list[k], ref list[i]);
        }
    }
  }
}
