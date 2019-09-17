using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class NovidadeRepository
    {
        public List<Novidades> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Novidades.ToList();
            }
        }

        public Novidades BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Novidades.FirstOrDefault(x => x.IdNovidade == id);
            }
        }

        public void Cadastrar(Novidades Novidade)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Novidades.Add(Novidade);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Novidades novidade)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Novidades NovidadeBuscada = ctx.Novidades.FirstOrDefault(x => x.IdNovidade == novidade.IdNovidade);
                NovidadeBuscada.Nome = novidade.Nome;
                NovidadeBuscada.IdMidia = novidade.IdMidia;
                NovidadeBuscada.IdGenero = novidade.IdGenero;
                NovidadeBuscada.Descricao = novidade.Descricao;
                NovidadeBuscada.Lancamento = novidade.Lancamento;
                NovidadeBuscada.IdPlataforma = novidade.IdPlataforma;
                ctx.Novidades.Update(NovidadeBuscada);
                ctx.SaveChanges();
            }
        }
    }
}
