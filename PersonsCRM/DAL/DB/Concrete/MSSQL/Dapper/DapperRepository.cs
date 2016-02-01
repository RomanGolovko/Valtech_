using DAL.DB.Abstract;
using DAL.Entities;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System;

namespace DAL.DB.Concrete.MSSQL.Dapper
{
    public class DapperRepository : IRepository<Person>
    {
        private string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Roman\Documents\Repository\Valtech_\PersonsCRM\WebUI\App_Data\PersonsDB.mdf;Integrated Security=True";

        public void Create(Person item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Person Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Person item)
        {
            throw new NotImplementedException();
        }

        public Person Get(int id)
        {
            Person person;

            var query = "SELECT * FROM People WHERE Id = @id; SELECT * FROM Phones WHERE PersonId = @id";
            IDbConnection db = new SqlConnection(_connectionString);
            using (var multipleresult = db.QueryMultiple(query, new { id = id }))
            {
                person = multipleresult.Read<Person>().FirstOrDefault();
                var phones = multipleresult.Read<Phone>().ToList();
                person?.Phones.AddRange(phones);
            }

            return person;
        }

        public IEnumerable<Person> GetAll()
        {
            List<Person> persons = new List<Person>();
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                persons = db.Query<Person>("SELECT * FROM People").ToList();

                foreach (var person in persons)
                {
                    var query = "SELECT * FROM Phones WHERE PersonId = @id";
                    person.Phones = new List<Phone>();
                    using (var multipleresult = db.QueryMultiple(query, new { id = person.Id }))
                    {
                        var phones = multipleresult.Read<Phone>().ToList();
                        person.Phones.AddRange(phones);
                    }
                }
            }

            return persons;
        }
        ///TODO: finish with query
        public void Create(Person item)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO People (FirstName, LastName, Age) VALUES(@FirstName, @LastName, @Age); INSERT INTO Phones (Number, Type, PersonId) VALUES (@Number, @Type, @Age)";
                db.Execute(sqlQuery, item);
            }
        }

        public void Update(Person item)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "UPDATE People SET FirstName = @FirstName, LastName = @LastName, Age = @Age; UPDATE Phones SET Number = @Number, Type = @Type, PersonId = @PersonId";
                db.Execute(sqlQuery, item);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = $"DELETE FROM Persons WHERE Id = {id}; DELETE FROM Phones WHERE PersonId = {id}";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}
