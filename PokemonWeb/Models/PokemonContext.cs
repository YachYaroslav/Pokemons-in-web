using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PokemonWeb.Models
{
    public class PokemonContext : DbContext
    {
        public DbSet<Pokemon> Pokemons { get; set; }
        public int IsId(int Id)
        {
            IEnumerable<Pokemon> pokemons = Pokemons;
            bool is_find = false;
            int ind = 0;
            foreach (var el in pokemons)
            {
                if (el.Id == Id)
                {
                    is_find = true;
                    break;
                }
                ind++;
            }
            if (is_find) return ind;
            return 0;
        }
    }
}
// Yaroslav Yachmenov