using Questionados.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questionados.Services
{
    public class QuestionadosService
    {

        protected PreguntaService preguntaService;

        public QuestionadosService(PreguntaService preguntaService)
        {
            this.preguntaService = preguntaService;
        }

        public Pregunta TraerPreguntaRandom()
        {

            List<Pregunta> todasLasPreguntas = preguntaService.TraerPreguntas();
            int min = 1;
            int max = todasLasPreguntas.Count;
            Random randomGenerator = new Random();
            int random = randomGenerator.Next(min, max);
            //return this.hechizos.get(random - 1);
            return todasLasPreguntas[random - 1];

        }

        public bool VerificarRespuesta(int preguntaId, int respuestaId)
        {

            Pregunta pregunta = preguntaService.BuscarPreguntaPorId(preguntaId);

            foreach (Respuesta respuesta in pregunta.Opciones)
            {
                if (respuesta.RespuestaId == respuestaId)
                {
                    return respuesta.EsCorrecta;
                }

            }

            return false;
        }
    }
}
