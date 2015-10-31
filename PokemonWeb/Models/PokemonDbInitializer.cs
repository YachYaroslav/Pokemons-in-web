// Yaroslav Yachmenov
using System.Data.Entity;

namespace PokemonWeb.Models
{
    public class PokemonDbInitializer : CreateDatabaseIfNotExists<PokemonContext>
    //DropCreateDatabaseAlways
    //CreateDatabaseIfNotExists
    {
        protected override void Seed(PokemonContext db)
        {
            // here you can add something to database before init...           
            base.Seed(db);
        }
    }
}