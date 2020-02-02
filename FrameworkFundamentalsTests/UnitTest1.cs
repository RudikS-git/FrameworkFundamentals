using FrameworkFundamentals;
using FrameworkFundamentals.Task_2;
using FrameworkFundamentals.Task_3;
using FrameworkFundamentals.Task_4;
using FrameworkFundamentals.Task_5;
using FrameworkFundamentals.Task_6;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace FrameworkFundamentalsTests
{
    public class Tests
    {
        static public IEnumerable<TestCaseData> combination_Customertests()
        {
            yield return new TestCaseData(new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000), Customer.Format.Full,
                                                       "Customer record: Jeffrey Richter, 1,000,000.00, +1 (425) 555-0100").SetName("[CustomerFormat] test 1");

            yield return new TestCaseData(new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000), Customer.Format.ContactPhone,
                                                       "Customer record: +1 (425) 555-0100").SetName("[CustomerFormat] test 2");

            yield return new TestCaseData(new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000), Customer.Format.Name,
                                                       "Customer record: Jeffrey Richter").SetName("[CustomerFormat] test 3");

            yield return new TestCaseData(new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000), Customer.Format.Revenue,
                                                       "Customer record: 1000000").SetName("[CustomerFormat] test 4");

            yield return new TestCaseData(new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000), Customer.Format.NameRevenue,
                                                       "Customer record: Jeffrey Richter, 1,000,000.00").SetName("[CustomerFormat] test 5");
        }

        [TestCaseSource("combination_Customertests")]
        public void CustomerTests(Customer customer, Customer.Format customerFormat, string strExpected)
        {
            CultureInfo format = (CultureInfo)CultureInfo.InvariantCulture.Clone();
            format.NumberFormat.CurrencySymbol = "";
            format.NumberFormat.CurrencyDecimalSeparator = ".";
            format.NumberFormat.CurrencyDecimalDigits = 2;

            Assert.AreEqual(customer.ToString(customerFormat, format), strExpected);
            
        }

        static public IEnumerable<TestCaseData> combination_Titletests()
        {
            yield return new TestCaseData("a clash of KINGS", "A Clash of Kings", "a an the of").SetName("[TitleFormat] test 1");

            yield return new TestCaseData("THE WIND IN THE WILLOWS", "The Wind in the Willows", "The In").SetName("[TitleFormat] test 2");

            yield return new TestCaseData("the quick brown fox", "The Quick Brown Fox", null).SetName("[TitleFormat] test 3");

        }

        [TestCaseSource("combination_Titletests")]
        public void Titletests(string text, string strExpected, string exception = null)
        {
            Assert.AreEqual(Title.EditToFormat(text, exception), strExpected);
        }

        static public IEnumerable<TestCaseData> combination_Urltests()
        {
            yield return new TestCaseData("www.example.com", "key=value", "www.example.com?key=value").SetName("[URLFormat] test 1");

            yield return new TestCaseData("www.example.com?key=value", "key2=value2", "www.example.com?key=value&key2=value2").SetName("[URLFormat] test 2");

            yield return new TestCaseData("www.example.com?key=oldValue", "key=newValue", "www.example.com?key=newValue").SetName("[URLFormat] test 3");

        }

        [TestCaseSource("combination_Urltests")]
        public void Urltests(string url, string keyValueParameter, string strExpected)
        {
            Assert.AreEqual(URL.AddOrChangeUrlParameter(url, keyValueParameter), strExpected);
        }

        static public IEnumerable<TestCaseData> combination_UniqueInOrderStrtests()
        {
            yield return new TestCaseData("AAAABBBCCDAABBB", "ABCDAB").SetName("[UniqueStrFormat] test 1");

            yield return new TestCaseData("ABBCcAD", "ABCcAD").SetName("[UniqueStrFormat] test 2");

            yield return new TestCaseData("12233", "123").SetName("[UniqueStrFormat] test 3");

        }

        [TestCaseSource("combination_UniqueInOrderStrtests")]
        public void UniqueInOrderStrTests(string str, string strExpected)
        {
            Assert.AreEqual(UniqueInOrder.Compose(str), strExpected);
        }

        static public IEnumerable<TestCaseData> combination_UniqueInOrderListtests()
        {
            yield return new TestCaseData(new List<int> { 1, 1, 2, 3, 2 }, new List<int> { 1, 2, 3, 2 }).SetName("[UniqueListFormat] test 1");

            yield return new TestCaseData(new List<double> { 1.1, 2.2, 2.2, 3.3 }, new List<double> { 1.1, 2.2, 3.3 }).SetName("[UniqueListFormat] test 2");

            yield return new TestCaseData(new List<int> { 1, 1, 2, 1, 3, 4, 3 }, new List<int> { 1, 2, 1, 3, 4, 3 }).SetName("[UniqueListFormat] test 3");

        }

        [TestCaseSource("combination_UniqueInOrderListtests")]
        public void UniqueInOrderListTests<T>(List<T> list, List<T> listExpected)
        {
            Assert.AreEqual(UniqueInOrder.Compose(list), listExpected);
        }

        static public IEnumerable<TestCaseData> combination_UniqueInOrderHashSettests()
        {
            yield return new TestCaseData(new HashSet<int> { 1, 1, 2, 3, 2 }, new HashSet<int> { 1, 2, 3, 2 }).SetName("[UniqueHashSetFormat] test 1");

            yield return new TestCaseData(new HashSet<double> { 1.1, 2.2, 2.2, 3.3 }, new HashSet<double> { 1.1, 2.2, 3.3 }).SetName("[UniqueHashSetFormat] test 2");

            yield return new TestCaseData(new HashSet<int> { 1, 1, 2, 1, 3, 4, 3 }, new HashSet<int> { 1, 2, 1, 3, 4, 3 }).SetName("[UniqueHashSetFormat] test 3");

        }

        [TestCaseSource("combination_UniqueInOrderHashSettests")]
        public void UniqueInOrderHashSetTests<T>(HashSet<T> list, HashSet<T> listExpected)
        {
            Assert.AreEqual(UniqueInOrder.Compose(list), listExpected);
        }

        [TestCase("The greatest victory is that which requires no battle", "battle no requires which that is victory greatest The")]
        public void SentenceTests(string text, string strExpected)
        {
            Assert.AreEqual(Sentence.ReverseWords(text), strExpected);
        }

        [TestCase("2", "2", "4")]
        [TestCase("0", "0", "0")]
        [TestCase("-1", "1", "0")]
        [TestCase("-5", "-5", "-10")]
        public void NumbersTests(string firstNum, string secondNum, string strExpected)
        {
            Assert.AreEqual(Numbers.Sum(firstNum, secondNum), strExpected);
        }





    }
}