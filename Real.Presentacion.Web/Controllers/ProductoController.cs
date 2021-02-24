using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Real.Entidades.Request;
using Real.Servicios.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real.Presentacion.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly ICUACD01Servicio _ICUACD01Servicio;
        private readonly ILogger<ProductoController> _logger;
        public ProductoController(  ICUACD01Servicio __ICUACD01Servicio)
        {
          
            _ICUACD01Servicio = __ICUACD01Servicio;
        }

        [HttpGet]
        public IActionResult Get(Producto request)
        {
            var response = _ICUACD01Servicio.Listar(request);
            return Ok(response);
        }
    }
}
