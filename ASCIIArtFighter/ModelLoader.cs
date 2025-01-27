using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIArtFighter
{
    public static class ModelLoader
    {
        private readonly static string currentDirectory = Environment.CurrentDirectory;
        private readonly static string modelDirectory = Path.Combine(currentDirectory, "Models");

        public static string LoadModel(string modelName)
        {
            string modelPath = Path.Combine(modelDirectory, modelName);
            string model = System.IO.File.ReadAllText(modelPath);
            return model;
        }

        public static void DrawModel(string model)
        {
            string[] lines = model.Split('\n');
            Console.WriteLine("\n\n");
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }

        public static void DrawModelCentered(string model)
        {
            string[] lines = model.Split('\n');

            // Get dimensions of the model
            int modelHeight = lines.Length;
            int modelWidth = lines.Max(line => line.Length);

            // Get dimensions of the console
            int consoleWidth = Console.WindowWidth;
            int consoleHeight = Console.WindowHeight;

            // Calculate margins
            int verticalMargin = (consoleHeight - modelHeight) / 2;
            int horizontalMargin = (consoleWidth - modelWidth) / 2;

            // Add vertical margin
            Console.WriteLine(new string('\n', Math.Max(0, verticalMargin)));

            // Print each line with horizontal padding
            foreach (string line in lines)
            {
                string paddedLine = line.PadLeft(line.Length + Math.Max(0, horizontalMargin));
                Console.WriteLine(paddedLine);
            }
        }
    }
}
