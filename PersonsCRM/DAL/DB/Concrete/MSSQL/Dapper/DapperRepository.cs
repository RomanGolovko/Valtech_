using DAL.DB.Abstract;
using DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace DAL.DB.Concrete.MSSQL.Dapper
{
    public class DapperRepository : IRepository<Person>
    {
        string connectionString; /*= ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;*/

        public DapperRepository(string connection)
        {
            connectionString = connection;
        }

        public Person Get(int id)
        {
            Person person = null;

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                person = db.Query<Person>("SELECT * FROM Persons WHERE Id = @id", new { id }).FirstOrDefault();
            }
            return person;
        }

        public IEnumerable<Person> GetAll()
        {
            var persons = new List<Person>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                persons = db.Query<Person>("SELECT * FROM Persons").ToList();
            }

            return persons;
        }

        public void Create(Person item)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "";

                if (item.Id == 0)
                {
                    sqlQuery = "INSERT INTO Persons (FirstName, LastName, Age) VALUES(@FirstName, @LastName, @Age)";
                }
                else
                {
                    sqlQuery = "UPDATE Persons SET FirstName = @FirstName, LastName = @LastName, Age = @Age";
                }

                db.Execute(sqlQuery, item);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Persons WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}
