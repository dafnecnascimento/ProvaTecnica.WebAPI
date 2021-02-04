using Microsoft.EntityFrameworkCore;
using ProvaTecnica.Dominio;
using ProvaTecnica.Dominio.Helpers;
using ProvaTecnica.WebAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecnica.Repositorio
{
    public class EFCoreRepository : IEFCoreRepository
    {
        private readonly DbEscolaContext _context;
         
        public EFCoreRepository(DbEscolaContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Perfil> GetPerfilById(int id)
        {
            IQueryable<Perfil> query = _context.Perfil.AsNoTracking().OrderBy(p => p.IdPerfil);
            return await query.FirstOrDefaultAsync(p => p.IdPerfil == id);
        }

        public async Task<IEnumerable<Perfil>> GetAllPerfis()
        {
            IQueryable<Perfil> query = _context.Perfil;
            query = query.AsNoTracking().OrderBy(p => p.IdPerfil);

            return await query.ToArrayAsync();
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuarios()
        {
            IQueryable<Usuario> query = _context.Usuarios;
            query = query.AsNoTracking().OrderBy(u => u.IdUsuario);

            return await query.ToArrayAsync();
        }

        public async Task<Usuario> GetUsuarioById(int id)
        {
            IQueryable<Usuario> query = _context.Usuarios.AsNoTracking().OrderBy(u => u.IdUsuario);
            return await query.FirstOrDefaultAsync(u => u.IdUsuario == id);
        }

        public async Task<IEnumerable<Escola>> GetAllEscolas()
        {
            IQueryable<Escola> query = _context.Escolas;
            query = query.AsNoTracking().OrderBy(e => e.IdEscola);

            return await query.ToArrayAsync();
        }

        public async Task<Escola> GetEscolaById(int id)
        {
            IQueryable<Escola> query = _context.Escolas.AsNoTracking().OrderBy(e => e.IdEscola);
            return await query.FirstOrDefaultAsync(e => e.IdEscola == id);
        }

        public async Task<PageList<Turma>> GetAllTurmas(PageParams pageParams)
        {
            IQueryable<Turma> query = _context.Turmas
                .Include(t => t.Escola);

            //return await query.ToArrayAsync();
            return await PageList<Turma>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }

        public async Task<Turma> GetTurmaById(int id)
        {
            IQueryable<Turma> query = _context.Turmas
                                        .Include(t => t.Escola)
                                        .Include(t => t.Alunos)
                                        .AsNoTracking()
                                        .OrderBy(t => t.IdTurma);
            return await query.FirstOrDefaultAsync(t => t.IdTurma == id);
        }

        public async Task<Turma> GetNotaMedia(int id)
        {
            IQueryable<Turma> query = _context.Turmas.AsNoTracking()
                                                     .Include(t => t.Alunos)
                                                     .OrderBy(t => t.IdTurma);


            return await query.FirstOrDefaultAsync(t => t.IdTurma == id);
        }

        public async Task<PageList<Aluno>> GetAllAlunos(PageParams pageParams)
        {
            IQueryable<Aluno> query = _context.Alunos.Include(a => a.Turma);
            query = query.AsNoTracking().OrderBy(a => a.IdAluno);

            //return await query.ToArrayAsync();
            return await PageList<Aluno>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }

        public async Task<Aluno> GetAlunoById(int id)
        {
            IQueryable<Aluno> query = _context.Alunos
                                        .Include(a => a.Turma)
                                        .AsNoTracking()
                                        .OrderBy(a => a.IdAluno);
            return await query.FirstOrDefaultAsync(a => a.IdAluno == id);
        }
    }
}
