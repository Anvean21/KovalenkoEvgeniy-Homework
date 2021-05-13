using CsvHelper;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Linq;

namespace CVSFileEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            var persons = PersonList.GetListPerson();
            var personsProperties = typeof(Person).GetProperties();

            Console.WriteLine("Введите поля");
            var str = Console.ReadLine().Split(",");

            foreach (var property in personsProperties)
            {
                foreach (var usersPropertie in str)
                {
                    using (StreamWriter sw = new StreamWriter("file.csv", true))
                    {
                        if (property.Name == usersPropertie)
                        {
                            var fileprop = string.Join("\n",persons.Select(x => typeof(Person).GetProperty(usersPropertie).GetValue(x)+" - "+property.Name))+"\n";
                            sw.WriteLine( fileprop);
                        }
                    }
                }
            }

            //Вариант рабочий, но не красивый.

            //var csv = new StringBuilder();
            //foreach (var item in persons)
            //{
            //    Print(() => item.Name, str, csv);
            //    Print(() => item.Address, str, csv);
            //    Print(() => item.Age, str, csv);
            //    Print(() => item.EyeColor, str, csv);
            //    Print(() => item.Gender, str, csv);
            //    Print(() => item.Salary, str, csv);
            //    Print(() => item.Company, str, csv);
            //    csv.Append("\n");
            //}
            //File.AppendAllText("D:\\file.csv", csv.ToString());

        }
        static void Print<T>(Expression<Func<T>> expression, string[] str, StringBuilder csv)
        {

            foreach (var item in str)
            {
                if (item == ((MemberExpression)expression.Body).Member.Name)
                {
                    //Console.WriteLine("Цикл отработал - " + item);
                    csv.Append(((MemberExpression)expression.Body).Member.Name + " - " + expression.Compile()());
                    csv.Append(",");
                }
            }
        }
    }
}
