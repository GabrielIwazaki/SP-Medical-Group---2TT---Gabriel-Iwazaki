using SP.MEDICAL.GROUP.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP.MEDICAL.GROUP.WebApi.Interfaces
{
    interface IClinicaRepository
    {

        /// Cadastra os dados de uma clínica.

        /// <param name="clinica"></param>
        void CadastrarDados(Clinica clinica);


        /// Busca uma clínica por Id.

        /// <param name="idClinica">Id primário da clínica.</param>
        /// <returns>Retorna uma clínica.</returns>
        Clinica BuscarClinicaPorId(int idClinica);

        List<Clinica> ListarClinicas();
    }
}
