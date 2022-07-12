using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace Tes.API.Autofac
{
    public class AutofacConfig
    {
        public static void RegisteService()
        {
            ContainerBuilder builder = new ContainerBuilder();



            //这一句必须要写,否则会出现Controller没有无参构造函数的错误 ......
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            

            IContainer container = builder.Build();

            // mvc 使用  DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}