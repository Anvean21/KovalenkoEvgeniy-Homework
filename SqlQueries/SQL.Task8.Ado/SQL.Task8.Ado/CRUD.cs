using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SQL.Task8.Ado
{
    public class CRUD
    {
        private readonly string connectionString;
        public CRUD(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void DeleteTableRow(string table, string name, string condition)
        {
            string sqlQuery = $"DELETE FROM {table} Where {name} = '{condition}' ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void InsertTableData(string table, string name, string value)
        {
            string sqlQuery = $"INSERT INTO {table} ({name}) VALUES ('{value}') ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateTableData(string table, string name, string value, string column, object condition)
        {
            string sqlQuery = $"Update {table} SET {name} = '{value}' Where {column} = '{condition}'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
