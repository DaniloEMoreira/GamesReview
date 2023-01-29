namespace GamesReview.Models
{
    public class UserModel
    {   
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Senha { get; set; }

        public bool SenhaValida(String senha)
        {
            return Senha == senha;
        }

    }
}
