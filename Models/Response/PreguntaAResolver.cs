using Questionados.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questionados.Models.Response
{
    public class PreguntaAResolver
    {
        public int PreguntaId;
        public string Enunciado;
        public Categoria Categoria;
        public List<OpcionPregunta> Opciones = new List<OpcionPregunta>();

        public static PreguntaAResolver ConvertirDesde(Pregunta pregunta)
        {

            PreguntaAResolver preguntaAResolver = new PreguntaAResolver();

            preguntaAResolver.PreguntaId = pregunta.PreguntaId;
            preguntaAResolver.Enunciado = pregunta.Enunciado;
            preguntaAResolver.Categoria = pregunta.Categoria;

            preguntaAResolver.Opciones = new List<OpcionPregunta>();

            foreach (Respuesta respuesta in pregunta.Opciones)
            {
                OpcionPregunta opcion = new OpcionPregunta();

                opcion.RespuestaId = respuesta.RespuestaId;
                opcion.Texto = respuesta.Texto;

                preguntaAResolver.Opciones.Add(opcion);
            }

            return preguntaAResolver;
        }
    }
}
