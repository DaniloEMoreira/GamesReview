using GamesReview.Models;
using GamesReview.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace GamesReview.Controllers
{
    public class LoginController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        public LoginController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel usuario = _contatoRepositorio.BuscarPorEmail(loginModel.Email);

                    if(usuario != null)
                    {
                        if(usuario.SenhaValida(loginModel.Senha))
                        {
                            return RedirectToAction("Index", "Home");

                        }
                        TempData["MensagemErro"] = $"Senha inválida. Por favor, Tente novamente.";
                    }

                    TempData["MensagemErro"] = $"Email e/ou Senha inválido(s). Por favor, Tente novamente.";
                }
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos seu login, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
