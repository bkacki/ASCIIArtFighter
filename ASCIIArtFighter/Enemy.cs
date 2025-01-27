using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIArtFighter
{
    public abstract class Enemy
    {
        public int Health { get; set; }
        public int MaxHealth { get; private set; }
        public int Damage { get; private set; }
        public int Armor { get; private set; }
        public int Gold { get; private set; }
        public string Name { get; private set; }

        public abstract string ModelName { get; }


        public Enemy(int health, int damage, int armor, int gold, string name)
        {
            Health = health;
            MaxHealth = health;
            Damage = damage;
            Armor = armor;
            Gold = gold;
            Name = name;
        }
        public void TakeDamage(int damage)
        {
            Health -= Math.Max(0, damage - Armor);
        }

        public void Attack(Player player)
        {
            player.TakeDamage(Damage);
        }

        public void Draw()
        {
            if (!File.Exists(Path.Combine(Environment.CurrentDirectory, "Models", ModelName)))
            {
                Console.WriteLine("Plik z grafiką nie istnieje.");
                return;
            }

            string[] lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Models", ModelName));

            int consoleHeight = Console.WindowHeight;
            int startRow = Math.Max((consoleHeight - lines.Length) / 2, 0);

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine();
            }
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }

    class NoEnemy : Enemy
    {
        public override string ModelName => "placeholder";
        public NoEnemy() : base(0, 0, 0, 0, "No enemy") { }
    }


    public class SmallRat : Enemy
    {
        public SmallRat() : base(20, 10, 3, 25, "Small rat") { }

        public override string ModelName => "smallrat.csv";
    }

    public class BigRat : Enemy
    {
        public BigRat() : base(30, 15, 5, 50, "Big rat") { }

        public override string ModelName => "bigrat.csv";
    }

    public class SmallFrog : Enemy
    {
        public SmallFrog() : base(25, 12, 4, 30, "Small frog") { }

        public override string ModelName => "smallfrog.csv";
    }

    public class BigFrog : Enemy
    {
        public BigFrog() : base(35, 18, 6, 55, "Big frog") { }
        public override string ModelName => "bigfrog.csv";
    }

    public class SmallSpider : Enemy
    {
        public SmallSpider() : base(30, 15, 5, 50, "Small spider") { }
        public override string ModelName => "smallspider.csv";
    }

    public class BigSpider : Enemy
    {
        public BigSpider() : base(40, 20, 7, 75, "Big spider") { }
        public override string ModelName => "bigspider.csv";
    }

    public class SmallDevil : Enemy
    {
        public SmallDevil() : base(50, 25, 10, 100, "Small devil") { }
        public override string ModelName => "smalldevil.csv";
    }

    public class MediumDevil : Enemy
    {
        public MediumDevil() : base(70, 35, 15, 150, "Medium devil") { }
        public override string ModelName => "mediumdevil.csv";
    }

    public class BigDevil : Enemy
    {
        public BigDevil() : base(100, 50, 20, 200, "Big devil") { }
        public override string ModelName => "bigdevil.csv";
    }

    public class  SmallGhost : Enemy
    {
        public SmallGhost() : base(60, 30, 12, 120, "Small ghost") { }
        public override string ModelName => "smallghost.csv";
    }

    public class  BigGhost : Enemy
    {
        public BigGhost() : base(80, 40, 18, 180, "Big ghost") { }
        public override string ModelName => "bigghost.csv";
    }

    public class GhostPack : Enemy
    {
        public GhostPack() : base(100, 50, 25, 250, "Ghost pack") { }
        public override string ModelName => "ghostpack.csv";
    }

    public class Reaper : Enemy
    {
        public Reaper() : base(150, 75, 30, 300, "Reaper") { }
        public override string ModelName => "reaper.csv";
    }

    public class Reaper2 : Enemy
    {
        public Reaper2() : base(200, 100, 40, 400, "Reaper") { }
        public override string ModelName => "reaper2.csv";
    }

    public class  Goblin : Enemy
    {
        public Goblin() : base(120, 60, 20, 200, "Goblin") { }
        public override string ModelName => "goblin1.csv";
    }

    public class Goblin2 : Enemy
    {
        public Goblin2() : base(150, 75, 25, 250, "Goblin") { }
        public override string ModelName => "goblin2.csv";
    }

    public class Skeleton : Enemy
    {
        public Skeleton() : base(130, 65, 22, 220, "Skeleton") { }
        public override string ModelName => "skeleton.csv";
    }

    public class FallenAngel : Enemy
    {
        public FallenAngel() : base(180, 90, 35, 350, "Fallen angel") { }
        public override string ModelName => "fallenangel.csv";
    }

    public class Dragon : Enemy
    {
        public Dragon() : base(250, 125, 50, 500, "Dragon") { }
        public override string ModelName => "dragon.csv";
    }
}
