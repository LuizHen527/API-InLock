using api_inlock.Domains;

namespace api_inlock.Interfaces
{
    public interface IJogoRepository
    {

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="jogo">Novo jogo que sera cadastrado</param>

        void Cadastrar(JogoDomain jogo);

        /// <summary>
        /// Lista todos os jogos existentes
        /// </summary>
        /// <returns>Retorna uma lista com todos os jogos</returns>

        List<JogoDomain> ListarTodos();

        /// <summary>
        /// Deleta um jogo
        /// </summary>
        /// <param name="jogo">Jogo que sera deletado</param>

        void Deletar(JogoDomain jogo);
    }
}
