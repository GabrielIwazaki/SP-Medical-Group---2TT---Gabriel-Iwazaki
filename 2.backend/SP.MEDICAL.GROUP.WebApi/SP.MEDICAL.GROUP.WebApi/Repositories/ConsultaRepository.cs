using SP.MEDICAL.GROUP.WebApi.Domains;
using SP.MEDICAL.GROUP.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP.MEDICAL.GROUP.WebApi.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        public void AtualizarDados(Consultas novaConsulta, Consultas consultaCadastrada)
        {
            consultaCadastrada.Descricao = novaConsulta.Descricao ?? consultaCadastrada.Descricao;
            consultaCadastrada.IdSituacao = novaConsulta.IdSituacao ?? consultaCadastrada.IdSituacao;

            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                ctx.Consultas.Update(consultaCadastrada);
                ctx.SaveChanges();
            }
        }

        public Consultas BuscarPorId(int id)
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                return ctx.Consultas.Find(id);
            }
        }

        public void Cadastrar(Consultas consulta)
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                ctx.Consultas.Add(consulta);
                ctx.SaveChanges();
            }
        }

        public List<Consultas> ListarConsultas()
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                return ctx.Consultas.ToList();
            }
        }

        public List<Consultas> ListarPorIdMedico(int id)
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                return ctx.Consultas.Where(x => x.IdMedico == id).ToList();
            }
        }

        public List<Consultas> ListarPorIdPaciente(int idPaciente)
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                return ctx.Consultas.Where(x => x.IdProntuario == idPaciente).ToList();
            }
        }
    }
}
