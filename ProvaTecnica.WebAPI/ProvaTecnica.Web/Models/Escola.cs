using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaTecnica.Web.Models
{
    public class Escola
    {
        public int IdEscola { get; set; }
        public string NomeEscola { get; set; }
        public List<Turma> Turmas { get; set; }
    }
}
