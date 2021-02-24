using Autofac;
using Autofac.Core;
using Release.Helper.File;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Real.Presentacion.Ioc.Other
{
    public class OtherModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Path.GetDirectoryName(Uri.UnescapeDataString(uri.Path)).Replace(@"\bin", @"\Temp");

            string rutaLocal = ConfigurationManager.AppSettings["RutaLocal"];
            //string rutaRemoto = ConfigurationManager.AppSettings["RutaRemoto"];
            string rutaLocalFinal = string.IsNullOrWhiteSpace(rutaLocal) ? path : rutaLocal;
            //Crear rutaLocal si no existe
            if (!Directory.Exists(rutaLocalFinal))
            {
                Directory.CreateDirectory(rutaLocalFinal);
            }

            var param = new List<Parameter>
                {
                    new NamedParameter("localFolder", rutaLocalFinal),
                    new NamedParameter("remoteFolder", null)
                };

            builder.RegisterType<FileManager>().As<IFileManager>().WithParameters(param);
            base.Load(builder);
        }
    }
}
