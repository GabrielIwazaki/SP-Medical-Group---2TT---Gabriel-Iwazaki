using SP.MEDICAL.GROUP.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP.MEDICAL.GROUP.WebApi.Interfaces
{
    interface IConsultaRepository
    {
        Consultas BuscarPorId(int id);

        void Cadastrar(Consultas consulta);

        List<Consultas> ListarConsultas();

        List<Consultas> ListarPorIdMedico(int id);

        List<Consultas> ListarPorIdPaciente(int idPaciente);

        void AtualizarDados(Consultas novaConsulta, Consultas consultaCadastrada);

    }
}
