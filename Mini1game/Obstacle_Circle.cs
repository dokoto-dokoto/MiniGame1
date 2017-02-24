using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini1game
{
    class Obstacle_Circle : StraightObstacles
    {
        private Random rand = new Random();

        private Player player;

        public Obstacle_Circle(float vel, Player playerRef)
            : base(vel, "Resources/circle.png", playerRef)
        {
            player = playerRef;
            CenterPosition = new asd.Vector2DF(Texture.Size.X / 2.0f, Texture.Size.Y / 2.0f);
            Position = new asd.Vector2DF((CenterPosition.X * 3 / 2) + (rand.Next(0, 6) * asd.Engine.WindowSize.X / 12), 0);
        }

        protected override void OnUpdate()
        {
            if((Position - player.Position).Length < Texture.Size.X / 4.0f + player.Radius)
            {
                player.OnCollide(null);
            }
            base.OnUpdate();
        }
    }
}
