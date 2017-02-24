using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini1game
{
    class GameOverScene : asd.Scene
    {
        asd.Layer2D backLayer = new asd.Layer2D();
        asd.Layer2D layer = new asd.Layer2D();
        asd.TextObject2D Score = new asd.TextObject2D();

        public GameOverScene(int sc)
        {
            Score.Font = asd.Engine.Graphics.CreateFont("Resources/font.aff");
            Score.Text = sc.ToString();
            Score.CenterPosition = new asd.Vector2DF(Score.Text.Length * 32 / 2, 0);
            Score.Position = new asd.Vector2DF(asd.Engine.WindowSize.X / 2, asd.Engine.WindowSize.Y / 2);
        }

        protected override void OnRegistered()
        {
            AddLayer(backLayer);
            asd.TextureObject2D gameOver = new asd.TextureObject2D();
            gameOver.Texture = asd.Engine.Graphics.CreateTexture2D("Resources/gameOver_background.png");
            backLayer.AddObject(gameOver);

            AddLayer(layer);
            layer.AddObject(Score);
        }
        protected override void OnUpdated()
        {
            if(asd.Engine.Keyboard.GetKeyState(asd.Keys.Space) == asd.KeyState.Push)
            {
                GameScene scene = new GameScene();
                asd.Engine.ChangeSceneWithTransition(scene, new asd.TransitionFade(1.0f, 1.0f));
            }
        }
    }
}
