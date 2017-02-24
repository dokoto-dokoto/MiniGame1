using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini1game
{
    class StraightObstacles : CollidableObject
    {
        float vel;
        public StraightObstacles(float velocity, string stringpath, Player player)
        {
            Texture = asd.Engine.Graphics.CreateTexture2D(stringpath);
            vel = velocity;
        }
        protected override void OnUpdate()
        {
            Position += new asd.Vector2DF(0.0f,vel);
            base.OnUpdate();

            if (Position.Y > asd.Engine.WindowSize.Y + CenterPosition.Y)
            {
                Dispose();
            }
        }
    }
}
