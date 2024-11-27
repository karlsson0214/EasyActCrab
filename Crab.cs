using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMonoGame;

namespace EasyActCrab
{
    internal class Crab : Actor
    {
        private float rotationSpeed = 1.5f; 
        private float speed = 3.3f;
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
        public override void Act()
        {
            var keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                // turn left
                Turn(-rotationSpeed);
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                // turn right
                Turn(rotationSpeed);
            }
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                // move forward
                Move(speed);
            }
            else if (keyboardState.IsKeyDown(Keys.Down))
            {
                // move backward at half speed
                Move(-speed / 2);
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
                    EasyGame.Instance.IsPaused = true;
                }
            }
            Actor lobster = GetOneIntersectingActor(typeof(Lobster));
            if (lobster != null)
            {
                this.World.ShowText(
                    "GAME OVER",
                    this.World.Width / 2,
                    this.World.Height / 2);
                EasyGame.Instance.IsPaused = true;
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
