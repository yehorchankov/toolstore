#region

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Ninject;
using ToolStore.Domain.Abstract;
using ToolStore.Domain.Concrete;

#endregion

namespace ToolStore.UI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
            AddBinding();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void AddBinding()
        {
            //Bindings
            _kernel.Bind<IProductRepository>().To<ProductRepository>();

            EmailCredential emailCredential = GetCredentialFromConfig();
            _kernel.Bind<IOrderHandler>().To<OrderHandler>()
                .WithConstructorArgument("credential", emailCredential);
        }

        private EmailCredential GetCredentialFromConfig()
        {
            EmailCredential credential = new EmailCredential
            {
                Email = ConfigurationManager.AppSettings["email.credentials.email"],
                Host = ConfigurationManager.AppSettings["email.credentials.host"],
                Password = ConfigurationManager.AppSettings["email.credentials.pass"],
                Port = int.Parse(ConfigurationManager.AppSettings["email.credentials.port"]),
                UseSsl = bool.Parse(ConfigurationManager.AppSettings["email.credentials.ssl"]),
                Username = ConfigurationManager.AppSettings["email.credentials.user"],
                OwnerEmail = ConfigurationManager.AppSettings["email.credentials.owner"]
            };

            return credential;
        }
    }
}