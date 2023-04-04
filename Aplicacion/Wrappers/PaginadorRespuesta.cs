using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Wrappers
{
    public class PaginadorRespuesta<T> : Respuesta<T>
    {
        public int NumeroPagina { get; set; }
        public int TamanioPagina { get; set; }

        public PaginadorRespuesta(T datos, int numeroPagina, int tamanioPagina)
        {
            this.NumeroPagina = numeroPagina;
            this.TamanioPagina = tamanioPagina;
            this.Datos = datos;
            this.Mensaje = null;
            this.Confirmar = true;
            this.Errors = null;
        }
    }
}

