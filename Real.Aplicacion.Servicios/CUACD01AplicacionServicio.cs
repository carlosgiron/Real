using Real.Aplicacion.Interfaces;
using Real.Datos.Interfaces.IUnitOfWork;
using Real.Entidades.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real.Aplicacion.Servicios
{
    public class CUACD01AplicacionServicio : ICUACD01AplicacionServicio
    {
        private readonly IUnitOfWork _uOfw;
        public CUACD01AplicacionServicio(IUnitOfWork uOfw)
        {
            _uOfw = uOfw;
        }

        public string Listar(Producto request)
        {
            return _uOfw.Listar(request);
        }
    }
}
