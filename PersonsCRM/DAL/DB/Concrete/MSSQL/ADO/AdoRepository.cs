using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using DAL.DB.Abstract;
using DAL.Entities;

namespace DAL.DB.Concrete.MSSQL.ADO
{
    public class AdoRepository : IRepository<Person>
    {
        //private readonly string _connectionString;
        string _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        //public AdoRepository(string connection)
        //{
        //    _connectionString = connection;
        //}

        public Person Get(int id)
        {
            Person person = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand { CommandText = $"SELECT * FROM Persons WHERE Id = {id}" };
                var dataReader = command.ExecuteReader();

                if (!dataReader.HasRows) return person;

                while (dataReader.Read())
                {
                    person = new Person
                    {
                        Id = dataReader.GetInt32(0),
                        FirstName = dataReader.GetString(1),
                        LastName = dataReader.GetString(2),
                        Age = dataReader.GetInt32(3)
                    };
                }
            }
            return person;
        }

        public IEnumerable<Person> GetAll()
        {
            var persons = new List<Person>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand { CommandText = "SELECT * FROM Persons" };
                var dataReader = command.ExecuteReader();

                if (!dataReader.HasRows) return persons;

                while (dataReader.Read())
                {
                    var person = new Person
                    {
                        Id = dataReader.GetInt32(0),
                        FirstName = dataReader.GetString(1),
                        LastName = dataReader.GetString(2),
                        Age = dataReader.GetInt32(3)
                    };

                    persons.Add(person);
                }
            }
            return persons;
        }

        public void Create(Person item)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand
                {
                    CommandText = item.Id == 0
                        ? "INSERT INTO Persons (FirstName, LastName, Age) VALUES (@FirstName, @LastName, @Age)"
                        : "UPDATE Persons SET FirstName = @FirstName, LastName = @LastName, Age = @Age"
                };

                var firstNameParam = new SqlParameter("@FirstName", item.FirstName);
                command.Parameters.Add(firstNameParam);

                var lastNameParam = new SqlParameter("@LastName", item.LastName);
                command.Parameters.Add(lastNameParam);

                var ageParam = new SqlParameter("@Age", item.Age);
                command.Parameters.Add(ageParam);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand
                {
                    CommandText = $"DELETE FROM Persons WHERE Id = {id}"
                };

                command.ExecuteNonQuery();
            }
        }

        public void Update(Person item)
        {
            throw new NotImplementedException();
        }
    }
}
