using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real.Entidades
{

    public class StatusResponse<T> : StatusResponse
    {
        public T Data { get; set; }
    }
    //============================================================//
    // Clase de uso Generico , NO agregar mas Propiedades
    //============================================================//
    public class StatusResponse
    {
        public StatusResponse()
        {
            Messages = new List<string>();
        }

        public bool Success { get; set; }

        public object Value { get; set; }

        public List<string> Messages { get; set; } //Lista de Mensajes
    }

}
