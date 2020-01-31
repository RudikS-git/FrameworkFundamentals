using System;

namespace FrameworkFundamentals.Task_1
{
    static class CustomerFormat
    {
        public static string Format(object obj, Customer.Format format, IFormatProvider formatProvider)
        {
            Customer customer = obj as Customer;

            if(customer == null)
            {
                obj.ToString();
            }

            return customer.ToString(format, formatProvider);
        }
    }
}
