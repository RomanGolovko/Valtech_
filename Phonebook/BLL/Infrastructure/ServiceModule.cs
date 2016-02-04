using DAL.DB.Abstract;
using DAL.DB.Concrete;
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
            Bind<IDalUnitOfWork>().To<EfUnitOfWork>();
        }
    }
}
