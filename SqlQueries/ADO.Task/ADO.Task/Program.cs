using System;
using System.Data;
using System.Data.SqlClient;

namespace ADO.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server =DESKTOP-DKVRESV;Database=AdventureWorksLT2019;Trusted_Connection=True;";
            Queries queries = new Queries(connectionString);

            var date = DateTime.Now.ToString("yyyy.mm.dd");
            var query1 = queries.GetCategorySoldProducts(date);
            foreach (var item in query1)
            {
                Console.WriteLine($"{item.ProductCategoryId}\t{item.CategoryName}\t{item.SummaryPrice}");
            }

            int discount = 4;
            var query2 = queries.CustomersViaDiscount(discount);
            foreach (var item in query2)
            {
                Console.WriteLine($"{item.CustomerId}\t{item.Title}\t{item.FirstName}\t{item.MiddleName}\t{item.LastName}");
            }

            int totalsum = 15000;
            var query3 = queries.CustomersTotalBoughtOver15k(totalsum);
            foreach (var item in query3)
            {
                Console.WriteLine($"{item.CustomerId}\t{item.FirstName}\t{item.MiddleName}\t{item.LastName}");
            }

            Console.Read();
        }

    }
}
