using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaTecnica.Dominio
{
    public class Escola
    {
        [Key]
        public int IdEscola { get; set; }
        public string NomeEscola { get; set; }
        public List<Turma> Turmas { get; set; }
    }
}
