using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Parametros
{
    public class RespuestaParametros
    {
        public int NumeroPagina { get; set; }
        public int TamanioPagina { get; set; }

        public RespuestaParametros()
        {
            this.NumeroPagina = 1;
            this.TamanioPagina = 15;
        }
        public RespuestaParametros(int numeroPagina, int tamanioPagina)
        {
            this.NumeroPagina = numeroPagina < 1 ? 1 : numeroPagina;
            this.TamanioPagina = tamanioPagina > 10 ? 10 : tamanioPagina;
        }
    }
}

