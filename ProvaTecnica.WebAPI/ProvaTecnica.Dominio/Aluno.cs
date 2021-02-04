using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaTecnica.Dominio
{
    public class Aluno
    {
        [Key]
        public int IdAluno { get; set; }
        public string NomeAluno { get; set; }
        public decimal NotaAluno { get; set; }
        public Turma Turma { get; set; }
        public int IdTurma { get; set; }
    }
}
