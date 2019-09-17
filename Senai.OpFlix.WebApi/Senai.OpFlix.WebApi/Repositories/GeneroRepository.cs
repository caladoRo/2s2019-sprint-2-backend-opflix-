using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class GeneroRepository
    {
        public List<Generos> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Favoritos.ToList();
            }
        }

        public void Cadastrar(Generos genero)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Favoritos.Add(genero);
                ctx.SaveChanges();
            }
        }

        public Generos BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Favoritos.FirstOrDefault(x => x.IdGenero == id);
            }
        }

        public void Atualizar(Generos genero)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Generos GeneroBuscado = ctx.Favoritos.FirstOrDefault(x => x.IdGenero == genero.IdGenero);
                GeneroBuscado.Nome = genero.Nome;
                ctx.Favoritos.Update(GeneroBuscado);
                ctx.SaveChanges();
            }
        }
    }
}
