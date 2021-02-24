using Real.Entidades.Request;
using System.Collections.Generic;
using System.ServiceModel;
 

namespace Real.Servicios.Contratos
{

    [ServiceContract]
    public interface ICUACD01Servicio
    {
        [OperationContract]
        string Listar(Producto producto);
    }

}
