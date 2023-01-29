using System.ComponentModel.DataAnnotations;

namespace GamesReview.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite o Email")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Digite a Senha")]
        public String Senha { get; set; }
    }
}
