using System.Data.Entity;

namespace PokemonWeb.Models
{
    public class PokemonContext : DbContext
    {
        public DbSet<Pokemon> Pokemons { get; set; }
    }
}
// Yaroslav Yachmenov
