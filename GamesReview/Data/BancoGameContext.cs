using GamesReview.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesReview.Data
{
    public class BancoGameContext : DbContext
    {
        public BancoGameContext(DbContextOptions<BancoGameContext> options) : base(options)
        {

        }

        public DbSet<GameModel> Games { get; set; }
    }
}