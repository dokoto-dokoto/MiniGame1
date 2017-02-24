using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini1game
{
    class ScoreWindow : asd.Layer2D
    {
        public asd.TextureObject2D window = new asd.TextureObject2D();
        public asd.TextObject2D score = new asd.TextObject2D();
        public asd.TextObject2D point = new asd.TextObject2D();
        public ScoreWindow()
        {
            window.Texture = asd.Engine.Graphics.CreateTexture2D("Resources/score_window.png");
            window.Position = new asd.Vector2DF(asd.Engine.WindowSize.X * 2 / 3, 0);
            asd.Font font = asd.Engine.Graphics.CreateFont("Resources/font.aff");
            score.Font = font;
            score.Text = "Score";
            score.Position = window.Position + new asd.Vector2DF(window.Texture.Size.X / 8.0f, window.Texture.Size.Y / 4.0f);
            point.Font = font;//asd.Engine.Graphics.CreateFont("Resources/font2.aff");            
            point.Position = score.Position + new asd.Vector2DF(asd.Engine.WindowSize.To2DF().Normal.X * 80, asd.Engine.WindowSize.To2DF().Normal.Y * 200);
        }
    }
}
