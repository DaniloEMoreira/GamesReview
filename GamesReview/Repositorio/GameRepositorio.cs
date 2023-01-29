using GamesReview.Data;
using GamesReview.Models;

//https://cdn.discordapp.com/attachments/289905869934690304/1067986857050243142/6400_8_06.jpg

namespace GamesReview.Repositorio
{
    public class GameRepositorio : IGameRepositorio
    {
        private readonly BancoGameContext _bancoGameContext;
        public GameRepositorio(BancoGameContext bancoContext)
        {
            _bancoGameContext = bancoContext;
        }

        public GameModel BuscarPorId(int id)
        {
            return _bancoGameContext.Games.FirstOrDefault(x => x.Id == id);
        }

        public List<GameModel> BuscarTodos()
        {
            return _bancoGameContext.Games.ToList();
        }

        public GameModel Adicionar(GameModel game)
        {
            _bancoGameContext.Games.Add(game);
            _bancoGameContext.SaveChanges();
            return game;
        }

        public bool Apagar(int id)
        {
            GameModel gameDB = BuscarPorId(id);

            if (gameDB == null) throw new System.Exception("Houve um erro ao apagar o contato!");

            _bancoGameContext.Games.Remove(gameDB);
            _bancoGameContext.SaveChanges();

            return true;
        }

        public GameModel Atualizar(GameModel game)
        {
            GameModel gameDB = BuscarPorId(game.Id);

            if (gameDB == null) throw new System.Exception("Houve um erro na atualização do contato!");

            gameDB.Name = game.Name;
            gameDB.Developer = game.Developer;
            gameDB.Description = game.Description;
            gameDB.Price = game.Price;
            gameDB.ReleaseDate = game.ReleaseDate;

            _bancoGameContext.Games.Update(gameDB);
            _bancoGameContext.SaveChanges();

            return gameDB;
        }
    }
}
