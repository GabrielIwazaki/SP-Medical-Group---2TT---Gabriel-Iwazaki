using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SP.MEDICAL.GROUP.WebApi.Domains;
using SP.MEDICAL.GROUP.WebApi.Interfaces;
using SP.MEDICAL.GROUP.WebApi.Repositories;

namespace SP.MEDICAL.GROUP.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ClinicasController : ControllerBase
    {
        private IClinicaRepository ClinicaRepository { get; set; }

        public ClinicasController()
        {
            ClinicaRepository = new ClinicaRepository();
        }

        
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(ClinicaRepository.ListarClinicas());
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message + "Lascô" });
            }
        }

        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Cadastrar(Clinica clinica)
        {
            try
            {
                ClinicaRepository.CadastrarDados(clinica);
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