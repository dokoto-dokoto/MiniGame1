using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini1game
{
    class BackGround
    {
        public BackGroundTexture bgTexture1;
        public BackGroundTexture bgTexture2;
        public BackGroundTexture bgTexture3;

        public BackGround(asd.Vector2DF pos, Player player)
        {
            bgTexture1 = new BackGroundTexture(pos, "Resources/background_01.png", 10, player);
            bgTexture2 = new BackGroundTexture(pos, "Resources/background_02.png", 8, player);
            bgTexture3 = new BackGroundTexture(pos, "Resources/background_03.png", 5, player);

            bgTexture1.DrawingPriority = 1;
            bgTexture2.DrawingPriority = 2;
            bgTexture3.DrawingPriority = 3;
        }
    }
}
