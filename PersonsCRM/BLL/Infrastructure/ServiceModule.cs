using DAL.DB.Abstract;
using DAL.DB.Concrete.LiteDb;
using DAL.DB.Concrete.MSSQL.ADO;
using DAL.DB.Concrete.MSSQL.Dapper;
using DAL.DB.Concrete.MSSQL.EF;
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
            Bind<IUnitOfWork>().To<LiteDbUnitOfWork>();
            //Bind<IUnitOfWork>().To<EfUnitOfWork>().WithConstructorArgument(_connectionString);
            //Bind<IUnitOfWork>().To<DapperUnitOfWork>().WithConstructorArgument(_connectionString);
            //Bind<IUnitOfWork>().To<AdoUnitOfWork>().WithConstructorArgument(_connectionString);
        }
    }
}
