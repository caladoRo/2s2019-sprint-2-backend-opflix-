using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Domains
{
  public class Favoritos
  {
            public int IdUsuario { get; set; }
            public Cadastros Usuario { get; set; }

            public int IdNovidade { get; set; }
            public Novidades Novidade { get; set; }
  }
    
}
