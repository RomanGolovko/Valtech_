using BLL.Abstract;
using BLL.Concrete;
using BLL.DTO;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebUI.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            _kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            _kernel.Bind<IService<PersonDTO>>().To<PersonService>();
        }
    }
}