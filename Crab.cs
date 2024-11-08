using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMonoGame;

namespace EasyCrab
{
    internal class Crab : Actor
    {
        private float rotationSpeed = 90f; 
        private float speed = 200f;
        private int score = 0;

        /// <summary>
        /// Create a Crab.
        /// </summary>
        public Crab()
        {

            //ShowScore();
        }



        /// <summary>
        /// The method is called once per frame by the MonoGame framework. 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            var keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                // turn left
                Rotation -= rotationSpeed * deltaTime;
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                // turn right
                Rotation += rotationSpeed * deltaTime;
            }
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                // move forward
                var distance = speed * deltaTime;
                Move(distance);
            }
            else if (keyboardState.IsKeyDown(Keys.Down))
            {
                // move backward at half speed
                var distance = speed / 2 * deltaTime;
                Move(-distance);
            }
            
            Actor worm = GetOneIntersectingActor(typeof(Worm));
            if (worm != null)
            {
                Debug.WriteLine("eat worm");
                this.World.RemoveActor(worm);
                score += 1;
                ShowScore();
                if (score >= 10)
                {
                    this.World.ShowText(
                        "You did it!",
                        this.World.Width / 2,
                        this.World.Height / 2);
                }
            }
            Actor lobster = GetOneIntersectingActor(typeof(Lobster));
            if (lobster != null)
            {
                this.World.ShowText(
                    "GAME OVER",
                    this.World.Width / 2,
                    this.World.Height / 2);
            }
            
        }
        private void ShowScore()
        {
            this.World.ShowText(
                "Score: " + score, 
                100, 100);
        }

    }
}
