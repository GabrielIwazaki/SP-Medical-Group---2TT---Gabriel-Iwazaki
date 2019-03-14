using SP.MEDICAL.GROUP.WebApi.Domains;
using SP.MEDICAL.GROUP.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP.MEDICAL.GROUP.WebApi.Repositories
{
    public class ProntuarioRepository : IProntuarioRepository
    {
        public List<Prontuario> ListarProntuarios()
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                return ctx.Prontuario.ToList();
            }
        }
    }
}
