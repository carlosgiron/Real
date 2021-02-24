
using Release.Helper.Data.Core;
using Release.Helper.Data.ICore;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real.Datos.Modelo
{
    public partial class ReaDbContext
    {
        private string _jsonAutenticado;
        private EntityAudit[] _records;
        public void SaveChanges(string jsonAuthN)
        {
            _records = new AuditDbContext(((IObjectContextAdapter)this).ObjectContext).Records(this.ChangeTracker);
            _jsonAutenticado = jsonAuthN;
        }
        public void SaveAudit()
        {
             
        }
    }
}
