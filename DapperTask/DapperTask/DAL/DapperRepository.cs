using Dapper;
using DapperExtensions;
using DapperTask.Core;
using DapperTask.Core.Entities;
using EFlecture.Core.Specifications;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DapperTask.DAL
{
    public class DapperRepository<TEntity> : IRepository<TEntity> where TEntity : BasicEntity
    {
        private readonly string connectionString = "Server=DESKTOP-DKVRESV;Database=ShopDatabase;Trusted_Connection=True;";

        private readonly string tableName = typeof(TEntity).Name;

        public DapperRepository()
        {

        }
        public void Add(TEntity entity)
        {
            var properties = string.Join(", ", entity.GetType().GetProperties().Select(x => $"{x.Name}"));

            var sqlValues = string.Join(", ", entity.GetType().GetProperties().Select(x => $"@{x.Name}"));

            using IDbConnection db = new SqlConnection(connectionString);
            var sqlQuery = $"Insert Into { tableName } ({properties}) VALUES ({sqlValues})";

            db.Execute(sqlQuery, entity);
        }

        public TEntity Find(int id)
        {
            using IDbConnection db = new SqlConnection(connectionString);
            return db.Query<TEntity>($"Select * From {tableName} Where Id = @id", new { id }).FirstOrDefault();
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, object>> expression, object value)
        {
            using IDbConnection db = new SqlConnection(connectionString);

            return db.GetList<TEntity>(Predicates.Field(expression, Operator.Eq, value)).ToList();
        }

        public void Remove(int entityId)
        {
            using IDbConnection db = new SqlConnection(connectionString);
            var sqlQuery = $"DELETE FROM {tableName} WHERE Id = @id";
            db.Execute(sqlQuery, new { entityId });
        }

        public void Update(TEntity entity)
        {
            var updates = string.Join(", ", entity.GetType().GetProperties()
                .Select(x => $"{x.Name} = @{x.Name}"));

            using IDbConnection db = new SqlConnection(connectionString);
            var sqlQuery = $"UPDATE {tableName} SET {updates} WHERE Id = @Id";
            db.Execute(sqlQuery, entity);
        }
    }
}
