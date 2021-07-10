using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Questionados.Entities
{
    [Table("pregunta")] //Indica el nombre de la tabla
    public class Pregunta
    {
        [Key] //Indica que es primary Key
        [Column("pregunta_id")] //Indica el nombre de la columna en la db
        public int PreguntaId { get; set; }


        public string Enunciado { get; set; }


        [Column("categoria_id")] //Esta columna actua como ForeignKey automagicamente
        public int CategoriaId { get; set; }

        //relacion uno a muchos automagicamente
        public Categoria Categoria { get; set; }

        //Relacion uno a muchos automagicamente
        [JsonIgnore]
        public List<Respuesta> Opciones { get; set; } = new List<Respuesta>();


    }
}
