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
    [Route("/categorias")]
    public class CategoriaController : ControllerBase
    {
        private readonly ILogger<CategoriaController> _logger;
        private readonly CategoriaService _categoriaService;

        public CategoriaController(ILogger<CategoriaController> logger, CategoriaService categoriaService)
        {
            _logger = logger;
            _categoriaService = categoriaService;

        }

        [HttpGet]
        public ActionResult<List<Categoria>> traerCategorias()
        {

            List<Categoria> categorias = _categoriaService.TraerCategorias();

            return Ok(categorias);

        }

        [HttpGet("{id}")]  //  /categorias/{id}
        public ActionResult<Categoria> traerCategoriaPorId(int id)
        {
            Categoria categoria = _categoriaService.BuscarCategoria(id);

            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }

        [HttpPost]
        public ActionResult<GenericResponse> crearCategoria([FromBody]Categoria categoria)
        {

            GenericResponse gR = new GenericResponse();

            bool categoriaCreada = _categoriaService.CrearCategoria(categoria);

            if (categoriaCreada)
            {
                gR.isOk = true;
                gR.message = "Creaste la categoria exitosamente.";
                gR.id = categoria.CategoriaId;
                return Ok(gR);
            }
            else
            {

                gR.isOk = false;
                gR.message = "No se pudo crear la categoria!";

                return BadRequest(gR);
            }
        }


    }
}
