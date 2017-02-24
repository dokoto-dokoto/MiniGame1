using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini1game
{
    class TitleScene : asd.Scene
    {
        asd.Layer2D layer = new asd.Layer2D();
        private bool toStart;
        private asd.TextObject2D start = new asd.TextObject2D();
        private asd.TextObject2D exit = new asd.TextObject2D();

        protected override void OnRegistered()
        {
            AddLayer(layer);
            asd.TextureObject2D title = new asd.TextureObject2D();
            title.Texture = asd.Engine.Graphics.CreateTexture2D("Resources/title.png");
            layer.AddObject(title);

            toStart = true;

            asd.Font font = asd.Engine.Graphics.CreateFont("Resources/font3.aff");

            start.Font = font;
            start.Text = "START";
            start.CenterPosition = new asd.Vector2DF(start.Text.Length * 30 / 2, 0);
            start.Position = new asd.Vector2DF(asd.Engine.WindowSize.X / 2, asd.Engine.WindowSize.Y * 2 / 3);
            start.Color = new asd.Color(0, 180, 255, 200);

            exit.Font = font;
            exit.Text = "EXIT";
            exit.CenterPosition = new asd.Vector2DF(exit.Text.Length * 32 / 2, 0);
            exit.Position = new asd.Vector2DF(asd.Engine.WindowSize.X / 2, asd.Engine.WindowSize.Y * 3 / 4);
            exit.Color = new asd.Color(0, 180, 255, 40);

            layer.AddObject(start);
            layer.AddObject(exit);
        }

        protected override void OnUpdated()
        {
            if(asd.Engine.Keyboard.GetKeyState(asd.Keys.Up) == asd.KeyState.Push)
            {
                toStart = true;
                start.Color = new asd.Color(0, 180, 255, 200);
                exit.Color = new asd.Color(0, 180, 255, 40);
            }
            if(asd.Engine.Keyboard.GetKeyState(asd.Keys.Down) == asd.KeyState.Push)
            {
                toStart = false;
                start.Color = new asd.Color(0, 180, 255, 40);
                exit.Color = new asd.Color(0, 180, 255, 200);
            }
            if(asd.Engine.Keyboard.GetKeyState(asd.Keys.Z) == asd.KeyState.Push)
            {
                if(toStart)
                {
                    GameScene scene = new GameScene();
                    asd.Engine.ChangeSceneWithTransition(scene, new asd.TransitionFade(1.0f, 1.0f));
                }else
                {
                    asd.Engine.Close();
                }
            }

        }
    }
}
