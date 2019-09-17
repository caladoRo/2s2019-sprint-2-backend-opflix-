using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Generos
    {
        public Generos()
        {
            Novidades = new HashSet<Novidades>();
        }

        public int IdGenero { get; set; }
        public string Nome { get; set; }

        public ICollection<Novidades> Novidades { get; set; }
    }
}
