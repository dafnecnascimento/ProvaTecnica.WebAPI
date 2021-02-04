using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaTecnica.Dominio
{
    public class Turma
    {
        [Key]
        public int IdTurma { get; set; }
        public string NomeTurma { get; set; }
        public Escola Escola { get; set; }
        public int IdEscola { get; set; }
        public List<Aluno> Alunos { get; set; }
    }
}
