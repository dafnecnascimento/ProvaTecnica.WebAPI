using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaTecnica.Web.Models
{
    public class Turma
    {
        public int IdTurma { get; set; }
        public string NomeTurma { get; set; }
        public Escola Escola { get; set; }
        public int IdEscola { get; set; }
        public List<Aluno> Alunos { get; set; }
        public decimal MediaNotas { get; set; }
    }
}
