using api_inlock.Domains;
using api_inlock.Interfaces;
using System.Data.SqlClient;

namespace api_inlock.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        //Conexão no SENAI
        //private string StringConexao = "Data Source = NOTE22-S15; Initial Catalog = inlock_games; User Id = sa; Pwd = Senai@134";

        //Conexão em casa
        private string StringConexao = "Data Source = DESKTOP-C6SOG6K\\SQLEXPRESS; Initial Catalog = inlock_games; User Id = sa; Pwd = pPtA3002";

        /// <summary>
        /// Metodo que cadastra um novo jogo
        /// </summary>
        /// <param name="jogo">Jogo que sera cadastrado</param>

        public void Cadastrar(JogoDomain jogo)
        {
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Jogo (Nome, Descricao, DataLancamento, Valor, IdEstudio) VALUES (@Nome, @Descricao, @DataLancamento, @Valor, @IdEstudio)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", jogo.Nome);
                    cmd.Parameters.AddWithValue("@Descricao", jogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", jogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", jogo.Valor);
                    cmd.Parameters.AddWithValue("@IdEstudio", jogo.IdEstudio);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Metodo que deleta um jogo existente
        /// </summary>
        /// <param name="id">Id do jogo que será deletado</param>

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE FROM Jogo WHERE Jogo.IdJogo = @IdJogo";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@IdJogo", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Metodo que lista todos os jogos 
        /// </summary>
        /// <returns>Retorna uma lista com todos os jogos</returns>

        public List<JogoDomain> ListarTodos()
        {
            List<JogoDomain> jogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryGet = "SELECT * FROM Jogo";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryGet, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString(),
                            Descricao = rdr["Descricao"].ToString(),
                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"]),
                            Valor = Convert.ToDecimal(rdr["Valor"]),

                        };

                        jogos.Add(jogo);
                    }

                    return jogos;
                }
            }
        }
    }
}
