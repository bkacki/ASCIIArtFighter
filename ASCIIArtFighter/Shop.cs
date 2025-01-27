using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIArtFighter
{
    public static class Shop
    {
        private static readonly string _merchantModel = ModelLoader.LoadModel("merchant.csv");
        public static void DrawShop(Player player, Queue<Weapon> weapons, Queue<Armor> armors)
        {
            while (true)
            {
                Console.Clear();
                UI.DrawPlayer(player);
                ModelLoader.DrawModel(_merchantModel);
                Console.WriteLine("Welcome to the shop! What would you like to do?");
                Console.WriteLine("1. Buy health potion for 50g (+50HP)");
                if (weapons.Count > 0)
                    Console.WriteLine($"2. Buy {weapons.Peek().Name} for {weapons.Peek().Cost}g");
                else
                    Console.WriteLine("2. No weapons available.");
                if (armors.Count > 0)
                    Console.WriteLine($"3. Buy {armors.Peek().Name} for {armors.Peek().Cost}g.");
                else
                    Console.WriteLine("3. No armor available.");
                Console.WriteLine("4. Increase max health by 100 (1000g)");
                Console.WriteLine("5. Leave shop");
                var choice = Console.ReadKey(true).KeyChar;
                switch(choice)
                {
                    case '1':
                        if (player.Gold >= 50)
                        {
                            player.Gold -= 50;
                            player.Health += 50;
                            if (player.Health > player.MaxHealth)
                            {
                                player.Health = player.MaxHealth;
                            }
                        }
                        break;
                    case '2':
                        if (weapons.Count > 0)
                        {
                            if (player.Gold >= weapons.Peek().Cost)
                            {
                                player.Gold -= weapons.Peek().Cost;
                                player.EquipWeapon(weapons.Dequeue());
                            }
                        }
                        break;
                    case '3':
                        if(player.Gold >= armors.Peek().Cost)
                        {
                            player.Gold -= armors.Peek().Cost;
                            player.EquipArmor(armors.Dequeue());
                        }
                        break;
                    case '4':
                        if (player.Gold >= 1000)
                        {
                            player.Gold -= 1000;
                            player.MaxHealth += 100;
                            player.Health += 100;
                        }
                        break;
                    case '5':
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid choice.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
