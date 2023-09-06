using api_inlock.Domains;
using api_inlock.Interfaces;

namespace api_inlock.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string StringConexao = "Data Source = NOTE22-S15; Initial Catalog = inlock_games; User Id = sa; Pwd = Senai@134";
        public void Cadastrar(JogoDomain jogo)
        {
            throw new NotImplementedException();
        }

        public void Deletar(JogoDomain jogo)
        {
            throw new NotImplementedException();
        }

        public List<JogoDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
