using Dapper;
using DapperPractice.Core;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DapperPractice.DAL
{
    public class DapperRepository<T> : IRepository<T> where T : class
    {
        private readonly string connectionString = "Server=DESKTOP-DKVRESV;Database=helloappdb;Trusted_Connection=True;";
        private readonly Type tableName = typeof(T);

        public DapperRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void Create(T item)
        {
            var c = tableName.GetProperties();
            string str = string.Join(", ", c.ToString());
            //foreach (var property in tableName.GetProperties())
            //{
            //    str.Join(',', property.Name.ToString());
            //}
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute($"Insert Into { tableName } ( )", item);
            }
        }

        public T FindById(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<T>($"Select * From {tableName} Where Id = @id", new { id }).FirstOrDefault();
            }
        }

        public IEnumerable<T> Get(Func<T, bool> predicate)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<T>($"Select * From { tableName }");
            }
        }

        public void Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
