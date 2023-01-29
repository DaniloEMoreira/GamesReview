using GamesReview.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesReview.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }
        
        public DbSet<UserModel> Contatos { get; set; }
    }
}
