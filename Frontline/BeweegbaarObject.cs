using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontline
{
    public abstract class BeweegbaarObject
    {
        public Point position;
        public Point positionMid;

        protected int xVelocity;
        protected int yVelocity;

        protected Surface video;
        protected Surface displayImage;
        protected Surface stillImage;
        protected Surface leftImage;
        protected Surface rightImage;
        protected Surface upImage;
        protected Surface downImage;

        public Rectangle colRectangleLeft;
        public Rectangle colRectangleRight;
        public Rectangle colRectangleUp;
        public Rectangle colRectangleDown;

        protected Bullets bullets;

        protected int Width;
        protected int Height;

        public BeweegbaarObject(Surface video)
        {
            this.video = video;
        }

        public abstract void Update(Level activeLevel, Boolean collRight, Boolean collLeft, Boolean collUp, Boolean collDown, string moveAmerican);

        public abstract void Draw();

        public abstract void Shoot(Bullets bullets);
    }
}
