using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini1game
{
    class Obstacle_Fever : CollidableObject
    {
        private Player player;
        private float ac;
        private float vel;

        public Obstacle_Fever(float accel, Player playerRef, asd.Vector2DF pos)
        {
            Texture = asd.Engine.Graphics.CreateTexture2D("Resources/bar_black.png");
            CenterPosition = new asd.Vector2DF(Texture.Size.X / 2, Texture.Size.Y / 2);
            pos.X += Texture.Size.X / 2;
            Position = pos;
            player = playerRef;
            ac = accel;
            vel = -4;
            Radius = Texture.Size.X / 4;
        }

        protected override void OnUpdate()
        {
            //------加速度的に迫ります。---------------------------------------------------------------------
            vel += ac;
            Position += new asd.Vector2DF(0, vel);

            if (IsCollide(player))
            {
                player.OnCollide(this);
                Dispose();
            }
        }
    }
}
