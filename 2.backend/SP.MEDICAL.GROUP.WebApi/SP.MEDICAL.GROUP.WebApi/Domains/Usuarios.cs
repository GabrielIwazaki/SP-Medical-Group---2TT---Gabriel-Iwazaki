using System;
using System.Collections.Generic;

namespace SP.MEDICAL.GROUP.WebApi.Domains
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Medicos = new HashSet<Medicos>();
            Prontuario = new HashSet<Prontuario>();
        }

        public int Id { get; set; }
        public int? IdTipoUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public ICollection<Medicos> Medicos { get; set; }
        public ICollection<Prontuario> Prontuario { get; set; }
    }
}
