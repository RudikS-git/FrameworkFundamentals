using System;
using System.Globalization;

namespace FrameworkFundamentals
{
    public class Customer
    {
        public string Name { get; set; }
        public string ContactPhone { get; set; }
        public decimal Revenue { get; set; }

        public Customer(string Name, string ContactPhone, decimal Revenue)
        {
            this.Name = Name;
            this.ContactPhone = ContactPhone;
            this.Revenue = Revenue;
        }

        public enum Format
        {
            Name,
            ContactPhone,
            Revenue,
            NameRevenue,
            Full
        }

        public override string ToString()
        {
            return this.ToString(Format.Full, CultureInfo.CurrentCulture);
        }

        public string ToString(Format format)
        {
            return this.ToString(format, CultureInfo.CurrentCulture);
        }

        public string ToString(Format format, IFormatProvider formatProvider)
        {
            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            switch (format)
            {
                case Format.Name:
                    return String.Format(formatProvider, "Customer record: {0}", Name);

                case Format.ContactPhone:
                    return String.Format(formatProvider, "Customer record: {0}", ContactPhone);

                case Format.Revenue:
                    return String.Format(formatProvider, "Customer record: {0}", Revenue);

                case Format.NameRevenue:
                    return String.Format(formatProvider, "Customer record: {0}, {1:C2}", Name, Revenue);

                case Format.Full:
                    return String.Format(formatProvider, "Customer record: {0}, {1:C2}, {2}", Name, Revenue, ContactPhone);

                default:
                    throw new FormatException($"This \"{format}\" isn't supported");
                  
            }
        }
    }
}
