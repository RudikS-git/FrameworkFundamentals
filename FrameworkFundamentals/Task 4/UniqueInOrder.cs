using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FrameworkFundamentals.Task_4
{
    public class UniqueInOrder
    {
        public static List<T> Compose<T>(List<T> list)
        {
            for(int i = 1; i < list.Count - 1; i++)
            {
                if(list[i].Equals(list[i+1]) || list[i].Equals(list[i-1]))
                {
                    list.RemoveAt(i);
                }
            }

            return list;
       
        }

        public static string Compose(string str)
        {
            if(str == null)
            {
                throw new ArgumentException("String is null");
            }

            if(str.Length == 1)
            {
                return str;
            }

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(str[0]);

            for (int i = 1; i < str.Length - 1; i++)
            {
                if(str[i] != str[i+1] && str[i] != stringBuilder[stringBuilder.Length-1])
                {
                    stringBuilder.Append(str[i]);
                }
            }

            int lastInd = str.Length - 1;

            if (str[lastInd] != stringBuilder[stringBuilder.Length - 1])
            {
                stringBuilder.Append(str[lastInd]);
            }


            return stringBuilder.ToString();
        }
    }
}
