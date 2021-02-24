using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real.Servicios.Ioc
{
    public class BootstrapperContainer
    {
        public static IContainer ReturnContainer(string assemblyStringService, string assemblyStringApplicationService)
        {
            var builder = new ContainerBuilder();
            //Modules
            builder.RegisterModule<ContextRepositoryModule>();
            var servicesModule = new ServicesModule
            {
                AssemblyStringService = assemblyStringService,
                AssemblyStringApplicationService = assemblyStringApplicationService
            };
            builder.RegisterModule(servicesModule);

            return builder.Build();
        }
    }
}
