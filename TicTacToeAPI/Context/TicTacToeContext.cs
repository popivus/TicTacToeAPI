using Microsoft.EntityFrameworkCore;
using TicTacToeAPI.Models;

namespace TicTacToeAPI.Context
{
    public class TicTacToeContext : DbContext
    {
        public TicTacToeContext() { }
        public TicTacToeContext(DbContextOptions<TicTacToeContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Game> Game { get; set; }
    }
}
