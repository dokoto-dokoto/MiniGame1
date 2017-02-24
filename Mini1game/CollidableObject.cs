using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini1game
{
    class CollidableObject : asd.TextureObject2D
    {
        public float Radius = 0.0f;
        public bool IsCollide(CollidableObject o)
        {
            return (o.Position - Position).Length < Radius + o.Radius;
        }
        public virtual void OnCollide(CollidableObject obj)
        {

        }
    }
}
