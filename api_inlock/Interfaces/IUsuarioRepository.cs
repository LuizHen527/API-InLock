using api_inlock.Domains;

namespace api_inlock.Interfaces
{
    public interface IUsuarioRepository
    {
        UsuarioDomain Login(string Email, string Senha);
    }
}
