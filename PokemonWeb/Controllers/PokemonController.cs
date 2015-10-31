using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PokemonWeb.Models;

namespace PokemonWeb.Controllers
{
    public class PokemonController : Controller
    {
        PokemonContext db = new PokemonContext();
        public ActionResult Index()
        {
            ViewBag.IdEmpty = true;
            ViewBag.Title = "Додавання покемона";
            ViewBag.ButtonTitle = "Додати!";
            var i = new Pokemon();
            if (!string.IsNullOrEmpty(Request.Params["Id"]))
            {
                int ind; // for index
                int.TryParse(Request.Params["Id"], out ind);
                ind = new WorkWithDb(db).IsId(ind);
                if (ind >= 0)
                {
                    IEnumerable<Pokemon> pokemons = db.Pokemons;
                    i = pokemons.ToArray()[ind];
                    ViewBag.IdEmpty = false;
                    ViewBag.Title = "Редагування покемона"; // change title
                    ViewBag.ButtonTitle = "Перезаписати!";
                    ViewData["Id"] = i.Id;
                }
            }
            ViewBag.CountOfPok = db.Pokemons.Count();
            ViewData["Name"] = i.Name;
            ViewData["Health"] = i.Health;
            ViewData["Damage"] = i.Damage;
            ViewData["Armor"] = i.Armor;
            ViewData["UniqueMove"] = i.UniqueMove;
            return View();
        }

        public ActionResult ListPokemons()
        {
            ViewBag.Title = "Таблиця покемонів";
            ViewBag.CountOfPok = db.Pokemons.Count();
            IEnumerable<Pokemon> pokemons = db.Pokemons;
            pokemons = pokemons.OrderBy(x => x.Name);
            ViewBag.Pokemons = pokemons;
            return View();
        }

        [HttpGet]
        public RedirectToRouteResult DelPokemon(int Id)
        {
            int ind = new WorkWithDb(db).IsId(Id);
            if (ind >= 0) {
                db.Pokemons.Remove(db.Pokemons.Find(Id));
                db.SaveChanges();
            }
            return RedirectToRoute(new { controller = "Pokemon", action = "ListPokemons" });
        }
        [HttpGet]
        public ActionResult ViewPokemon(int Id = -1)
        {
            int ind = new WorkWithDb(db).IsId(Id);
            if (ind >= 0){
                var pokemon = db.Pokemons.Find(Id);
                ViewBag.Pokemon = pokemon;
                return View();
            }
            return RedirectToRoute(new { controller = "Pokemon", action = "ListPokemons" });
        }
        [HttpPost]
        public RedirectToRouteResult AddPokemon(Pokemon pokemon)
        {
            int ind = new WorkWithDb(db).IsId(pokemon.Id);
            if (ind >= 0)
            {
                db.Pokemons.Remove(db.Pokemons.Find(pokemon.Id));
                db.Pokemons.Add(pokemon);
                db.SaveChanges();
                return RedirectToRoute(new { controller = "Pokemon", action = "ListPokemons" });
            }
            db.Pokemons.Add(pokemon);
            db.SaveChanges();
            ViewBag.CountOfPok = db.Pokemons.Count();
            return RedirectToRoute(new { controller = "Pokemon", action = "Index" });
        }

    }
}
// Yaroslav Yachmenov