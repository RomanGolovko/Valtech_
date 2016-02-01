using DAL.DB.Abstract;
using DAL.DB.Concrete.Cassandra;
using DAL.DB.Concrete.LiteDB;
using DAL.DB.Concrete.MSSQL.ADO;
using DAL.DB.Concrete.MSSQL.Dapper;
using DAL.DB.Concrete.MSSQL.EF;
using DAL.DB.Concrete.Neo4j;
using DAL.DB.Concrete.NHibernate;
using DAL.Entities;
using Ninject.Modules;

namespace BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private readonly string _connectionString;

        public ServiceModule(string connection)
        {
            _connectionString = connection;
        }

        public override void Load()
        {
            //Bind<IRepository<Person>>().To<LiteDbRepository>();
            Bind<IRepository<Person>>().To<EfRepository>().WithConstructorArgument(_connectionString);
            //Bind<IRepository<Person>>().To<NHibernateRepository>();
            //Bind<IRepository<Person>>().To<DapperRepository>();
            //Bind<IRepository<Person>>().To<AdoRepository>();
            //Bind<IRepository<Person>>().To<RedisRepository>();
            //Bind<IRepository<Person>>().To<CassandraRepository>();
            //Bind<IRepository<Person>>().To<Neo4jRepository>();
        }
    }
}
 