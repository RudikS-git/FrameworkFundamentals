using System;

namespace FrameworkFundamentals.Task_6
{
    public class Numbers
    {
        public static string Sum(string firstNum, string secondNum)
        {
            try
            {
                return (int.Parse(firstNum) + int.Parse(secondNum)).ToString();
            }
            catch(Exception exception)
            {
                throw new ArgumentException(exception.ToString());
            }
        }
    }
}
