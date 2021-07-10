using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using Questionados.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questionados.Repositories
{
    public class QuestionadosContext : DbContext
    {
        public QuestionadosContext(DbContextOptions<QuestionadosContext> options) : base(options) { }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Pregunta> Preguntas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Opcionalmente se puede configurar todo usando FluentAPI
            //Este caso se usa cuando vienen las clases creadas y no las podemos modificar
            //Pero no va a ser nuestro caso puntual

            ////En este caso dice que la entidad Categoria tiene una tabla "categoria"
            //modelBuilder.Entity<Categoria>().ToTable("categoria");
            ////Que la pk es categoriaId
            //modelBuilder.Entity<Categoria>().HasKey(e => e.CategoriaId);

            //modelBuilder.Entity<Pregunta>().ToTable("pregunta");
            ////Aca, ademas de la PK, dice que la relacion esn uno a Muchos

            /*modelBuilder.Entity<Pregunta>().HasKey(e => e.PreguntaId);
            modelBuilder.Entity<Pregunta>().HasOne(e => e.Categoria).WithMany(e => e.Preguntas);*/
        }
    }
}
