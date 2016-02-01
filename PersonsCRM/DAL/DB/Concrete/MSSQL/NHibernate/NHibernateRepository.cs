using DAL.DB.Abstract;
using DAL.Entities;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System.Collections.Generic;

namespace DAL.DB.Concrete.NHibernate
{
    public class NHibernateRepository : IRepository<Person>
    {
        private readonly ISessionFactory _session;

        public NHibernateRepository()
        {
            _session = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Roman\Documents\Repository\Valtech_\PersonsCRM\WebUI\App_Data\PersonsDB.mdf;Integrated Security=True")
                .ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<NHibernateRepository>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg)/*.Create(true, true)*/)
                .BuildSessionFactory();
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
                    foreach (var item in person.Phones)
                    {
                        item.Person = person;
                    }
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
