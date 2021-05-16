using System;
using System.IO;
using System.Linq;

namespace CsvEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = PeopleList.GetPeople();
            var personsProperties = typeof(Person).GetProperties();
            Console.WriteLine("Введите поля");
            var userProperties = Console.ReadLine().Split(",");
            const string symbol = ";";
            using (StreamWriter stream = new StreamWriter("file.csv", true))
            {
                foreach (var input in userProperties.Select(x => x + symbol))
                {
                    Console.Write(input);
                    stream.Write(input);
                }
                Console.WriteLine();
                foreach (var property in people)
                {
                    Console.WriteLine();
                    stream.WriteLine();
                    foreach (var usersPropertie in userProperties)
                    {
                        var fileprop = property.GetType().GetProperty(usersPropertie).GetValue(property, null);
                        Console.Write(fileprop + symbol);
                        stream.Write(fileprop + symbol);
                    }
                }
            }
        }
    }
}
