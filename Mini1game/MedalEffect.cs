using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini1game
{
    class MedalEffect : asd.TextureObject2D
    {
        const int TextureSizeX = 24;
        const int TextureSizeY = 36;

        const int TextureXCount = 4;
        const int TextureYCount = 2;

        protected int count;

        public MedalEffect(asd.Vector2DF pos)
        {
            Position = pos;

            CenterPosition = new asd.Vector2DF(TextureSizeX / 2, TextureSizeY / 2);

            Texture = asd.Engine.Graphics.CreateTexture2D("Resources/effect1.png");

            Src = new asd.RectF(0, 0, TextureSizeX, TextureSizeY);

            AlphaBlend = asd.AlphaBlendMode.Add;
        }

        protected override void OnUpdate()
        {
            int x = count % TextureXCount;
            int y = count / TextureXCount;

            Src = new asd.RectF(x * TextureSizeX, y * TextureSizeY, TextureSizeX, TextureSizeY);

            if(count == TextureXCount * TextureYCount)
            {
                Dispose();
            }

            count++;  
        }
    }
}
