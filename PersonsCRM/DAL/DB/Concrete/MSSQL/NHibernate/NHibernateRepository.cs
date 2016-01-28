using DAL.DB.Abstract;
using DAL.Entities;
using NHibernate;
using NHibernate.Cfg;
using System.Collections.Generic;

namespace DAL.DB.Concrete.NHibernate
{
    public class NHibernateRepository : IRepository<Person>
    {
        private readonly ISessionFactory _session;

        public NHibernateRepository()
        {
            var config = new Configuration();
            config.Configure();
            config.AddAssembly(typeof(Person).Assembly);
            _session = config.BuildSessionFactory();
        }

        public Person Get(int id)
        {
            Person person;

            using (var currentSession = _session.OpenSession())
            {
                person = currentSession.Get<Person>(id);
            }

            return person;
        }

        public IEnumerable<Person> GetAll()
        {
            IList<Person> persons;

            using (var currentSession = _session.OpenSession())
            {
                persons = currentSession.CreateCriteria<Person>().List<Person>();
            }

            return persons;
        }

        public void Create(Person person)
        {
            using (var currentSession = _session.OpenSession())
            {
                using (var transact = currentSession.BeginTransaction())
                {
                    currentSession.Save(person);
                    transact.Commit();
                }
            }
        }

        public void Update(Person person)
        {
            using (var currentSession = _session.OpenSession())
            {
                using (var transact = currentSession.BeginTransaction())
                {
                    currentSession.Update(person);
                    transact.Commit();
                }
            }
        }

        public void Delete(int id)
        {
            using (var currentSession = _session.OpenSession())
            {
                using (var transact = currentSession.BeginTransaction())
                {
                    var person = currentSession.Get<Person>(id);
                    currentSession.Delete(person);
                    transact.Commit();
                }
            }
        }
    }
}
