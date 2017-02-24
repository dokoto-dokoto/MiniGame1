using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini1game
{
    class Program
    {
        static void Main(string[] args)
        {
            asd.Engine.Initialize("avoid", 1200, 960, new asd.EngineOption());

            TitleScene scene = new TitleScene();
            asd.Engine.ChangeSceneWithTransition(scene, new asd.TransitionFade(0, 1.0f));

            while (asd.Engine.DoEvents())
            {
                if(asd.Engine.Keyboard.GetKeyState(asd.Keys.Escape) == asd.KeyState.Push)
                {
                    break;
                }
                
                asd.Engine.Update();
            }

            asd.Engine.Terminate();
        }
    }
}
