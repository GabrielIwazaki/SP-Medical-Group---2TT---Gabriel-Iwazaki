using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SP.MEDICAL.GROUP.WebApi.Domains;
using SP.MEDICAL.GROUP.WebApi.Interfaces;
using SP.MEDICAL.GROUP.WebApi.Repositories;

namespace SP.MEDICAL.GROUP.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private IConsultaRepository ConsultaRepository { get; set; }

        public ConsultasController()
        {
            ConsultaRepository = new ConsultaRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(ConsultaRepository.ListarConsultas());
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message + "Lascô" });
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Consultas consulta)
        {
            try
            {
                ConsultaRepository.Cadastrar(consulta);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message + "Lascô" });
            }
        }

        [HttpGet("medico/{id}")]
        public IActionResult ListarPorMedico(int id)
        {
            try
            {
                return Ok(ConsultaRepository.ListarPorIdMedico(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Erro: " + ex
                });
            }
        }
        [HttpGet]
        [Authorize(Roles = "2,3")]
        [Route("Usuario")]
        public IActionResult ListarMeus()
        {
            try
            {
                int usuarioId = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                int RoleId = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Role).Value);

                if (RoleId == 2)
                {
                    using (SPMedGroupContext ctx = new SPMedGroupContext())
                    {
                        Medicos medicoLogado = ctx.Medicos.FirstOrDefault(X => X.IdUsuario == usuarioId);

                        return Ok(ConsultaRepository.ListarPorIdMedico(medicoLogado.Id));
                    }
                }
                else if (RoleId == 3)
                {
                    using (SPMedGroupContext ctx = new SPMedGroupContext())
                    {
                        Prontuario pacienteLogado = ctx.Prontuario.FirstOrDefault(x => x.IdUsuario == usuarioId);

                        return Ok(ConsultaRepository.ListarPorIdPaciente(pacienteLogado.Id));
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        [Authorize(Roles = "2")]
        [HttpPut]
        public IActionResult Atualizar(Consultas novaConsulta)
        {
            try
            {
                Consultas consultaCadastrada = ConsultaRepository.BuscarPorId(novaConsulta.Id);

                if (consultaCadastrada == null)
                {
                    return NotFound(new
                    {
                        mensagem = "Consulta não encontrada"
                    });
                }

                ConsultaRepository.AtualizarDados(novaConsulta, consultaCadastrada);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Erro: " + ex
                });
            }
        }
    }
}