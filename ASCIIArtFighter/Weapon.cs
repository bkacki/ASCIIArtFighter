using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIArtFighter
{
    public abstract class Weapon
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Cost { get; set; }

        public Weapon(string name, int damage, int cost)
        {
            Name = name;
            Damage = damage;
            Cost = cost;
        }
    }

    public class WeaponGenerator
    {
        public IEnumerable<Weapon> GenerateWeapons()
        {
            yield return new Fists();
            yield return new Dagger();
            yield return new Sword();
            yield return new LongSword();
            yield return new GreatSword();
            yield return new WarAxe();
            yield return new WarHammer();
            yield return new Spear();
        }
    }

    public class Fists : Weapon
    {
        public Fists() : base("Fists", 10, 0) {}
    }

    public class Dagger : Weapon
    {
        public Dagger() : base("Dagger", 25, 75) { }
    }

    public class Sword : Weapon
    {
        public Sword() : base("Sword", 50, 150) { }
    }

    public class LongSword : Weapon
    {
        public LongSword() : base("Long Sword", 100, 250) { }
    }

    public class GreatSword : Weapon
    {
        public GreatSword() : base("Great Sword", 200, 500) { }
    }

    public class WarAxe : Weapon
    {
        public WarAxe() : base("War Axe", 300, 750) { }
    }

    public class WarHammer : Weapon
    {
        public WarHammer() : base("War Hammer", 400, 1000) { }
    }

    public class Spear : Weapon
    {
        public Spear() : base("Spear", 500, 1250) { }
    }
}
