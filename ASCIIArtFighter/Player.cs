using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIArtFighter
{
    public class Player
    {
        public int Gold { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int PlayerDamage { get; private set; }
        public int PlayerArmor { get; private set; }
        public Weapon Weapon { get; private set; }
        public Armor Armor { get; private set; }

        public Player()
        {
            Gold = 0;
            Health = 100;
            PlayerDamage = 0;
            PlayerArmor = 0;
            MaxHealth = 100;
        }

        public void EquipWeapon(Weapon weapon)
        {
            Weapon = weapon;
            PlayerDamage = weapon.Damage;
        }

        public void EquipArmor(Armor armor)
        {
            Armor = armor;
            PlayerArmor = armor.ArmorPoints;
        }

        public void TakeDamage(int damage)
        {
            Health -= Math.Max(0, damage - PlayerArmor);
            if(Health <= 0)
            {
                Console.Clear();
                var skull = ModelLoader.LoadModel("skull.csv");
                ModelLoader.DrawModelCentered(skull);
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        public void Attack(Enemy enemy, Player player)
        {
            enemy.Health -= Math.Max(0, player.PlayerDamage - enemy.Armor);
        }
    }
}
