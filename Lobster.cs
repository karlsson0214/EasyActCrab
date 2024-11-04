using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using EasyMonoGame;


namespace EasyCrab
{
    internal class Lobster : Actor
    {
        private float speed = 50f;
        private Random random = new Random();
        private Crab crab;

        public Lobster(Crab crab)
        {
            ImageName = "lobster";
            this.crab = crab;
        }

        public override void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float deltaAngle = random.Next(-1800, 1800) * deltaTime;
            Rotation = Rotation + deltaAngle;
            TurnTowards(crab.Position.X, crab.Position.Y);
            Move(speed * deltaTime);
        }
    }
}
