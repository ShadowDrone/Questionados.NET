using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Questionados.Services;
using Questionados.Models.Response;
using Questionados.Entities;
using Questionados.Models.Request;

namespace Questionados.Controllers
{
    [ApiController]
    [Route("/preguntas")]
    public class PreguntaController : ControllerBase
    {

        private readonly ILogger<CategoriaController> _logger;
        private readonly PreguntaService _preguntaService;

        public PreguntaController(ILogger<CategoriaController> logger, PreguntaService preguntaService)
        {
            _logger = logger;
            _preguntaService = preguntaService;
        }

        [HttpGet]
        public ActionResult<List<Pregunta>> traerPreguntas()
        {

            List<Pregunta> preguntas = _preguntaService.TraerPreguntas();

            return Ok(preguntas);

        }

        [HttpGet("{id}")]
        public ActionResult<Pregunta> traerPreguntaPorId(int id)
        {
            Pregunta pregunta = _preguntaService.BuscarPreguntaPorId(id);

            if (pregunta == null)
            {
                return NotFound();
            }
            return Ok(pregunta);
        }

        [HttpPost]
        public ActionResult crearPregunta([FromBody] InfoPreguntaNueva preguntaNueva)
        {

            GenericResponse respuesta = new GenericResponse();
            Pregunta pregunta = _preguntaService.CrearPregunta(preguntaNueva.Enunciado, preguntaNueva.CategoriaId, preguntaNueva.Opciones);
            respuesta.isOk = true;
            respuesta.id = pregunta.PreguntaId;
            respuesta.message = "La pregunta fue creada con exito";

            return Ok(preguntaNueva);

        }

    }
}
