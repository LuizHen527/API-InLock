using api_inlock.Domains;
using api_inlock.Interfaces;
using System.Data.SqlClient;

namespace api_inlock.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data Source = NOTE22-S15; Initial Catalog = Filmes; User Id = sa; Pwd = Senai@134";
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
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            IdUsuario = Convert.ToInt32(rdr[0]),
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
