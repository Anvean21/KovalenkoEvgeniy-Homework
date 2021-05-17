using System;
using System.IO;
using System.Linq;

namespace CsvEditor
{
    class Program
    {
        const string CsvSymbol = ";";
        const char SplitSymbol = ',';
        const string FileName = "file.csv";
        static void Main(string[] args)
        {
            var people = PeopleList.GetPeople();
            var personsProperties = typeof(Person).GetProperties();
            Console.Write("Введите поля через запятую : ");
            var userProperties = Console.ReadLine().Split(SplitSymbol);
            using (StreamWriter stream = new StreamWriter(FileName, true))
            {
                foreach (var input in userProperties.Select(x => x + CsvSymbol))
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
                        Console.Write(fileprop + CsvSymbol);
                        stream.Write(fileprop + CsvSymbol);
                    }
                }
            }
        }
    }
}
