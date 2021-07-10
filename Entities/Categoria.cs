using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Questionados.Entities
{
    [Table("categoria")]
    public class Categoria
    {
        [Key]
        [Column("categoria_id")]
        public int CategoriaId { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        //Relacion uno a muchos automagicamente
        [JsonIgnore]
        public List<Pregunta> Preguntas { get; set; } = new List<Pregunta>();

    }
}