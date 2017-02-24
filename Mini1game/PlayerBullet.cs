using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini1game
{
    class PlayerBullet : CollidableObject
    {
        public PlayerBullet(asd.Vector2DF pos)
        {
            Texture = asd.Engine.Graphics.CreateTexture2D("Resources/playerBullet.png");
            CenterPosition = new asd.Vector2DF(Texture.Size.X / 2.0f, Texture.Size.Y / 2.0f);
            Position = pos;
        }

        protected override void OnUpdate()
        {
            Position += new asd.Vector2DF(0, -20);
        }
    }
}
