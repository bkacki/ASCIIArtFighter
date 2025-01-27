using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIArtFighter
{
    public static class MainMenu
    {
        public static void Show()
        {
            Console.Clear();
            ShowLogo();
            Console.WriteLine("1. Start Game");
            Console.WriteLine("2. Exit");
            Console.Write("Choose an option: ");
        }

        public static int GetUserChoice()
        {
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2)
            {
                Console.Write("Invalid choice. Please enter a number between 1 and 3: ");
            }
            return choice;
        }

        public static void ShowLogo()
        {
            var logo = ModelLoader.LoadModel("logo.csv");

            var lines = logo.Split('\n');

            foreach (var line in lines)
            {
                int padding = (Console.WindowWidth - line.Length) / 2;
                if (padding < 0) padding = 0;

                Console.WriteLine(new string(' ', padding) + line);
            }

            Console.WriteLine("\n\n");
        }
    }
}
