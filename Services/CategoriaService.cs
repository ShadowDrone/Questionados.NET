using Microsoft.EntityFrameworkCore;
using Questionados.Entities;
using Questionados.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questionados.Services
{
    public class CategoriaService
    {
        QuestionadosContext repo;

        public CategoriaService(QuestionadosContext repo)
        {
            this.repo = repo;
        }


        public List<Categoria> TraerCategorias()
        {
            //Esto es en JAVA return repo.findAll();
            return repo.Categorias.Include(e => e.Preguntas).ToList();

        }

        public Categoria BuscarCategoria(int id, bool fullObject = false)
        {
            if (fullObject)
                return repo.Categorias.Include(c => c.Preguntas).Where(c => c.CategoriaId == id).FirstOrDefault(); //El includee es para que traiga info de las preguntas
            else
                return repo.Categorias.Find(id);
        }

        public bool CrearCategoria(Categoria categoria)
        {
            if (Existe(categoria.Nombre))
                return false;


            repo.Add(categoria);
            repo.SaveChanges();
            return true;

        }

        public bool Existe(String nombre)
        {
            Categoria categoria = repo.Categorias.FirstOrDefault(c => c.Nombre == nombre);
            return categoria != null;
        }


    }
}
