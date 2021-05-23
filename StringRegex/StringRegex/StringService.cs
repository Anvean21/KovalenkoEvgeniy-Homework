using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace StringRegex
{
    public static class StringService
    {
        public static string DigitsInString(string inputString)
        {
            var charArr = inputString.ToCharArray();
            var result = string.Empty;
            foreach (var digit in charArr)
            {
                if (char.IsDigit(digit))
                {
                    result += digit;
                }
            }
            return result;
        }
        public static string DivideDigits(double a, double b)
        {
            double result = b / a;
            return result.ToString("F" + 2);
        }
        public static decimal ExponentialDigit()
        {
            var number = Console.ReadLine();
            if (!decimal.TryParse(number, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal result))
            {
                throw new Exception("Ошибка ввода");
            }
            return result;
        }
        public static void DateTimeISO(string str)
        {
            var date = str.Split(".");
            Array.Reverse(date);
            foreach (var item in date)
            {
                Console.Write(item + ".");
            }
        }

        public static string DateTimeParse(string input)
        {
            var split = input.Split("-");
            string result = split[0] + " " + split[1];
            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime date = DateTime.ParseExact(result.Replace(' ', ','), "yyyy,dd,MM", provider);
            return date.ToShortDateString();
        }

        public static string SumOfDigits(string digits)
        {
            var result = digits.Split(',');
            var res = 0;
            foreach (var item in result)
            {
                res += int.Parse(item);
            }
            return res.ToString();
        }

        public static void RegularFinder(string input)
        {

            Regex regex = new Regex(@"(\w*\d*)");
            MatchCollection matches = regex.Matches(input);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                    Console.WriteLine(match.Value);
            }
        }
        public static void RegularValidator(string password)
        {
            string pattern = @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$";
            if (Regex.IsMatch(password, pattern))
            {
                Console.WriteLine("Пароль валиден");
            }
            else
            {
                Console.WriteLine("Пароль не валиден");
            }
        }
        public static void RegularPostCodeValidator(string postcode)
        {
            string pattern = @"[0-9]{3}-[0-9]{3}";
            if (Regex.IsMatch(postcode, pattern))
            {
                Console.WriteLine("Посткод валиден");
            }
            else
            {
                Console.WriteLine("Посткод не валиден");
            }
        }

        public static void RegularPhoneNumberValidator(string phonenumber)
        {
            string pattern = "[0-9]{3}-[0-9]{2}-[0-9]{3}-[0-9]{2}-[0-9]{2}";
            if (Regex.IsMatch(phonenumber, pattern))
            {
                Console.WriteLine("Номер валиден");
            }
            else
            {
                Console.WriteLine("номер не валиден");
            }
        }
        public static void RegularReplacer(string number)
        {
            string pattern = "[0-9]{3}-[0-9]{2}-[0-9]{3}-[0-9]{2}-[0-9]{2}";
            string s = @"\d+";
            string target = "XXX";
            Regex regex = new Regex(s);
            string result = regex.Replace(number, target);
            Console.WriteLine(result);
        }

        public static string CamelCaseReplacer(string array)
        {
            TextInfo inf = CultureInfo.CurrentCulture.TextInfo;
            string[] str = array.Split(' ');

            for (int i = 0; i < str.Length; i++)
            {
                str[i] = inf.ToTitleCase(str[i]);
            }
            return String.Join(" ", str);
        }

        public static void Base64Encoder(string base64)
        {
            Console.WriteLine(Encoding.UTF8.GetString(Convert.FromBase64String(base64)));
        }
    }
}
