using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ASCIIArtFighter
{
    class Program
    {
        private const int ConsoleWidth = 80;
        private const int ConsoleHeight = 21;
        private static WeaponGenerator weaponGenerator = new WeaponGenerator();
        private static Queue<Weapon> weapons = new Queue<Weapon>(weaponGenerator.GenerateWeapons());
        private static ArmorGenerator armorGenerator = new ArmorGenerator();
        private static Queue<Armor> armors = new Queue<Armor>(armorGenerator.GenerateArmors());
        private static Random _random = new Random();

        static void Main()
        {
            ConfigureConsole();
            MainMenu.Show();
            var choice = MainMenu.GetUserChoice();

            if (choice == 1)
            {
                var player = InitializePlayer();

                PlayStages(player, new List<Func<List<Enemy>>>
                {
                    GenerateSmallRats,
                    GenerateRats, GenerateRats, GenerateRats,
                    GenerateFrogs, GenerateFrogs, GenerateFrogs,
                    GenerateSpiders, GenerateSpiders, GenerateSpiders, 
                    GenerateDevils, GenerateDevils, GenerateDevils,
                    GenerateDevils2, GenerateDevils2, GenerateDevils2,
                    GenerateGhosts, GenerateGhosts, GenerateGhosts,
                    GenerateGhosts2, GenerateGhosts2, GenerateGhosts2,
                    GenerateReapers, GenerateReapers, GenerateReapers,
                    GenerateGoblins, GenerateGoblins, GenerateGoblins,
                    GenerateSkeletons, GenerateSkeletons, GenerateSkeletons,
                    GenerateDragons,
                });
            }
            else if (choice == 2)
            {
                Environment.Exit(0);
            }
        }

        private static void ConfigureConsole()
        {
            IntPtr consoleHandle = GetConsoleWindow();
            IntPtr sysMenu = GetSystemMenu(consoleHandle, false);

            DeleteMenu(sysMenu, SC_SIZE, MF_BYCOMMAND);
            DeleteMenu(sysMenu, SC_MAXIMIZE, MF_BYCOMMAND);

            Console.SetWindowSize(ConsoleWidth, ConsoleHeight);
            Console.SetBufferSize(ConsoleWidth, ConsoleHeight);
        }

        private static Player InitializePlayer()
        {
            var player = new Player();
            var defaultWeapon = weapons.Dequeue();
            player.EquipWeapon(defaultWeapon);
            return player;
        }

        private static void PlayStages(Player player, List<Func<List<Enemy>>> stageGenerators)
        {
            foreach (var stageGenerator in stageGenerators)
            {
                var enemies = stageGenerator();
                StartGame(player, enemies);
                Shop.DrawShop(player, weapons, armors);

                if (player.Health <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Game Over! You have been defeated!");
                    return;
                }
            }

            Console.Clear();
            Console.WriteLine("Congratulations! You have completed the game!");
            Console.ReadKey();
        }

        private static List<Enemy> GenerateEnemies<TSmall, TBig>(int minSmall, int maxSmall, int minBig, int maxBig)
            where TSmall : Enemy, new()
            where TBig : Enemy, new()
        {
            var enemies = new List<Enemy>();

            for (int i = 0; i < _random.Next(minSmall, maxSmall + 1); i++)
                enemies.Add(new TSmall());

            for (int i = 0; i < _random.Next(minBig, maxBig + 1); i++)
                enemies.Add(new TBig());

            return enemies;
        }

        private static List<Enemy> GenerateSmallRats() => GenerateEnemies<SmallRat, NoEnemy>(3, 6, 0, 0);
        private static List<Enemy> GenerateRats() => GenerateEnemies<SmallRat, BigRat>(2, 6, 0, 2);
        private static List<Enemy> GenerateFrogs() => GenerateEnemies<SmallFrog, BigFrog>(2, 6, 0, 2);
        private static List<Enemy> GenerateSpiders() => GenerateEnemies<SmallSpider, BigSpider>(2, 6, 0, 2);
        private static List<Enemy> GenerateDevils() => GenerateEnemies<SmallDevil, MediumDevil>(2, 6, 0, 2);
        private static List<Enemy> GenerateDevils2() => GenerateEnemies<MediumDevil, BigDevil>(2, 6, 0, 2);
        private static List<Enemy> GenerateGhosts() => GenerateEnemies<SmallGhost, BigGhost>(2, 6, 0, 2);
        private static List<Enemy> GenerateGhosts2() => GenerateEnemies<BigGhost, GhostPack>(2, 6, 0, 2);
        private static List<Enemy> GenerateReapers() => GenerateEnemies<Reaper, Reaper2>(2, 6, 0, 2);
        private static List<Enemy> GenerateGoblins() => GenerateEnemies<Goblin, Goblin2>(2, 6, 0, 2);
        private static List<Enemy> GenerateSkeletons() => GenerateEnemies<Skeleton, FallenAngel>(2, 6, 0, 2);
        private static List<Enemy> GenerateDragons() => GenerateEnemies<FallenAngel,Dragon>(2, 6, 1, 2);

        private static void StartGame(Player player, List<Enemy> enemies)
        {
            foreach (var enemy in enemies)
            {
                if (!Fight(player, enemy))
                {
                    Console.Clear();
                    Console.WriteLine("You have been defeated!");
                    return;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"You defeated the {enemy.Name}!");
                    player.Gold += enemy.Gold;
                    Console.ReadKey(true);
                }
            }
        }

        private static bool Fight(Player player, Enemy enemy)
        {
            while (enemy.Health > 0 && player.Health > 0)
            {
                Console.Clear();
                UI.DrawPlayer(player);
                UI.DrawEnemy(enemy);
                UI.DrawMenu();

                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Spacebar)
                {
                    player.Attack(enemy, player);
                    if (enemy.Health > 0)
                        enemy.Attack(player);
                }
            }

            return player.Health > 0;
        }

        #region P/Invoke Methods
        private const int MF_BYCOMMAND = 0x00000000;
        private const int SC_SIZE = 0xF000;
        private const int SC_MAXIMIZE = 0xF030;

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32.dll")]
        private static extern bool DeleteMenu(IntPtr hMenu, uint uPosition, uint uFlags);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        #endregion
    }
}