using DAL.DB.Abstract;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Cassandraemon;
using Apache.Cassandra;
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

        public Person Get(int id)
        {
            var session = _cluster.Connect("PersonsDB");
            var row = session.Execute($"SELECT * FROM Persons WHERE Id = {id}").FirstOrDefault();
            var person = new Person
            {
                Id = (int)row["Id"],
                FirstName = row["FirstName"].ToString(),
                LastName = row["LastName"].ToString(),
                Age = (int)row["Age"]
            };

            return person;
        }

        public IEnumerable<Person> GetAll()
        {
            //IEnumerable<Person> persons;
            //using (var context = new CassandraContext(HOST, PORT, KEYSPACE))
            //{
            //    var records = (from x in context.ColumnList where x.ColumnFamily == COLUMNFAMILY select x.ToObject<Person>());
            //    persons = records.ToList().Where(x => x != null).AsEnumerable();
            //}
            var session = _cluster.Connect("PersonsDB");
            var rows = session.Execute("SELECT * FROM Persons");
            var persons = rows.Select(row => new Person
            {
                Id = (int) row["Id"],
                FirstName = row["FirstName"].ToString(),
                LastName = row["LastName"].ToString(),
                Age = (int) row["Age"]
            }).ToList();

            return persons;
        }

        public void Create(Person person)
        {
            var session = _cluster.Connect("PersonsDB");
            session.Execute("INSERT INTO Persons (Id, FirstName, LastName, Age) " +
                            $"values ({person.Id}, {person.FirstName}, {person.LastName}, {person.Age})");
        }

        public void Update(Person person)
        {
            //using (var context = new CassandraContext(HOST, PORT, KEYSPACE))
            //{
            //    var records = new CassandraEntity<List<Column>>().SetColumnFamily(COLUMNFAMILY).SetKey(person.Id).SetData(person);
            //    context.ColumnList.InsertOnSubmit(records);
            //    context.SubmitChanges();
            //}

            var session = _cluster.Connect("PersonsDB");
            session.Execute($"UPDATE Persons SET Id = {person.Id}, FirstName = {person.FirstName}, " +
                            $"LastName = {person.LastName}, Age  = {person.Age}");
        }

        public void Delete(int id)
        {
            //using (var context = new CassandraContext(HOST, PORT, KEYSPACE))
            //{
            //    context.Column.DeleteOnSubmit(x => x.ColumnFamily == COLUMNFAMILY && x.Key == id);
            //    context.SubmitChanges();
            //}
            var session = _cluster.Connect("PersonsDB");
            session.Execute($"DELETE FROM Persons WHERE Id = {id}");
        }
    }
}
