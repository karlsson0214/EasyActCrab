using EasyMonoGame;
using Microsoft.Xna.Framework;
using System;


namespace EasyCrab
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
            LoadContent();
            AddContent();
        }
        /// <summary>
        /// This method is called by the MonoGame framework when the game is started.
        /// </summary>
        public void LoadContent()
        {
            // Load game art from the "Content" folder.
            GameArt.Add("crab");
            GameArt.Add("crab2");
            GameArt.Add("worm");
            GameArt.Add("lobster");
            GameArt.Add("sand2");
            /* or
            string[] names = { "crab", "crab2", "worm", "lobster", "sand2" };
            GameArt.Add(names); 
            */

            // set background tile
            BackgroundTileName = "sand2";

        }
        public void AddContent()
        { 
            // Add objects to the game world.
            Crab crab = new Crab();
            Add(crab);
            AddWorms();
            AddLobsters(crab);

        }
        /// <summary>
        /// This method is called once per frame by the MonoGame framework.
        /// </summary>
        /// <param name="gameTime"></param>
       
        public override void Update(GameTime gameTime)
        {
            // Call Update once per object in the world.
            base.Update(gameTime);

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
                worm.Position = new Vector2(x, y);
                Add(worm);
            }
        }
        private void AddLobsters(Crab crab)
        {
            Lobster lobster = new Lobster(crab);
            lobster.Position = new Vector2(100, 100);
            Add(lobster);

            Lobster lobster2 = new Lobster(crab);
            lobster2.Position = new Vector2(100, Height - 100);
            Add(lobster2);

            Lobster lobster3 = new Lobster(crab);
            lobster3.Position = new Vector2(Width - 100, 100);
            Add(lobster3);

            Lobster Lobster4 = new Lobster(crab);
            Lobster4.Position = new Vector2(Width - 100, Height - 100);
            Add(Lobster4);
        }
    }
}
