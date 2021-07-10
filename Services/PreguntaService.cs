using Microsoft.EntityFrameworkCore;
using Questionados.Entities;
using Questionados.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questionados.Services
{
    public class PreguntaService
    {
        protected readonly CategoriaService categoriaService;
        protected readonly QuestionadosContext repo;

        public PreguntaService(CategoriaService categoriaService, QuestionadosContext repo)
        {
            this.categoriaService = categoriaService;
            this.repo = repo;
        }


        public Pregunta BuscarPreguntaPorId(int id)
        {
                return repo.Preguntas.Include(p => p.Opciones).Where(p => p.PreguntaId == id).FirstOrDefault(); //El includee es para que traiga info de las respuestas
            
        }

        public List<Pregunta> TraerPreguntas()
        {
            return repo.Preguntas.Include(e => e.Opciones).ToList();

        }

        public Pregunta CrearPregunta(String enunciado, int categoriaId, List<Respuesta> opciones)
        {

            Pregunta pregunta = new Pregunta();
            pregunta.Enunciado = enunciado;

            Categoria categoria = categoriaService.BuscarCategoria(categoriaId);

            pregunta.Categoria = categoria;

            pregunta.Opciones = opciones;

            repo.Add(pregunta);
            repo.SaveChanges();

            return pregunta;
        }
    }
}
