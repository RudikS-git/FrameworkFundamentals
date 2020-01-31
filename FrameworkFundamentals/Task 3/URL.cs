using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkFundamentals.Task_3
{
    public class URL
    {
        public static string AddOrChangeUrlParameter(string url, string keyValueParameter)   
        {
            string[] str = keyValueParameter.Split('=');

            if(str == null || str.Length != 2)
            {
                throw new ArgumentException($"This keyValueParameter({keyValueParameter}) isn't correct");
            }

            int index = url.IndexOf(str[0]);

            if(index == -1) // new key
            {
                if (url.IndexOf('?') == -1)
                {
                    url = url.Insert(url.Length, '?' + keyValueParameter);
                }
                else
                {
                    url = url.Insert(url.Length, '&' + keyValueParameter);
                }
            }
            else // edit existing key
            {
                int indexNextAmp = url.IndexOf('&', index);

                if (indexNextAmp == -1) // then there are no more keys
                {
                    url = url.Remove(index + str[0].Length + 1);
                }
                else // then there are keys
                {
                    url = url.Remove(index + str[0].Length + 1, indexNextAmp - index + str[0].Length + 1);
                }

                url = url.Insert(index + str[0].Length + 1, str[1]);

            }

            return url;
        }
    }
}
