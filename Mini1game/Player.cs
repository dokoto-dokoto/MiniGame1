using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini1game
{
    class Player : CollidableObject
    {
        private asd.Vector2DF cPos = new asd.Vector2DF(80, 48);
        public bool feverState;
        float vel;

        public Player()
        {
            Texture = asd.Engine.Graphics.CreateTexture2D("Resources/player_allstate.png");
            Src = new asd.RectF(cPos.X * 2, 0, cPos.X, cPos.Y);
            CenterPosition = new asd.Vector2DF(cPos.X / 2, cPos.Y / 2);
            Position = new asd.Vector2DF(asd.Engine.WindowSize.X * 1 / 3, asd.Engine.WindowSize.Y / 2.0f);
            Radius = Texture.Size.Y / 2.0f;
            feverState = false;
            vel = 10;
        }
        protected override void OnUpdate()
        {
            //-------------動くよ--------------------------------------------------------------------------------------------------------------------
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Up) == asd.KeyState.Hold)
            {
                Position += new asd.Vector2DF(0, -vel);
            }
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Down) == asd.KeyState.Hold)
            {
                Position += new asd.Vector2DF(0, vel);
            }
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Left) == asd.KeyState.Hold)
            {
                Position += new asd.Vector2DF(-vel, 0);
            }
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Right) == asd.KeyState.Hold)
            {
                Position += new asd.Vector2DF(vel, 0);
            }
            if (feverState) vel = 15;
            else vel = 10;


            //------------機体も動くよ----------------------------------------------------------------------------------------------------------------

            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Left) == asd.KeyState.Push)
            {
                if (feverState)
                {
                    Src = new asd.RectF(cPos.X, cPos.Y, cPos.X, cPos.Y);
                    Src = new asd.RectF(0, cPos.Y, cPos.X, cPos.Y);
                }
                else
                {
                    Src = new asd.RectF(cPos.X, 0, cPos.X, cPos.Y);
                    Src = new asd.RectF(0, 0, cPos.X, cPos.Y);
                }
            }
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Right) == asd.KeyState.Push)
            {
                if (feverState)
                {
                    Src = new asd.RectF(cPos.X * 3, cPos.Y, cPos.X, cPos.Y);
                    Src = new asd.RectF(cPos.X * 4, cPos.Y, cPos.X, cPos.Y);
                }
                else
                {
                    Src = new asd.RectF(cPos.X * 3, 0, cPos.X, cPos.Y);
                    Src = new asd.RectF(cPos.X * 4, 0, cPos.X, cPos.Y);
                }
            }
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Left) == asd.KeyState.Release)
            {
                if (feverState)
                {
                    Src = new asd.RectF(cPos.X, cPos.Y, cPos.X, cPos.Y);
                    Src = new asd.RectF(cPos.X * 2, cPos.Y, cPos.X, cPos.Y);
                }
                else
                {
                    Src = new asd.RectF(cPos.X, 0, cPos.X, cPos.Y);
                    Src = new asd.RectF(cPos.X * 2, 0, cPos.X, cPos.Y);
                }
            }
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Right) == asd.KeyState.Release)
            {
                if (feverState)
                {
                    Src = new asd.RectF(cPos.X * 3, cPos.Y, cPos.X, cPos.Y);
                    Src = new asd.RectF(cPos.X * 2, cPos.Y, cPos.X, cPos.Y);
                }
                else
                {
                    Src = new asd.RectF(cPos.X * 3, 0, cPos.X, cPos.Y);
                    Src = new asd.RectF(cPos.X * 2, 0, cPos.X, cPos.Y);
                }
            }


            //-----------playerの動く範囲制限---------------------------------------------------------------------------------------------------------

            asd.Vector2DF position = Position;

            position.X = asd.MathHelper.Clamp(position.X, asd.Engine.WindowSize.X * 2 / 3 - cPos.X / 2.0f, cPos.X / 2.0f);
            position.Y = asd.MathHelper.Clamp(position.Y, asd.Engine.WindowSize.Y - cPos.Y / 2.0f, cPos.Y / 2.0f);

            Position = position;

            //----------------------------------------------------------------------------------------------------------------------------------------

/*            
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Z) == asd.KeyState.Push)
            {
                PlayerBullet bullet = new PlayerBullet(new asd.Vector2DF(Position.X, Position.Y + 20.0f));

                asd.Engine.AddObject2D(bullet);
            }
*/            
        }

        public override void OnCollide(CollidableObject obj)  //それぞれのオブジェクトから呼び出してもらう形にしました。
        {
            if (obj == null) Dispose();

            if (obj is Obstacle_Fever)
            {
                feverState = false;
                Src = new asd.RectF(cPos.X * 2, 0, cPos.X, cPos.Y);
            }
            if(obj is FeverWarp)
            {
                feverState = true;
                Src = new asd.RectF(cPos.X * 2, cPos.Y, cPos.X, cPos.Y);
            }
            if(obj is Medal)
            {
                var scene = (GameScene)Layer.Scene;
                scene.score += 200;
            }
        }
    }
}
