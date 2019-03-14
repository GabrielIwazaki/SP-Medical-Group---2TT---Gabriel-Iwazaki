using System;
using System.Collections.Generic;

namespace SP.MEDICAL.GROUP.WebApi.Domains
{
    public partial class Prontuario
    {
        public Prontuario()
        {
            Consultas = new HashSet<Consultas>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int? IdUsuario { get; set; }
        public DateTime DtNascimento { get; set; }
        public string Telefone { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Endereço { get; set; }

        public Usuarios IdUsuarioNavigation { get; set; }
        public ICollection<Consultas> Consultas { get; set; }
    }
}
