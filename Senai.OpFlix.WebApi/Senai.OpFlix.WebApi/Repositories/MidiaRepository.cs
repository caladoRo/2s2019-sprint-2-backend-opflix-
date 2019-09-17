using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class MidiaRepository
    {
        public List<Midias> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Midias.ToList();
            }
        }

        public void Cadastrar(Midias midia)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Midias.Add(midia);
                ctx.SaveChanges();
            }
        }

        public Midias BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Midias.FirstOrDefault(x => x.IdMidia == id);
            }
        }

        public void Atualizar(Midias midia)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Midias MidiaBuscada = ctx.Midias.FirstOrDefault(x => x.IdMidia == midia.IdMidia);
                MidiaBuscada.Nome = midia.Nome;
                ctx.Midias.Update(MidiaBuscada);
                ctx.SaveChanges();
            }
        }

    }
}
