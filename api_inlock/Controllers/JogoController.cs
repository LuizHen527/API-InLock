using api_inlock.Domains;
using api_inlock.Interfaces;
using api_inlock.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_inlock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class JogoController : ControllerBase
    {
        private IJogoRepository _jogoRepository { get; set; }

        public JogoController()
        {
            _jogoRepository = new JogoRepository();
        }

        [HttpPost]

        public IActionResult Post(JogoDomain jogo)
        {
            try
            {
                _jogoRepository.Cadastrar(jogo);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            try
            {
                _jogoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                List<JogoDomain> jogos = _jogoRepository.ListarTodos();

                return Ok(jogos);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

    }
}
