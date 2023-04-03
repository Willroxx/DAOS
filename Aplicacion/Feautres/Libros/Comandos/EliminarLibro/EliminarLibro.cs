﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.Interfaces;
using Aplicacion.Wrappers;
using Dominio.Entidades;
using MediatR;

namespace Aplicacion.Feautres.Libros.Comandos.EliminarLibro
{
    public class EliminarLibro: IRequest<Respuesta<int>>
    {
        public int Id { get; set; }
    }

    public class EliminarLibroHandler : IRequestHandler <EliminarLibro, Respuesta<int>> 
    {
        private readonly IRepositorioAsincrono<Libro> _repositorioAsincrono;

        public EliminarLibroHandler(IRepositorioAsincrono<Libro> repositorioAsincrono)
        {
            _repositorioAsincrono = repositorioAsincrono;
        }

        public async Task<Respuesta<int>> Handle(EliminarLibro request, CancellationToken cancellationToken)
        {
            var libro = await _repositorioAsincrono.GetByIdAsync(request.Id);

            if (libro == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");

            }
            else
            {
                await _repositorioAsincrono.DeleteAsync(libro);

                return new Respuesta<int>(libro.Id);
            }
        }

    }
}
