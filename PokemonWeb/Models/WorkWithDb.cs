using System.Collections.Generic;
// Yaroslav Yachmenov
namespace PokemonWeb.Models
{
    public class WorkWithDb
    {
        public WorkWithDb(PokemonContext _db)
        {
            db = _db;
        }
        PokemonContext db;
        public int IsId(int Id)
        {
            IEnumerable<Pokemon> pokemons = db.Pokemons;
            int index = 0;
            foreach (var el in pokemons){
                if (el.Id == Id){
                    return index;
                }
                index++;
            }
            return -1;
        }
    }
}