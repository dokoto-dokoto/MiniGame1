using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini1game
{
    class BackGroundTexture : asd.TextureObject2D
    {
        private float vel;
        Player player = new Player();
        public BackGroundTexture(asd.Vector2DF pos, string texturepath, float velocity, Player playerRef)
        {
            Position = pos;
            Texture = asd.Engine.Graphics.CreateTexture2D(texturepath);
            vel = velocity;
            player = playerRef;
        }

        protected override void OnUpdate()
        {
            float flow = player.Position.Y / asd.Engine.WindowSize.Y * vel / 2;
            Position += new asd.Vector2DF(0.0f, vel - flow);
            if (Position.Y > asd.Engine.WindowSize.Y)
            {
                Position -= new asd.Vector2DF(0.0f, Texture.Size.Y * 2);
            }
        }
    }
}
