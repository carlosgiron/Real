using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Real.Servicios.Ioc
{
    public class ServicesModule : Autofac.Module
    {
        public string AssemblyStringService { get; set; }
        public string AssemblyStringApplicationService { get; set; }
        protected override void Load(ContainerBuilder builder)
        {
            //Servicio
            builder.RegisterAssemblyTypes(Assembly.Load(AssemblyStringService))
                .Where(type => type.Name.EndsWith("Servicio", StringComparison.Ordinal))
                .AsImplementedInterfaces();

            //Aplicacion
            builder.RegisterAssemblyTypes(Assembly.Load(AssemblyStringApplicationService))
                .Where(type => type.Name.EndsWith("Servicio", StringComparison.Ordinal))
                .AsImplementedInterfaces();


            //Validacion
            builder.RegisterAssemblyTypes(Assembly.Load(AssemblyStringApplicationService))
                .Where(type => type.Name.EndsWith("Validacion", StringComparison.Ordinal))
                .AsSelf();

            //Proceso
            builder.RegisterAssemblyTypes(Assembly.Load(AssemblyStringApplicationService))
                .Where(type => type.Name.EndsWith("Proceso", StringComparison.Ordinal))
                .AsSelf();

        }

    }
}
