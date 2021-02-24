using Autofac;
using Release.Helper.Data.Core;
using Release.Helper.Data.ICore;
using System;
 
using System.Linq;
using System.Configuration;
using System.Reflection;
using Real.Datos.Modelo;
using Real.Datos.Modelo.UnitOfWork;
using Real.Datos.Repositorio;
using Real.Dominio.RepositorioInterfaces;
using Real.Datos.Interfaces.IUnitOfWork;

namespace Real.Servicios.Ioc
{
    public class ContextRepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //string sitRegistryKey = System.Configuration.ConfigurationManager.AppSettings["StringsSIRRegistryKey"];
            string metadata = ConfigurationManager.AppSettings["MetaData"];

            //string sitDbContextValue = (string)RegeditManager.Read(sitRegistryKey, "SirDbContext", false);
            string sitDbContextValue = ConfigurationManager.AppSettings["ConexionString"];
            var source = new ConnectionStringManager().GetEntityConnection(sitDbContextValue, metadata);

            //Context
            builder.RegisterType<ReaDbContext>().Named<IDbContext>("context").WithParameter("nameOrConnectionString", source).InstancePerLifetimeScope();
            //Resolve
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().WithParameter((c, p) => true, (c, p) => p.ResolveNamed<IDbContext>("context"));
            builder.RegisterType<ContextAdapter>().As<IContext>().WithParameter((c, p) => true, (c, p) => p.ResolveNamed<IDbContext>("context"));

            //Repository
            builder.RegisterAssemblyTypes(Assembly.Load("Real.Datos.Repositorio"))
                .Where(type => type.Name.EndsWith("Repository", StringComparison.Ordinal))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Repository<>))
                .As(typeof(IRepository<>))
                .InstancePerDependency();

            base.Load(builder);
        }
    }
}
