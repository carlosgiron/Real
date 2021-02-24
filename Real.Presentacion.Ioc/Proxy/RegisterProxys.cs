
//===================================================================================
// Template T4 for WCF Services Proxys
// NO Editar manualmente esta Clase
//===================================================================================
using Autofac;
  
using Real.Servicios.Contratos;
using System;
using System.ServiceModel.Channels;

namespace Real.Presentacion.Ioc.Proxy
{
    public partial class ProxysModule
    {
        //============================================================================================================
        // Registra en el contenedor Instancias de Servicios Proxys para : Real.Servicios.Contratos
        //============================================================================================================
        public static void General_ServiceProxy(ContainerBuilder builder, Uri uriHost, Binding binding)
        {
            builder.RegisterServiceProxy<ICUACD01Servicio>(uriHost, binding, "General/CUACD01Servicio.svc");            
 
        }
 
    }    
}
