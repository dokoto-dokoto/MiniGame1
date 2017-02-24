using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini1game
{
    class FeverWarp : CollidableObject
    {
        private Random rand = new Random();
        private int count;
        Player player;
        GameScene gscene;
        public FeverWarp(Player playerRef, GameScene scene)
        {
            player = playerRef;
            gscene = scene;

            //Texture = asd.Engine.Graphics.CreateTexture2D("Resources/DarkBall.png");
            //            Texture = asd.Engine.Graphics.CreateTexture2D("Resources/WarpHole.png");
                        Texture = asd.Engine.Graphics.CreateTexture2D("Resources/WarpHole2.png");
            Scale = new asd.Vector2DF(2.0f, 2.0f);
            Color = new asd.Color(200, 200, 200, 200);
            Radius = Texture.Size.X / 8;
            CenterPosition = new asd.Vector2DF(Texture.Size.X / 2, Texture.Size.Y / 2);

            while (true)
            {
                asd.Vector2DF pos = new asd.Vector2DF(Texture.Size.X / 2 + rand.Next(0, 6) * (asd.Engine.WindowSize.X / 9), Texture.Size.Y / 2 + rand.Next(0, 10) * (asd.Engine.WindowSize.Y / 10));
                if ((player.Position - pos).Length > Radius)
                {
                    Position = pos;
                    break;
                }
            }
            
            Src = new asd.RectF(0, 0, 0, 0);
        }

        protected override void OnUpdate()
        {
            count++;
            if (count <= 60)
            {
                Src = new asd.RectF(0, 0, Texture.Size.X * count / 60, Texture.Size.Y * count / 60);
            }
            else if (count >= 300)
            {
                Src = new asd.RectF(0, 0, Texture.Size.X - (Texture.Size.X * (count - 300) / 60), Texture.Size.Y - (Texture.Size.Y * (count - 300) / 60));
            }

            if (count >= 360)
            {
                Dispose();
            }

            Angle += 90;

            if (IsCollide(player))
            {
                player.OnCollide(this);
                gscene.isFever = true;
                Dispose();
            }
        }
    }
}
