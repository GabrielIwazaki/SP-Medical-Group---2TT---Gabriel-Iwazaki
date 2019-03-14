using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SP.MEDICAL.GROUP.WebApi.Domains
{
    public partial class Consultas
    {
        public int Id { get; set; }
        public int? IdProntuario { get; set; }
        public int? IdMedico { get; set; }
        public DateTime DtConsulta { get; set; }
        public int? IdSituacao { get; set; }
        public string Descricao { get; set; }

        public Medicos IdMedicoNavigation { get; set; }
        public Prontuario IdProntuarioNavigation { get; set; }
        public Situacao IdSituacaoNavigation { get; set; }
        [NotMapped]
        public object Id_Situacao { get; internal set; }
        [NotMapped]
        public object Observacoes { get; internal set; }
    }
}
