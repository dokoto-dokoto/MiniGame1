using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini1game
{
    class Medal : CollidableObject
    {
        Player player;
        public Medal(Player playerRef, asd.Vector2DF pos)
        {
            player = playerRef;
            Texture = asd.Engine.Graphics.CreateTexture2D("Resources/medal1.png");
            Position = pos;
            Radius = Texture.Size.X / 2;
        }

        protected override void OnUpdate()
        {
            if (IsCollide(player))
            {
                player.OnCollide(this);
                asd.Engine.AddObject2D(new MedalEffect(Position));
                Dispose();
            }
        }
    }
}
