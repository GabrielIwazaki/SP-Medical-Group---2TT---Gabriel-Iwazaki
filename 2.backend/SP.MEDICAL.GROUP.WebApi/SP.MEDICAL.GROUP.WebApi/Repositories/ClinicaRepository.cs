using SP.MEDICAL.GROUP.WebApi.Domains;
using SP.MEDICAL.GROUP.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP.MEDICAL.GROUP.WebApi.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        public void AtualizarDados(Clinica novaClinica, Clinica clinicaCadastrada)
        {
            clinicaCadastrada.Localidade = novaClinica.Localidade ?? clinicaCadastrada.Localidade;

            clinicaCadastrada.HorarioFuncionamento = novaClinica.HorarioFuncionamento ?? clinicaCadastrada.HorarioFuncionamento;

            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                ctx.Clinica.Update(clinicaCadastrada);
                ctx.SaveChanges();
            }
        }

        public void CadastrarDados(Clinica clinica)
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                ctx.Clinica.Add(clinica);
                ctx.SaveChanges();
            }
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public List<Clinica> ListarClinicas()
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                return ctx.Clinica.ToList();
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }

        Clinica IClinicaRepository.BuscarClinicaPorId(int idClinica)
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                return ctx.Clinica.Find(idClinica);
            }
        }
    }
}
