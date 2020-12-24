﻿using System;
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

      int numberOfSyllable = 5;
      int numberOfWords = 30;
      Random rnd = new Random();
      for (int i = 0; i < numberOfWords; i++)
      {
        string oneWord = "";
        for (int j = 0; j < numberOfSyllable; j++)
        {
          oneWord += syllabes[rnd.Next(0, syllabes.Count)];
        }

        if (!words.Contains(oneWord))
        {
          words.Add(oneWord);
        }
      }

      foreach (string word in words)
      {
        display($"{word}");
      }

      display("Press any key to exit:");
      Console.ReadKey();
    }
  }
}
