using EasyMonoGame;
using Microsoft.Xna.Framework;
using System;


namespace EasyActCrab
{
    internal class CrabWorld : World
    {
        private Random random = new Random();
        /// <summary>
        /// Create a new CrabWorld.
        /// 
        /// This is called from the class Program.
        /// </summary>
        public CrabWorld() : base(800, 600)
        {
            BackgroundTileName = "sand2";

            // Add objects to the game world.
            Crab crab = new Crab();
            Add(crab, "crab", 400, 300);
            AddWorms();
            AddLobsters(crab);
        }

        /// <summary>
        /// This method is called once per frame by the MonoGame framework.
        /// </summary>

        public override void Act()
        {
            // Add game logic for the world here.
            // your code ...
        }
        
        private void AddWorms()
        {
            for (int i = 0; i < 10; i++)
            {
                float x = random.Next(Width);
                float y = random.Next(Height);
                Worm worm = new Worm();
                Add(worm, "worm", x, y);
            }
        }
        private void AddLobsters(Crab crab)
        {
            Lobster lobster = new Lobster(crab);
            Add(lobster, "lobster", 100, 100);

            Lobster lobster2 = new Lobster(crab);
            Add(lobster2, "lobster", 100, Height - 100);

            Lobster lobster3 = new Lobster(crab);
            Add(lobster3, "lobster", Width - 100, 100);

            Lobster Lobster4 = new Lobster(crab);
            Add(Lobster4, "lobster", Width - 100, Height - 100);
        }
    }
}
