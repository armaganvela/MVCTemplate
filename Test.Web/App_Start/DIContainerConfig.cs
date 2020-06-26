using Autofac;
using Autofac.Integration.Mvc;
using Interfaces;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Interfaces;
using Test.Services;
using Test.Sql;
using Test.Web.Models;

namespace Test.Web.App_Start
{
    public class DIContainerConfig
    {
        public class ContainerConfig
        {
            internal static void RegisterContainer()
            {
                var builder = new ContainerBuilder();

                builder.RegisterControllers(typeof(MvcApplication).Assembly);

                builder.RegisterType<ProductService>()
                    .As<IProductService>()
                    .InstancePerRequest();

                builder.RegisterType<ImageService>()
                    .As<IImageService>()
                    .InstancePerRequest();

                builder.RegisterType<UserService>()
                    .As<IUserService>()
                    .InstancePerRequest();

                builder.RegisterType<ApplicationDbContext>()
                    .InstancePerRequest();

                var container = builder.Build();
                DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            }
        }
    }
}