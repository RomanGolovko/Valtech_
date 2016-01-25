using DAL.DB.Abstract;
using DAL.Entities;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL.DB.Concrete.MSSQL.Dapper
{
    public class DapperRepository : IRepository<Person>
    {
        private string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\GitHub Repository\Valtech_\PersonsCRM\WebUI\App_Data\PersonsDB.mdf';Integrated Security=True";

        public Person Get(int id)
        {
            Person person;

            var query = "SELECT * FROM Persons WHERE Id = @id; SELECT * FROM Phones WHERE PersonId = @id";
            IDbConnection db = new SqlConnection(_connectionString);
            using (var multipleresult = db.QueryMultiple(query, new {id = id}))
            {
                person = multipleresult.Read<Person>().FirstOrDefault();
                var phones = multipleresult.Read<Phone>().ToList();
                person?.Phones.AddRange(phones);
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
        ///TODO: finish with query
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
