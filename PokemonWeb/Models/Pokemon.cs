namespace PokemonWeb.Models
{
    public class Pokemon
    {
        public Pokemon()
        {
            Name = "Покемон";
            Damage = 2;
            Armor = 5;
            UniqueMove = 3;
            Moves = 0;
            Die = false;
            _health = 10;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
        public int UniqueMove { get; set; }
        public int Moves;
        public bool Die;
        private int _health;
        public int Health
        {
            get { return _health; }
            set
            {
                if (value <= 0) Die = true;
                else _health = value;
            }
        }

        public virtual void Move()
        {
            if (Health <= 10) Health++;
            Moves++;
        }
        public virtual void Kick(Pokemon enemy)
        {
            if (enemy.Armor > 0)
            {
                enemy.Armor -= Damage;
                if (enemy.Armor < 0) enemy.Health += enemy.Armor;
            }
            else
            {
                enemy.Health -= Damage;
            }
        }
    }
}
// Yaroslav Yachmenov
