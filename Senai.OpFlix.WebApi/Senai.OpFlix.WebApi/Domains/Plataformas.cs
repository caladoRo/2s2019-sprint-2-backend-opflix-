using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Plataformas
    {
        public Plataformas()
        {
            Novidades = new HashSet<Novidades>();
        }

        public int IdPlataforma { get; set; }
        public string Nome { get; set; }

        public ICollection<Novidades> Novidades { get; set; }
    }
}
