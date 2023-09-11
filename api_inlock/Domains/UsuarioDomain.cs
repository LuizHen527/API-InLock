using System.ComponentModel.DataAnnotations;

namespace api_inlock.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O campo email é obrigatório!")]
        public string Email { get; set; }


        [Required(ErrorMessage = "O campo senha é obrigatório!")]
        public string Senha { get; set; }

        public string Tipo { get; set; }
    }
}
