using Real.Datos.Interfaces.IUnitOfWork;
using Real.Entidades.Request;
using Release.Helper.Data.Core;
using Release.Helper.Data.ICore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real.Datos.Modelo.UnitOfWork
{
    public partial class UnitOfWork : BaseUnitOfWork, IUnitOfWork
    {
        public UnitOfWork(IDbContext ctx)
       : base(ctx)
        { }
        public string Listar(Producto request)
        {
            var param = new Dictionary<string, object>
            {
                {"@Id",request.Id}

            };
            return ExecuteXmlReader("dbo.USP_LISTA_PRODUCTO", param);
        }


    }
}
