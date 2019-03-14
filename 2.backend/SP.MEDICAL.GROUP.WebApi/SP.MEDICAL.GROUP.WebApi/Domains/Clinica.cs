using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SP.MEDICAL.GROUP.WebApi.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Medicos = new HashSet<Medicos>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Endereço { get; set; }
        public string RazaoSocial { get; set; }

        public ICollection<Medicos> Medicos { get; set; }
        [NotMapped]
        public object HorarioFuncionamento { get; internal set; }
        [NotMapped]
        public object Localidade { get; internal set; }
    }
}
