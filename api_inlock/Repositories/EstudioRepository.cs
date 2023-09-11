using api_inlock.Domains;
using api_inlock.Interfaces;
using System.Data.SqlClient;

namespace api_inlock.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        //private string StringConexao = "Data Source = NOTE22-S15; Initial Catalog = inlock_games; User Id = sa; Pwd = Senai@134";

        private string StringConexao = "Data Source = DESKTOP-C6SOG6K\\SQLEXPRESS; Initial Catalog = inlock_games; User Id = sa; Pwd = pPtA3002";

        /// <summary>
        /// Cadastra um estudio
        /// </summary>
        /// <param name="estudio">Estudio que sera cadastrado</param>
        public void Cadastrar(EstudioDomain estudio)
        {
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Estudio (Nome) VALUES (@EstudioNome)";

                con.Open();

                using(SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@EstudioNome", estudio.Nome);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta um estudio
        /// </summary>
        /// <param name="id">Estudio que sera deletado</param>

        public void Deletar(int id)
        {
            using(SqlConnection con = new SqlConnection(StringConexao)) 
            {
                string queryDelete = "DELETE FROM Estudio WHERE Estudio.IdEstudio = @IdEstudio";

                con.Open();

                using(SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@IdEstudio", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os estudios existentes no banco de dados
        /// </summary>
        /// <returns>Retorna a lista de estudios</returns>

        public List<EstudioDomain> ListarTodos()
        {
            List<EstudioDomain> listaEstudio = new List<EstudioDomain>();

            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryGet = "SELECT * FROM Estudio";

                con.Open();

                SqlDataReader rdr;

                using(SqlCommand cmd = new SqlCommand(queryGet, con))
                {
                    rdr= cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString()
                        };

                        listaEstudio.Add(estudio);
                    }

                    return listaEstudio;
                }
            }
        }
    }
}
