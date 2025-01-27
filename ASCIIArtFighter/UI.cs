using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIArtFighter
{
    internal class UI
    {
        public static void DrawPlayer(Player player)
        {
            Console.Clear();

            string health = $"HP: {player.Health}/{player.MaxHealth}";
            string damage = $"Damage: {player.PlayerDamage}";
            string armor = $"Armor: {player.PlayerArmor}";
            string weapon = $"Weapon: {player.Weapon.Name}";
            string gold = $"Gold: {player.Gold}";

            int consoleWidth = Console.WindowWidth;

            string leftStats = $"{health}   {damage} {armor}    {weapon}";
            int leftStatsLength = leftStats.Length;

            int padding = consoleWidth - leftStatsLength - gold.Length;

            Console.WriteLine(leftStats + new string(' ', Math.Max(0, padding)) + gold);
        }

        public static void DrawEnemy(Enemy enemy)
        {
            enemy.Draw();
            Console.WriteLine();
            Console.WriteLine(enemy.Name);
            Console.WriteLine($"HP: {enemy.Health}/{enemy.MaxHealth}");
            Console.WriteLine($"Damage: {enemy.Damage}  Armor: {enemy.Armor}");
        }

        public static void DrawMenu()
        {
            string menuText = "Press [Space] to attack.";
            int consoleWidth = Console.WindowWidth;
            int menuTextLength = menuText.Length;

            int centeredPos = (consoleWidth - menuTextLength) / 2;

            int lastRow = Console.WindowHeight - 2;
            Console.SetCursorPosition(centeredPos, lastRow);
            Console.Write(menuText);
            DisableCursor();
        }

        public static void DisableCursor()
        {
            Console.CursorVisible = false;
        }

        public static void EnableCursor()
        {
            Console.CursorVisible = true;
        }
    }
}
