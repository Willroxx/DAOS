using Aplicacion.DTOs;
using Aplicacion.Feautres.Libros.Consultas.Especificacion;
using Aplicacion.Interfaces;
using Aplicacion.Wrappers;
using AutoMapper;
using Dominio.Entidades;
using MediatR;

namespace Aplicacion.Feautres.Libros.Consultas.ObtenerTodosLibros
{
    public class ObtenerTodosLibros  : IRequest<PaginadorRespuesta<List<LibrosDTO>>>
    {
        public int NumeroPagina { get; set; }
        public int TamanioPagina { get; set; }
        public string TituloLibro { get; set; }

        public class ObtenerTodosLibrosHandler : IRequestHandler<ObtenerTodosLibros, PaginadorRespuesta<List<LibrosDTO>>>
        {
            private readonly IRepositorioAsincrono<Libro> _repositorioAsincrono;
            private readonly IMapper _mapper;


            public ObtenerTodosLibrosHandler(IRepositorioAsincrono<Libro> repositorioAsincrono, IMapper mapper)
            {
                _repositorioAsincrono = repositorioAsincrono;
                _mapper = mapper;
            }
            public async Task<PaginadorRespuesta<List<LibrosDTO>>> Handle(ObtenerTodosLibros request, CancellationToken cancellationToken)
            {
                var libros = await _repositorioAsincrono.ListAsync(new PaginaLibroEspecificacion(request.TamanioPagina, request.NumeroPagina, request.TituloLibro));
                var librosdto = _mapper.Map<List<LibrosDTO>>(libros);

                return new PaginadorRespuesta<List<LibrosDTO>>(librosdto, request.NumeroPagina, request.TamanioPagina);
            }


        }
    }
}
