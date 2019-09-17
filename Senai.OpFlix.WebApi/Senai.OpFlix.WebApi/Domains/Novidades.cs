using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Novidades
    {
        public int IdNovidade { get; set; }
        public string Nome { get; set; }
        public int IdMidia { get; set; }
        public int IdGenero { get; set; }
        public string Descricao { get; set; }
        public DateTime Lancamento { get; set; }
        public int IdPlataforma { get; set; }

        public Generos IdGeneroNavigation { get; set; }
        public Midias IdMidiaNavigation { get; set; }
        public Plataformas IdPlataformaNavigation { get; set; }
    }
}
