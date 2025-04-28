# ASCII Art Fighter

ASCII Art Fighter is a console-based RPG game where players fight against various enemies in a series of stages. The game features ASCII art visuals, a turn-based combat system, and a shop for upgrading weapons and armor.-

## Features
- **Turn-Based Combat**: Fight against a variety of enemies with unique stats and abilities.
- **ASCII Art Visuals**: Enjoy a retro-style gaming experience with ASCII art for enemies and UI.
- **Stages and Progression**: Progress through multiple stages with increasing difficulty.
- **Shop System**: Upgrade your weapons and armor between stages to improve your stats.
- **Randomized Enemies**: Each stage generates a random set of enemies for replayability.

---

## Gameplay
1. Start the game and choose your path from the main menu.
2. Fight through multiple stages, defeating enemies to earn gold.
3. Use gold to purchase better weapons and armor in the shop.
4. Survive until the final stage to complete the game.

---

## Installation
1. Clone the repository:
`git clone https://github.com/your-username/ASCIIArtFighter.git`
2. Open the solution in **Visual Studio 2022**.
3. Build the project using the `.NET 8` SDK.
4. Run the application from Visual Studio or using the command line:
`dotnet run`

---

## How to Play
- **Controls**:
  - Press `[Space]` to attack during combat.
  - Use the shop to upgrade your equipment between stages.
- **Objective**:
  - Defeat all enemies in each stage and survive until the end of the game.

---

## Project Structure
- **`Program.cs`**: Main entry point of the game. Handles game flow and stage progression.
- **`UI.cs`**: Manages the console UI, including player stats, enemy stats, and menus.
- **`Enemy.cs`**: Defines enemy types and their behaviors.
- **`Player.cs`**: Represents the player, including stats, weapons, and armor.
- **`WeaponGenerator.cs` & `ArmorGenerator.cs`**: Generate random weapons and armor for the shop.

  
---

## Contributing
Contributions are welcome! If you'd like to improve the game or add new features:
1. Fork the repository.
2. Create a new branch for your feature or bugfix.
3. Submit a pull request with a detailed description of your changes.
