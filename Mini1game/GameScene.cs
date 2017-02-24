using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini1game
{
    class GameScene : asd.Scene
    {
        public int count;
        private int feverCount;
        public int score;
        public bool isFever;

        asd.Layer2D layer = new asd.Layer2D();
        asd.Layer2D feverLayer = new asd.Layer2D();
        BackGroundTexture bg3;
        BackGroundTexture bg4;
        private byte colorVal = 200;
        private Player player = new Player();
        private FeverWarp warpHole;

        asd.Layer2D backLayer = new asd.Layer2D();
        private ScoreWindow scoreWindow = new ScoreWindow();
        private asd.Vector2DF wSize;

        public asd.Object2D emptyObj;

        private bool isSceneChangeing = false;

        protected override void OnRegistered()
        {
            isFever = false;

            BackGround bg1 = new BackGround(new asd.Vector2DF(0.0f, 0.0f), player);
            BackGround bg2 = new BackGround(new asd.Vector2DF(0.0f, -bg1.bgTexture1.Texture.Size.Y), player);
            AddLayer(backLayer);
            backLayer.DrawingPriority = 10;
            backLayer.AddObject(bg1.bgTexture1);
            backLayer.AddObject(bg1.bgTexture2);
            backLayer.AddObject(bg1.bgTexture3);
            backLayer.AddObject(bg2.bgTexture1);
            backLayer.AddObject(bg2.bgTexture2);
            backLayer.AddObject(bg2.bgTexture3);

            bg3 = new BackGroundTexture(new asd.Vector2DF(0.0f, 0.0f), "Resources/background_fevermode0.png", 40.0f, player);
            bg4 = new BackGroundTexture(new asd.Vector2DF(0.0f, -bg3.Texture.Size.Y), "Resources/background_fevermode0.png", 40.0f, player);
            AddLayer(feverLayer);
            feverLayer.DrawingPriority = 1;
            feverLayer.AddObject(bg3);
            feverLayer.AddObject(bg4);

            AddLayer(layer);
            layer.DrawingPriority = 100;
            layer.AddObject(player);
            player.DrawingPriority = 110;

            AddLayer(scoreWindow);
            scoreWindow.DrawingPriority = 1000;
            scoreWindow.AddObject(scoreWindow.window);
            scoreWindow.AddObject(scoreWindow.score);
            scoreWindow.AddObject(scoreWindow.point);

            wSize = asd.Engine.WindowSize.To2DF();

            count = 0;
            feverCount = 0;
        }

        protected override void OnUpdated()
        {
            //-----playerやられたらgameover
            if (!isSceneChangeing && !player.IsAlive)
            {
                asd.Engine.ChangeSceneWithTransition(new GameOverScene(score), new asd.TransitionFade(1.0f, 1.0f));
                isSceneChangeing = true;
            }
            else
            {
                count++; // countを上げる。

                //-----Fevermodeの時に仕様をごっそり変える。
                if (isFever) FeverMode();
                else NormalMode();

                //-----スコア表示
                score = asd.MathHelper.Clamp(score, 999999999, 0);
                scoreWindow.point.Text = score.ToString("D9");
                //            scoreWindow.point.Text = String.Format("{0:D9}",score);  //---先輩にいろいろ書き方を教わったよ！---
                //            scoreWindow.point.Text = $"{score:D9}";
            }

            foreach (var obj in layer.Objects)
                if (NeedToDelete(obj)) emptyObj = obj;

            if (emptyObj != null) emptyObj.Dispose();
        }


        //--------------障害を出現させるメソッド--------------------------------------------------------------------------------
        void ObstacleLoop()
        {
            Pattern0();
            if ((score > 2000 && score < 40000) || score > 50000)
            {
                Pattern1();
            }
            if ((score > 40000 && score < 10000) || score > 200000)
            {
                Pattern2();
            }
            if (score > 100000)
            {
                Pattern3();
            }
        } //Patternの出し方を制御する

        void Pattern0()
        {
            if (count % 40 == 0) layer.AddObject(new Obstacle_Bar(10, player, 0));
        } //ただの棒
        void Pattern1()
        {
            if (count % 45 == 0) layer.AddObject(new Obstacle_Circle(15, player));
        } //まる
        void Pattern2()
        {
            if (count % 240 == 0) layer.AddObject(new Obstacle_Bar(5, player, 1));
            else if (count % 240 == 120) layer.AddObject(new Obstacle_Bar(5, player, -1));
        } //回転する棒
        void Pattern3()
        {
            if (count % 400 == 0) layer.AddObject(new Obstacle_Bar(2, player, 2));
            else if (count % 400 == 200) layer.AddObject(new Obstacle_Bar(2, player, -2));
        } //急に回転する棒


        void FeverObstacleLoop()
        {
            FeverPattern0();
        }

        private int arraynum = 0;
        void FeverPattern0()
        {
            if (feverCount % 10 == 0)
            {
                Random rand = new Random();
                PositionArray p = new PositionArray();
                int[,] posOrder = p.Array(0);
                for (int j = 0; j < 11; j++)
                {
                    if (posOrder[arraynum, j] == 1)
                    {
                        layer.AddObject(new Obstacle_Fever(0.2f, player, new asd.Vector2DF(80 * j, 45)));
                    }
                }

                arraynum++;

                if (arraynum == 38) arraynum = 0;
            }
        }

        //----------FeverMode------------背景点滅、プレーヤー光る、Score上昇率上がる--------------------------------------------
        void NormalMode()
        {
            //-----playerの位置に応じてスコアアップ
            int position = (int)player.Position.Y;
            if (position < asd.Engine.WindowSize.Y / 4)
            {
                if (count % 5 == 0) score += 40;
            }
            else if (position < asd.Engine.WindowSize.Y / 2)
            {
                if (count % 10 == 0) score += 40;
            }
            else if (position < asd.Engine.WindowSize.Y * 3 / 4)
            {
                if (count % 20 == 0) score += 40;
            }
            else if (position < asd.Engine.WindowSize.Y)
            {
                if (count % 30 == 0) score += 40;
            }

            if (count % 600 == 0)
            {
                warpHole = new FeverWarp(player, this);
                warpHole.DrawingPriority = 103;
                layer.AddObject(warpHole);
            }
            /*      if (count % 200 == 0)
                  {
                      Medal medal = new Medal(player, new asd.Vector2DF(240, 500));
                      medal.Scale = new asd.Vector2DF(2.0f, 2.0f);
                      layer.AddObject(medal);

                      MedalEffect effect = new MedalEffect(new asd.Vector2DF(240, 500));
                      layer.AddObject(effect);

                  }
            /**/
            //------障害出現
            ObstacleLoop();

        }
        void FeverMode()
        {
            feverLayer.DrawingPriority = 20; //feverLayerを出現させる。

            feverCount++; //---FeverMode中の時間をはかる。一定時間でNormalModeにもどる。

            //Fever中のスコアアップ。
            if (count % 4 == 0) score += 10;
            if (count % 8 == 0) score += 100;
            if (count % 16 == 0) score += 1000;

            bg3.Color = new asd.Color(colorVal, colorVal, colorVal, 240);
            bg4.Color = new asd.Color(colorVal, colorVal, colorVal, 240);

            FeverObstacleLoop();

            if (feverCount > 900 || player.feverState == false)
            {
                feverCount = 0;
                feverLayer.DrawingPriority = 0; //feverLayerをかくす。
                isFever = false; //FeverModeを終了。
                player.feverState = false;
            }
        }

        public bool NeedToDelete(asd.Object2D o)
        {
            if (o is Obstacle_Fever)
            {
                if (o.IsAlive && isFever == false)
                {
                    return true;
                }

            }
            else if (o is StraightObstacles)
            {
                if (o.IsAlive && isFever == true)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
