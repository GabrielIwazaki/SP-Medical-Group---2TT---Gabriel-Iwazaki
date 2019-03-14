using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SP.MEDICAL.GROUP.WebApi.Interfaces;
using SP.MEDICAL.GROUP.WebApi.Repositories;

namespace SP.MEDICAL.GROUP.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProntuariosController : ControllerBase
    {
        private IProntuarioRepository ProntuarioRepository { get; set; }

        public ProntuariosController()
        {
            ProntuarioRepository = new ProntuarioRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(ProntuarioRepository.ListarProntuarios());
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message + "Lascô" });
            }
        }
    }
}