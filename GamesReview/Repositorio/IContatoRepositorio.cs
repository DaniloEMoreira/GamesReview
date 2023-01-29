using GamesReview.Models;

namespace GamesReview.Repositorio
{
    public interface IContatoRepositorio
    {
        UserModel BuscarPorId(int id);

        UserModel BuscarPorEmail(string Email);

        List<UserModel> BuscarTodos();

        UserModel Adicionar(UserModel contato);

        UserModel Atualizar(UserModel contato);

        bool Apagar(int id);
    }
}