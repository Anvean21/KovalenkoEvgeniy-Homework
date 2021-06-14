using ADO.Task.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ADO.Task
{
    public class Queries
    {
        private readonly string connectionString;
        public Queries(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public IEnumerable<CategoryInfo> GetCategorySoldProducts(string date)
        {
            string sqlQuery = " Select product.ProductCategoryID, category.Name, SUM(sale.UnitPrice) SummaryPrice From SalesLT.Product product  JOIN SalesLT.ProductCategory category ON product.ProductCategoryID = category.ProductCategoryID JOIN SalesLT.SalesOrderDetail sale ON product.ProductID = sale.ProductID  Where Product.SellEndDate < @date Group By product.ProductCategoryID, category.Name ";

            List<CategoryInfo> resultList = new List<CategoryInfo>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlParameter sqlParameter = new SqlParameter("@date", date);
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.ExecuteNonQuery();
                    command.Parameters.Add(sqlParameter);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            object productCategoryId = (int)reader.GetValue(0);
                            object categoryName = (string)reader.GetValue(1);
                            object summaryPrice = (decimal)reader.GetValue(2);

                            var type = new CategoryInfo { ProductCategoryId = (int)productCategoryId, CategoryName = (string)categoryName, SummaryPrice = (decimal)summaryPrice };

                            resultList.Add(type);
                            Console.WriteLine($"{productCategoryId}\t{categoryName}\t{summaryPrice}");
                        }
                    }
                    reader.Close();
                }
                return resultList;
            }
        }
        public IEnumerable<Customer> CustomersViaDiscount(int discount)
        {
            string sqlQuery = "Select * FROM SalesLT.Customer WHERE CustomerID in( SELECT distinct customer.CustomerID FROM SalesLT.Customer customer JOIN SalesLT.SalesOrderHeader salesHeader ON salesHeader.CustomerID = customer.CustomerID JOIN SalesLT.SalesOrderDetail salesDetail ON salesDetail.SalesOrderID = salesHeader.SalesOrderID GROUP BY customer.CustomerID HAVING  MAX(salesDetail.UnitPriceDiscount * 100) > @discount)";

            List<Customer> resultList = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlParameter sqlParameter = new SqlParameter("@discount", discount);
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.ExecuteNonQuery();
                    command.Parameters.Add(sqlParameter);
                    command.Parameters.Add(sqlParameter);
                    command.Parameters.Add(sqlParameter);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            object customerId = (int)reader.GetValue(0);
                            object title = (string)reader.GetValue(1);
                            object firtName = (string)reader.GetValue(2);
                            object middleName = (string)reader.GetValue(3);
                            object lastName = (string)reader.GetValue(4);

                            Customer type = new Customer { CustomerId = (int)customerId, Title = (string)title, FirstName = (string)firtName, MiddleName = (string)middleName, LastName = (string)lastName };

                            resultList.Add(type);
                        }
                    }
                    reader.Close();
                }
                return resultList;
            }
        }
        public IEnumerable<Customer> CustomersTotalBought(int totalSum)
        {
            string sqlQuery = "SELECT CustomerID, customer.FirstName, customer.MiddleName, customer.LastName from SalesLT.Customer  WHERE CustomerID In(SELECT DISTINCT customer.CustomerID from SalesLT.Customer customer  JOIN SalesLT.SalesOrderHeader salesHeader ON salesHeader.CustomerID = customer.CustomerIDJOIN SalesLT.SalesOrderDetail salesDetail ON salesDetail.SalesOrderID = salesHeader.SalesOrderID GROUP BY customer.CustomerID HAVING SUM(salesDetail.UnitPrice) > @totalsum)";

            List<Customer> resultList = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlParameter sqlParameter = new SqlParameter("@totalsum", totalSum);

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.ExecuteNonQuery();
                    command.Parameters.Add(sqlParameter);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            object customerId = (int)reader.GetValue(0);
                            object firtName = (string)reader.GetValue(1);
                            object middleName = (string)reader.GetValue(2);
                            object lastName = (string)reader.GetValue(3);

                            Customer type = new Customer { CustomerId = (int)customerId, FirstName = (string)firtName, MiddleName = (string)middleName, LastName = (string)lastName };

                            resultList.Add(type);
                        }
                        return resultList;
                    }
                    reader.Close();
                }
                return resultList;
            }
        }
    }
}
