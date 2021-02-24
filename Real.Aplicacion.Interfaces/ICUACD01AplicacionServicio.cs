using Real.Entidades.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real.Aplicacion.Interfaces
{
    public interface ICUACD01AplicacionServicio
    {
          string Listar(Producto request);
    }
}
