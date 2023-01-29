using GamesReview.Data;
using GamesReview.Models;

namespace GamesReview.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public UserModel BuscarPorEmail(string email)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper());
        }

        public UserModel BuscarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.ID == id);
        }

        public List<UserModel> BuscarTodos()
        {
           return _bancoContext.Contatos.ToList();
        }

        public UserModel Adicionar(UserModel contato)
        {
            // gravar  no banco de dados
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

        public UserModel Atualizar(UserModel contato)
        {
            UserModel contatoDB = BuscarPorId(contato.ID);

            if (contatoDB == null) throw new System.Exception("Houve um erro na atualização do contato!");

            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;
            contatoDB.Senha = contato.Senha;

            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();

            return contatoDB;
        }

        public bool Apagar(int id)
        {
            UserModel contatoDB = BuscarPorId(id);

            if (contatoDB == null) throw new System.Exception("Houve um erro ao apagar o contato!");

            _bancoContext.Contatos.Remove(contatoDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
