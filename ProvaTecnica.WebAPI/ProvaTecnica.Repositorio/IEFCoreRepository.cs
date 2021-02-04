using ProvaTecnica.Dominio;
using ProvaTecnica.Dominio.Helpers;
using ProvaTecnica.WebAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecnica.Repositorio
{
    public interface IEFCoreRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangeAsync();

        //Perfis
        Task <IEnumerable<Perfil>> GetAllPerfis();
        Task<Perfil> GetPerfilById(int id);

        //Usuários
        Task<IEnumerable<Usuario>> GetAllUsuarios();
        Task<Usuario> GetUsuarioById(int id);

        //Escolas
        Task<IEnumerable<Escola>> GetAllEscolas();
        Task<Escola> GetEscolaById(int id);

        //Turmas
        Task<PageList<Turma>> GetAllTurmas(PageParams pageParams);
        Task<Turma> GetTurmaById(int id);
        Task<Turma> GetNotaMedia(int id);

        //Alunos
        Task<PageList<Aluno>> GetAllAlunos(PageParams pageParams);
        Task<Aluno> GetAlunoById(int id);
    }
}
