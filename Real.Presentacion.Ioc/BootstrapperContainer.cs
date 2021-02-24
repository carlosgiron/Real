using Autofac;
 
namespace Real.Presentacion.Ioc
{
    public class BootstrapperContainer
    {
        public static ContainerBuilder GetContainer()
        {
            var builder = new ContainerBuilder();

            //Modules
            builder.RegisterModule<Other.OtherModule>();
            builder.RegisterModule<Proxy.ProxysModule>();

            return builder;
        }
        public static IContainer Container()
        {
            return GetContainer().Build();
        }
    }
}
