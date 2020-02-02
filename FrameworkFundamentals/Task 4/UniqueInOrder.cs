using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FrameworkFundamentals.Task_4
{
    public class UniqueInOrder
    {
        public static IEnumerable<T> Compose<T>(IEnumerable<T> list)
        { 
            var array = list.ToList();
            
            for(int i = 1; i < array.Count - 1; i++)
            {
                if(array[i].Equals(array[i+1]) || array[i].Equals(array[i-1]))
                {
                    array.RemoveAt(i);
                }
            }

            return array;
       
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
