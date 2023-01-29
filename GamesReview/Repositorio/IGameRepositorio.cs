using GamesReview.Models;

namespace GamesReview.Repositorio
{
    public interface IGameRepositorio
    {
        GameModel BuscarPorId(int id);

        List<GameModel> BuscarTodos();

        GameModel Adicionar(GameModel contato);

        GameModel Atualizar(GameModel contato);

        bool Apagar(int id);
    }
}