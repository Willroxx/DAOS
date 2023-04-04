using Aplicacion.Parametros;
using Aplicacion.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Feautres.Libros.Consultas.ObtenerTodosLibros
{
    public  class ObtenerTodosLibrosParametros : RespuestaParametros
    {
        public string? TituloLibro { get; set; }
    }
}
