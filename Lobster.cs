using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using EasyMonoGame;


namespace EasyActCrab
{
    internal class Lobster : Actor
    {
        private float speed = 0.83f;
        private Random random = new Random();
        private Crab crab;

        public Lobster(Crab crab)
        {

            this.crab = crab;
        }

        public override void Act()
        {

            float deltaAngle = random.Next(-30, 30);
            Rotation = Rotation + deltaAngle;
            TurnTowards(crab.Position.X, crab.Position.Y);
            Move(speed);
        }
    }
}
