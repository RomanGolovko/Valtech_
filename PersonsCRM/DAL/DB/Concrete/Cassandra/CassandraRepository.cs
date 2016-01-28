using DAL.DB.Abstract;
using DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using Cassandra;

namespace DAL.DB.Concrete.Cassandra
{
    public class CassandraRepository : IRepository<Person>
    {
        private const string HOST = "localhost";
        private const int PORT = 8081;
        private const string KEYSPACE = "PersonsDB";
        private const string COLUMNFAMILY = "Persons";

        private readonly Cluster _cluster = Cluster.Builder().AddContactPoint(HOST).Build();
        ISession session;
        public CassandraRepository()
        {
            session = _cluster.Connect("personsdb");
        }

        public Person Get(int id)
        {
            var row = session.Execute($"SELECT * FROM persons WHERE id = {id}").FirstOrDefault();
            Person person;
            if (row != null)
            {
                person = new Person
                {
                    Id = (int)row["id"],
                    FirstName = row["firstname"].ToString(),
                    LastName = row["lastname"].ToString(),
                    Age = (int)row["age"]
                };
            }
            else
            {
                person = null;
            }

            return person;
        }

        public IEnumerable<Person> GetAll()
        {
            var rows = session.Execute("SELECT * FROM persons");
            var persons = rows.Select(row => new Person
            {
                Id = (int)row["id"],
                FirstName = row["firstname"].ToString(),
                LastName = row["lastname"].ToString(),
                Age = (int)row["age"]
            }).ToList();

            return persons;
        }

        public void Create(Person person)
        {
            session.Execute("INSERT INTO persons (id, firstname, lastname, age) " +
                            $"values ({person.Id}, '{person.FirstName}', '{person.LastName}', {person.Age})");
        }

        public void Update(Person person)
        {
            session.Execute($"UPDATE persons SET Id = {person.Id}, FirstName = '{person.FirstName}', " +
                            $"LastName = '{person.LastName}', Age  = {person.Age}");
        }

        public void Delete(int id)
        {
            session.Execute($"DELETE FROM persons WHERE Id = {id}");
        }
    }
}
