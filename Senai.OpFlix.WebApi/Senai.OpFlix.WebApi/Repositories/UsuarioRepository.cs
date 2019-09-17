using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class UsuarioRepository
    {
        public Cadastros BuscarPorEmailESenha(LoginViewModel loginViewModel)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Cadastros UsuarioBuscado = ctx.Cadastros.FirstOrDefault(x => x.Email == loginViewModel.Email && x.Senha == loginViewModel.Senha);
                if (UsuarioBuscado == null)
                {
                    return null;
                }
                return UsuarioBuscado;
            }
        }


        public List<Cadastros> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Cadastros.ToList();
            }
        }

        public void Cadastrar(Cadastros Usuario)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Cadastros.Add(Usuario);
                ctx.SaveChanges();
            }
        }
    }
}
