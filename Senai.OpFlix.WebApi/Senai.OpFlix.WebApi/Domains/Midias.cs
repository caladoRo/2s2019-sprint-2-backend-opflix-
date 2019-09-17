using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Midias
    {
        public Midias()
        {
            Novidades = new HashSet<Novidades>();
        }

        public int IdMidia { get; set; }
        public string Nome { get; set; }

        public ICollection<Novidades> Novidades { get; set; }
    }
}
