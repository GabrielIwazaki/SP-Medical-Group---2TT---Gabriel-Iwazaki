using SP.MEDICAL.GROUP.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP.MEDICAL.GROUP.WebApi.Interfaces
{
    interface IMedicoRepository
    {
        List<Medicos> ListarMedicos();
    }
}
