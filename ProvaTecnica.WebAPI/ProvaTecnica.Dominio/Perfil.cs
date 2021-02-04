using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaTecnica.Dominio
{
    public class Perfil
    {
        [Key]
        public int IdPerfil { get; set; }
        public string TipoPerfil { get; set; }
    }
}
