using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var customers = new List<Customer>
{
    new Customer(1, "Tawana Shope", new DateTime(2017, 7, 15), 15.8),
    new Customer(2, "Danny Wemple", new DateTime(2016, 2, 3), 88.54),
    new Customer(3, "Margert Journey", new DateTime(2017, 11, 19), 0.5),
    new Customer(4, "Tyler Gonzalez", new DateTime(2017, 5, 14), 184.65),
    new Customer(5, "Melissa Demaio", new DateTime(2016, 9, 24), 241.33),
    new Customer(6, "Cornelius Clemens", new DateTime(2016, 4, 2), 99.4),
    new Customer(7, "Silvia Stefano", new DateTime(2017, 7, 15), 40),
    new Customer(8, "Margrett Yocum", new DateTime(2017, 12, 7), 62.2),
    new Customer(9, "Clifford Schauer", new DateTime(2017, 6, 29), 89.47),
    new Customer(10, "Norris Ringdahl", new DateTime(2017, 1, 30), 13.22),
    new Customer(11, "Delora Brownfield", new DateTime(2011, 10, 11), 0),
    new Customer(12, "Sparkle Vanzile", new DateTime(2017, 7, 15), 12.76),
    new Customer(13, "Lucina Engh", new DateTime(2017, 3, 8), 19.7),
    new Customer(14, "Myrna Suther", new DateTime(2017, 8, 31), 13.9),
    new Customer(15, "Fidel Querry", new DateTime(2016, 5, 17), 77.88),
    new Customer(16, "Adelle Elfrink", new DateTime(2017, 11, 6), 183.16),
    new Customer(17, "Valentine Liverman", new DateTime(2017, 1, 18), 13.6),
    new Customer(18, "Ivory Castile", new DateTime(2016, 4, 21), 36.8),
    new Customer(19, "Florencio Messenger", new DateTime(2017, 10, 2), 36.8),
    new Customer(20, "Anna Ledesma", new DateTime(2017, 12, 29), 0.8)
};

            //Первый зарегистрированный пользователь
            var firstCustomer = customers.OrderBy(x => x.RegistrationDate);

            //Средний баланс всех юзеров
            var list = customers.Select(x => x.Balance);

            //Фильтрация дат
            FilterDate(customers, new DateTime(2015, 10, 11), new DateTime(2017, 9, 9));

            //Поиск Id
            Console.WriteLine("id - ");
            var i = int.Parse(Console.ReadLine());
            var idFilter = customers.FirstOrDefault(x => x.Id == i );
            Console.WriteLine(idFilter.Name);

            //Поиск по части имени
            Console.WriteLine("Name - ");
            var str = Console.ReadLine().ToLower();
            var customersNames = customers.Where(x => x.Name.Contains(str)).ToList();
            foreach (var item in customersNames)
            {
                Console.WriteLine($"{item.Id}-{item.Name}-{item.RegistrationDate}");
            }
            Console.WriteLine("Выберите месяц");
            var monthNumber = int.Parse(Console.ReadLine());
            var sortedGroup = customers.Where(x => x.RegistrationDate.Month == monthNumber).OrderBy(x=> x.RegistrationDate);
            foreach (var item in sortedGroup)
            {
                Console.WriteLine($"{item.Name}, {item.RegistrationDate}");
            }
            //Сортировка пользователей по полю и в разных порядках
           var ASC = CustomerSort(customers, "Name", true);
           var DESC = CustomerSort(customers, "Name", false);
            Console.WriteLine("-------------------ASC----------------------");
            foreach (var item in ASC)
            {
                Console.WriteLine($"{item.Id}-{item.Name}-{item.RegistrationDate}");
            }
            Console.WriteLine("-------------------DESC----------------------");

            foreach (var item in DESC)
            {
                Console.WriteLine($"{item.Id}-{item.Name}-{item.RegistrationDate}");
            }


            Console.WriteLine("-------------------,----------------------");
            //Вывод через запятую
            var collection = customers.Select(x => x.Name + ", ").ToList();
            foreach (var item in collection)
            {
                Console.Write(item);
            }
        }
        public static void FilterDate(List<Customer> cm, DateTime from, DateTime to)
        {
            var dates = cm.Where(x => x.RegistrationDate >= from && x.RegistrationDate <= to).ToList();
            if (dates.Count == 0)
            {
                Console.WriteLine("No result!");
            }
            else
            {
                foreach (var date in dates)
                {
                    Console.WriteLine($"{date.Name} - {date.RegistrationDate}") ;
                }
            }
        }
        public static List<Customer> CustomerSort(List<Customer> cm, string property,bool order)
        {

            var type = typeof(Customer);
            var sortProperty = type.GetProperty(property);
            if (order)
            {
                return cm.OrderBy(p => sortProperty.GetValue(p, null)).ToList();
            }
            else
            {
                return cm.OrderByDescending(p => sortProperty.GetValue(p, null)).ToList();
            }
        }


    }
}
