using System;
using System.Collections.Generic;

namespace SP.MEDICAL.GROUP.WebApi.Domains
{
    public partial class Situacao
    {
        public Situacao()
        {
            Consultas = new HashSet<Consultas>();
        }

        public int Id { get; set; }
        public string Tipo { get; set; }

        public ICollection<Consultas> Consultas { get; set; }
    }
}
