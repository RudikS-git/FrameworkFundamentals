using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FrameworkFundamentals.Task_2
{
    public class Title
    {
        public static string EditToFormat(string text, string exceptions = null)
        {
            if(text == null)
            {
                throw new ArgumentException("Text is null");
            }

            text = text.ToLower();
            string[] words = text.Split(' ');
            string[] WordsExceptions = null;

            List<StringBuilder> list = new List<StringBuilder>();
            StringBuilder stringBuilder = new StringBuilder("");

            for (int i = 0; i < words.Length; i++)
            {
                list.Add(new StringBuilder(words[i]));
            }

            if (exceptions != null)
            {
                exceptions = exceptions.ToLower();
                WordsExceptions = exceptions.Split(' ');
            }

            for(int i = 0; i < list.Count; i++)
            {
                if (char.IsLetter(list[i][0]) && (i == 0 || ((WordsExceptions != null && CheckWord(list[i].ToString().ToLower(), ref WordsExceptions)) || WordsExceptions == null))) // difficult
                {
                    list[i] = FirstToUpper(list[i]);
                }

                stringBuilder.Append(list[i] + " ");
            }

            return String.Join(" ", stringBuilder.ToString().TrimEnd(' '));
        }

        private static StringBuilder FirstToUpper(StringBuilder str)
        {
            str[0] = char.ToUpper(str[0]);

            for (int i = 1; i < str.Length; i++)
            {
                if(char.IsUpper(str[i]))
                {
                    str[i] = char.ToLower(str[i]);
                }
            }

            return str;
        }

        private static bool CheckWord(string word, ref string [] exceptions)
        {
            for(int i = 0; i < exceptions.Length; i++)
            {
                if (word == exceptions[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
