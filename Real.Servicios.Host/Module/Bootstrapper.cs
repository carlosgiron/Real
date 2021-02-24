using Autofac;
using Autofac.Integration.Wcf;
using Real.Servicios.Ioc;


namespace Real.Servicios.Host.Module
{
    public class Bootstrapper
    {
        public static void LoadContainer()
        {
            AutofacHostFactory.Container = Container();
        }
        public static IContainer Container()
        {
            return BootstrapperContainer.ReturnContainer("Real.Servicios", "Real.Aplicacion.Servicios");
        }
    }
}