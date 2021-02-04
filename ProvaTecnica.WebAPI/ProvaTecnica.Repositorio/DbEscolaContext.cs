using Microsoft.EntityFrameworkCore;
using ProvaTecnica.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaTecnica.Repositorio
{
    public class DbEscolaContext : DbContext
    {
        public DbEscolaContext(DbContextOptions<DbEscolaContext> options) : base (options) {}

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Escola> Escolas { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
    }
}
