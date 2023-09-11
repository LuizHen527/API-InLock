using api_inlock.Domains;
using api_inlock.Interfaces;
using System.Data.SqlClient;

namespace api_inlock.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string StringConexao = "Data Source = NOTE22-S15; Initial Catalog = inlock_games; User Id = sa; Pwd = Senai@134";
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
