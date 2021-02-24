using Autofac;
using Autofac.Builder;
using Autofac.Integration.Wcf;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Real.Presentacion.Ioc.Proxy
{
    public partial class ProxysModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            ServiceProxy(builder);
        }
        private static void ServiceProxy(ContainerBuilder builder)
        {
            /*
             Hosts
             ----------------------------------------------------------------------------------
           
             General         = https://localhost:44316/General/          => Sitio o Host General
      

            */

            NameValueCollection keys = ConfigurationManager.AppSettings;

            string urlGeneral = "General.Host.Url";
            Binding bindingGeneral = ContainerBuilderExtensions.MakeBinding(keys["General.Host.Binding"]);


            //TODO: Colocar Metodo aqui si hay mas modulos
            /****Los Metodos se Generan automaticamente en la Plantilla T4: RegisterProxys.tt***/
            /****Para Nuevos Modulos, Agregue la Carpeta y el NameSpace de Contratos en: RegisterProxys.tt***/
            General_ServiceProxy(builder, new Uri(keys[urlGeneral]), bindingGeneral);
        }
    }
    public static class ContainerBuilderExtensions
    {
        public static IRegistrationBuilder<TChannel, SimpleActivatorData, SingleRegistrationStyle> RegisterServiceProxy<TChannel>(this ContainerBuilder builder, Uri baseUri, Binding binding, string relativeUri)
        {
            builder.Register(c => new ChannelFactory<TChannel>(binding, new EndpointAddress(new Uri(baseUri, relativeUri))))
                   .SingleInstance();

            return builder.Register(c => c.Resolve<ChannelFactory<TChannel>>().CreateChannel())
                   .UseWcfSafeRelease();
        }

        public static Binding MakeBinding(string @bindingName)
        {
            // Bindings Soportados en el Servidor de Servicios

            Binding binding = null;
            switch (@bindingName)
            {
                case "basicHttpBinding":
                    binding = new BasicHttpBinding("proxyHttpBinding");
                    break;

                case "customBinding":
                    binding = new CustomBinding("proxyHttpBinding");
                    break;
            }
            //Es el mismo nombre que el web.config
            return binding;
        }
    }
}
