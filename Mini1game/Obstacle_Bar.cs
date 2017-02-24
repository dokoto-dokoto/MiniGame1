using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini1game
{
    class Obstacle_Bar : StraightObstacles
    {
        private Random rand = new Random();

        private Player player;
        private int type;
        private float scaleRate;
        private int count = 0;

        public Obstacle_Bar(float vel, Player playerRef, int typeness)
            : base(vel, "Resources/bar.png", playerRef)
        {
            //------引数typenessに応じてbarの長さ、挙動を変更。ちなみに、typenessという英単語はない。----------------------------------------------

            type = Math.Abs(typeness);
            if (type == 1)  //タイプ1。長くなって回る。
            {
                scaleRate = 2.0f;
                Scale = new asd.Vector2DF(scaleRate, 1.0f);
            }
            else if (type == 2)  //タイプ2。少し長くなって早く回る。
            {
                scaleRate = 1.5f;
                Scale = new asd.Vector2DF(scaleRate, 1.0f);
            }
            else if (type == 3)
            {
                scaleRate = 5.0f;
                Scale = new asd.Vector2DF(scaleRate, 1.0f);
            }

            //-------------------------------------------------------------------------------------------------------------------------------

            player = playerRef;
            CenterPosition = new asd.Vector2DF(Texture.Size.X / 2.0f, Texture.Size.Y / 2.0f);
            float obsPoint = asd.Engine.WindowSize.X / 9; 　　// 障害の位置をtypeによって分けるためにWindowSizeを障害の位置パターンの最小単位にする
            asd.Vector2DF pos = new asd.Vector2DF((rand.Next(0, 6) * obsPoint), 0);
            Position = new asd.Vector2DF(CenterPosition.X * 3 / 2, 0) + pos;
        }
        protected override void OnUpdate()
        {
            //------playerと接触したかどうかの計算---------------------------------------------------------------------------------------------

            asd.Vector2DF playerDir = player.Position - Position;
            float playerDirL = playerDir.Length;            //playerとの距離を取得
            double distanceH = playerDirL*Math.Abs(Math.Sin(playerDir.Degree - Angle));            //playerからbarの延長線までの距離を取得
            double distanceW = playerDirL*Math.Abs(Math.Cos(playerDir.Degree - Angle));            //playerからbarの中心線までの距離を取得
            if (distanceH < Texture.Size.Y / 2 && distanceW < Texture.Size.X / 2)　  //playerが長方形の中に入ったら
            {
                player.OnCollide(null);         //playerの衝突処理をよぶ。
            }
            

            //------------------------------------------------------------------------------------------------------------------------------         

            if (type == 1)
            {
                Angle++;
            }
            if (type == -1)
            {
                Angle--;
            }
            if(type == 2)
            {
                count++;
                if(count % 200 > 0 && count % 200 < 50)
                {
                      Angle += 36;                 
                }
            }
            if (type == -2)
            {
                count++;
                if (count % 200 > 0 && count % 200 < 50)
                {
                    Angle -= 36;
                }
            }
            if(type == 3)
            {
                Angle++;
            }
            base.OnUpdate();
        }
    }
}
