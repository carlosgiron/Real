using Newtonsoft.Json;
using Release.Helper.Data.ICore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real.Datos.Interfaces
{
    public static class ExtensionBaseUnitOfWork
    {
        public static int Save(this IBaseUnitOfWork baseUnitOfWork, dynamic medatada)
        {
            return baseUnitOfWork.Save(JsonConvert.SerializeObject(medatada));
        }
    }
}
