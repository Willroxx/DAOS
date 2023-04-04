using Ardalis.Specification;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Aplicacion.Feautres.Libros.Consultas.Especificacion
{
    public class PaginaLibroEspecificacion : Specification<Libro>
    {
        public PaginaLibroEspecificacion(int tamanioPagina, int numeroPagina, string TutuloLibro)
        {
            Query.Skip((numeroPagina - 1) * tamanioPagina)
                .Take(tamanioPagina);

            if (!string.IsNullOrEmpty(TutuloLibro))
            {
                Query.Search(x => x.TituloLibro, "%" + TutuloLibro + "%");
            }
        }
    }
}

