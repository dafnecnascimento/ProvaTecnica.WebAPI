using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaTecnica.Dominio
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public Perfil Perfil { get; set; }
        public int IdPerfil { get; set; }
    }
}
