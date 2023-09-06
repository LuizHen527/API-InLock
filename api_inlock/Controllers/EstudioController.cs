using api_inlock.Domains;
using api_inlock.Interfaces;
using api_inlock.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace api_inlock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository { get; set; }

        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        /// <summary>
        /// Endpoint que aciona metodo de cadastrar um novo estudio
        /// </summary>
        /// <param name="estudio">Estudio que sera cadastrado</param>
        /// <returns>Retorna statusCode 200</returns>

        [HttpPost]

        public IActionResult Post(EstudioDomain estudio)
        {
            try
            {
                _estudioRepository.Cadastrar(estudio);

                return StatusCode(200, "Cadastrado");
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona metodo para listar todos os estudios
        /// </summary>
        /// <returns>Retorna uma lista com os estudios</returns>

        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                List<EstudioDomain> estudio = _estudioRepository.ListarTodos();

                return Ok(estudio);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Aciona um metodo que deleta um estudio por uma id
        /// </summary>
        /// <param name="id">Id do estudio que sera deletado</param>
        /// <returns>Retorna um StatusCode 204</returns>

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            try
            {
                _estudioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
