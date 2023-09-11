using api_inlock.Domains;
using api_inlock.Interfaces;
using api_inlock.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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

        /// <summary>
        /// Endpoint que aciona o metodo de cadastrar um jogo
        /// </summary>
        /// <param name="jogo">Jogo que será cadastrado</param>
        /// <returns>Retorna status code 201</returns>

        [HttpPost]
        [Authorize(Roles = "Administrador")]

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

        /// <summary>
        /// Endpoint que aciona o metodo de deletar um jogo
        /// </summary>
        /// <param name="id">Id do jogo que será deletado</param>
        /// <returns>Retorna status code 200 com uma mensagem</returns>

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]

        public IActionResult Delete(int id)
        {
            try
            {
                _jogoRepository.Deletar(id);

                return StatusCode(200, "Deletado");
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo de listar todos os jogos
        /// </summary>
        /// <returns>Retorna uma lista com todos os jogos</returns>

        [HttpGet]
        [Authorize(Roles = "Administrador,Comum")]

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
