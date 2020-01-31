using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkFundamentals.Task_5
{
    public class Sentence
    {
        public static string ReverseWords(string text)
        {
            string [] newText = text.Split(' ');
            string[] reversedText = new string[newText.Length];

            for(int i = newText.Length - 1, j = 0; i >= 0; i--, j++)
            {
                reversedText[j] = newText[i];
            }

            return string.Join(" ", reversedText);
        }
    }
}
