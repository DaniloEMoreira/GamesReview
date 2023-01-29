using GamesReview.Models;
using GamesReview.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GamesReview.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGameRepositorio _gameRepositorio;

        public HomeController(IGameRepositorio gameRepositorio)
        {
            _gameRepositorio = gameRepositorio;
        }
        public IActionResult Index()
        {
            List<GameModel> games = _gameRepositorio.BuscarTodos();
            return View(games);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            GameModel game = _gameRepositorio.BuscarPorId(id);
            return View(game);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            GameModel game = _gameRepositorio.BuscarPorId(id);
            return View(game);
        }

        public IActionResult Apagar(int id)
        {
            _gameRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(GameModel game)
        {
            _gameRepositorio.Adicionar(game);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Alterar(GameModel game)
        {
            _gameRepositorio.Atualizar(game);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}