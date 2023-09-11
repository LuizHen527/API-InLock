using api_inlock.Domains;
using api_inlock.Interfaces;
using System.Data.SqlClient;

namespace api_inlock.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        //Conexão no SENAI
        //private string StringConexao = "Data Source = NOTE22-S15; Initial Catalog = inlock_games; User Id = sa; Pwd = Senai@134";

        //Conexão em casa
        private string StringConexao = "Data Source = DESKTOP-C6SOG6K\\SQLEXPRESS; Initial Catalog = inlock_games; User Id = sa; Pwd = pPtA3002";


        /// <summary>
        /// Metodo que compara a senha e email com os mesmos do banco de dados
        /// </summary>
        /// <param name="Email">Email que será comparado</param>
        /// <param name="Senha">Senha que será comparada</param>
        /// <returns></returns>

        public UsuarioDomain Login(string Email, string Senha)
        {
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryLogin = "SELECT Email, Senha, IdUsuario, Titulo FROM Usuario INNER JOIN TiposUsuario ON Usuario.IdTipoUsuario = TiposUsuario.IdTipoUsuario WHERE Email = @Email AND Senha = @Senha";

                con.Open();

                SqlDataReader rdr;

                using(SqlCommand cmd = new SqlCommand(queryLogin, con))
                {
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Senha", Senha);

                    cmd.ExecuteNonQuery();

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain
                        {
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            Email = rdr["Email"].ToString(),
                            Senha = rdr["Senha"].ToString(),
                            Tipo = rdr["Titulo"].ToString()

                        };

                        return usuario;
                    }

                    else
                    {
                        return null;
                    }
                }
            }
        }
    }
}
