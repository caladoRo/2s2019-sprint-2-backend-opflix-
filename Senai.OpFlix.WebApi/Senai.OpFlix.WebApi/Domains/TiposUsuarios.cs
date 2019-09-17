using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class TiposUsuarios
    {
        public TiposUsuarios()
        {
            Cadastros = new HashSet<Cadastros>();
        }

        public int IdTipo { get; set; }
        public string Nome { get; set; }

        public ICollection<Cadastros> Cadastros { get; set; }
    }
}
