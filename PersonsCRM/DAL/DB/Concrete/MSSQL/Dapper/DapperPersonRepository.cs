using DAL.DB.Abstract;
using DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace DAL.DB.Concrete.MSSQL.Dapper
{
    public class DapperPersonRepository : IRepository<Person>
    {
        private readonly string _connectionString;

        public DapperPersonRepository(string connection)
        {
            _connectionString = connection;
        }

        public Person Get(int id)
        {
            Person person;

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                person = db.Query<Person>("SELECT * FROM Persons WHERE Id = @id", new { id }).FirstOrDefault();
            }
            return person;
        }

        public IEnumerable<Person> GetAll()
        {
            List<Person> persons;
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                persons = db.Query<Person>("SELECT * FROM Persons").ToList();
            }

            return persons;
        }

        public void Create(Person item)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO Persons (FirstName, LastName, Age) VALUES(@FirstName, @LastName, @Age)";
                db.Execute(sqlQuery, item);
            }
        }

        public void Update(Person item)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "UPDATE Persons SET FirstName = @FirstName, LastName = @LastName, Age = @Age";
                db.Execute(sqlQuery, item);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = $"DELETE FROM Persons WHERE Id = {id}";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}
