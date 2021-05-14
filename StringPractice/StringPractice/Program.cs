using System;

namespace StringPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(StringService.DigitsInString("123fds21"));
            Console.WriteLine(StringService.DivideDigits(5,8.21));
            StringService.DateTimeISO(DateTime.Now.ToShortDateString());
            Console.WriteLine();
            Console.WriteLine(StringService.DateTimeParse("2016 21-07"));
            Console.WriteLine(StringService.SumOfDigits("1,2,3"));
            StringService.RegularFinder("текст123текст242?екс3534?текст123");
            StringService.RegularValidator("passWord123");
            StringService.RegularValidator("pas12");
            Console.WriteLine();
            StringService.RegularPostCodeValidator("123-123");
            StringService.RegularPostCodeValidator("12-123");
            Console.WriteLine();
            StringService.RegularPhoneNumberValidator("+380-98-123-45-67");
            StringService.RegularPhoneNumberValidator("+38098-123-45-67");
            Console.WriteLine();
            StringService.RegularReplacer("+380-98-123-45-67");
            StringService.Base64Encoder("0JXRgdC70Lgg0YLRiyDRh9C40YLQsNC10YjRjCDRjdGC0L7RgiDRgtC10LrRgdGCLCDQt9C90LDRh9C40YIg0LfQsNC00LDQvdC40LUg0LLRi9C/0L7Qu9C90LXQvdC+INCy0LXRgNC90L4gOik=");

        }
    }
}
