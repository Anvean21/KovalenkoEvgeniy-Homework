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
            foreach (var property in personsProperties)
            {
                foreach (var usersPropertie in userProperties)
                {
                    using (StreamWriter sw = new StreamWriter("file.csv", true))
                    {
                        if (property.Name == usersPropertie)
                        {
                            var fileprop = string.Join("\n", people.Select(x => typeof(Person).GetProperty(usersPropertie).GetValue(x) + " - " + property.Name)) + "\n";
                            sw.WriteLine(fileprop);
                        }
                    }
                }
            }
        }
    }
}
