using api_inlock.Domains;
using api_inlock.Interfaces;
using api_inlock.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace api_inlock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Endpoint que aciona o metodo de login
        /// </summary>
        /// <param name="usuario">Usuario que sera autenticado</param>
        /// <returns>Retorna um token</returns>

        [HttpPost]

        public IActionResult Login(UsuarioDomain usuario)
        {
            try
            {
                UsuarioDomain usuarioEncontrado = _usuarioRepository.Login(usuario.Email, usuario.Senha);

                if (usuarioEncontrado == null)
                {
                    return NotFound("Email ou Senha Inválidos !");
                }

                var claims = new[]
                {
                    //formato da claim
                    new Claim(JwtRegisteredClaimNames.Jti,usuarioEncontrado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,usuarioEncontrado.Email),
                    new Claim(ClaimTypes.Role,usuarioEncontrado.Tipo),
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-autenticacao-webapi-dev"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                (
                    //emissor do token
                    issuer: "api_inlock",

                    //destinatário do token
                    audience: "api_inlock",

                    //dados definidos nas claims(informações)
                    claims: claims,

                    //tempo de expiração do token
                    expires: DateTime.Now.AddMinutes(5),

                    //credenciais do token
                    signingCredentials: creds
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
