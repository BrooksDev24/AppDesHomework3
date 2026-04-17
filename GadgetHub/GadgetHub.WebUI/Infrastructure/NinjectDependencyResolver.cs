using GadgetHub.Domain.Abstract;
using GadgetHub.Domain.Entities;
using Moq;
using Ninject;
using Ninject.Planning.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GadgetHub.Domain.Concrete;


namespace GadgetHub.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver

    {
        private readonly IKernel mykernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            mykernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type myserviceType)
        {
            return mykernel.TryGet(myserviceType);
        }

        public IEnumerable<object> GetServices(Type myserviceType)
        {
            return mykernel.GetAll(myserviceType);
        }

        private void AddBindings()
        {
            //var myMock = new Mock<IProductRepository>();

            //myMock.Setup(m => m.Products).Returns(new List<Product>
            //{
            //    new Product { Name = "iPhone 15", Brand = "Apple", Price = 999, Description = "Latest Apple smartphone", Category = "Smartphones" },
            //    new Product { Name = "Galaxy S24", Brand = "Samsung", Price = 899, Description = "Flagship Samsung phone", Category = "Smartphones" },
            //    new Product { Name = "MacBook Pro", Brand = "Apple", Price = 1999, Description = "High performance laptop", Category = "Laptops" },
            //    new Product { Name = "Fitbit Charge 6", Brand = "Fitbit", Price = 199, Description = "Advanced fitness tracker", Category = "Wearables" }
            //}.AsQueryable());

            mykernel.Bind<IProductRepository>().To<EFProductRepository>();
        }
    }
}