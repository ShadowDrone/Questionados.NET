using Questionados.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questionados.Models.Request
{
    public class InfoPreguntaNueva
    {

        public string Enunciado;

        public List<Respuesta> Opciones;

        public int CategoriaId;
    }
}
