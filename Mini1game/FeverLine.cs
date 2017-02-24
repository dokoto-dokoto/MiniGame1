using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini1game
{
    class FeverLine : asd.GeometryObject2D
    {
        GameScene scene;
        Player player;
        public FeverLine(GameScene gscene, Player playerRef)
        {
            //線の始点・終点・幅を定義して、形を決める。
            var arc = new asd.LineShape();
            arc.StartingPosition = new asd.Vector2DF(0, 0);
            arc.EndingPosition = new asd.Vector2DF(asd.Engine.WindowSize.X, 0);
            arc.Thickness = 20;
            Shape = arc;

            Color = new asd.Color(200, 220, 25, 200);

            scene = gscene;
            player = playerRef;
        }

        protected override void OnUpdate()
        {
            Position += new asd.Vector2DF(0, 2);

            //feverLineを超えるとfevermodeに
            if (Position.Y > player.Position.Y)
            {
                scene.isFever = true;
                player.feverState = true;
                Dispose();
            }

        }
    }
}
