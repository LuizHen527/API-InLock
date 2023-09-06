using api_inlock.Domains;

namespace api_inlock.Interfaces
{
    public interface IEstudioRepository
    {

        /// <summary>
        /// Cadastra um estudio
        /// </summary>
        /// <param name="estudio">Estudio que sera cadastrado</param>

        void Cadastrar(EstudioDomain estudio);


        /// <summary>
        /// Lista todos os estudios existentes no banco de dados
        /// </summary>
        /// <returns>Retorna a lista de estudios</returns>

        List<EstudioDomain> ListarTodos();

        /// <summary>
        /// Deleta um estudio
        /// </summary>
        /// <param name="estudio">Estudio que sera deletado</param>

        void Deletar(int id);
    }
}
