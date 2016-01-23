using DAL.DB.Abstract;
using DAL.Entities;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace DAL.DB.Concrete.MSSQL.Dapper
{
    public class DapperRepository : IRepository<Person>
    {
        //private readonly string _connectionString;
        string _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        //public DapperRepository(string connection)
        //{
        //    _connectionString = connection;
        //}

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
                var sqlQuery = item.Id == 0 ? "INSERT INTO Persons (FirstName, LastName, Age) VALUES(@FirstName, @LastName, @Age)" : 
                    "UPDATE Persons SET FirstName = @FirstName, LastName = @LastName, Age = @Age";

                db.Execute(sqlQuery, item);
            }
        }

        public void Update(Person item)
        {
            throw new System.NotImplementedException();
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
