using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.WCF;
using Real.Aplicacion.Interfaces;
using Real.Entidades.Request;
using Real.Servicios.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Real.Servicios
{
    [ExceptionShielding]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Single)]
    public class CUACD01Servicio : ICUACD01Servicio
    {
        private readonly ICUACD01AplicacionServicio _cuacd01AplicacionServicio;
        public CUACD01Servicio(ICUACD01AplicacionServicio cuacd01AplicacionServicio)
        {
            _cuacd01AplicacionServicio = cuacd01AplicacionServicio;
        }


        public string Listar(Producto request)
        {
             return _cuacd01AplicacionServicio.Listar(request);
        }
    }
}
