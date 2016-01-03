using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontline
{
    public class GermanSoldier : BeweegbaarObject
    {
        private Rectangle visibleRec;
        private bool left, right;

        public GermanSoldier(Surface video):base(video)
        {
            position = new Point(100, 100);
            xVelocity = 1;

            displayImage = new Surface("Sprites/Graphics/GermanRunAlpha.png");
            visibleRec = new Rectangle(0, 0, 95, 90);
            //colRectangle = new Rectangle(position.X, position.Y, 95, 90);
        }
        public override void Draw()
        {
            video.Blit(displayImage, position, visibleRec);
        }

        public override void Update(Level activeLevel, Boolean collRight, Boolean collLeft, Boolean collUp, Boolean collDown)
        {
            Move(activeLevel, collRight, collLeft, collUp, collDown);
        }

        public override void Move(Level activeLevel, Boolean collRight, Boolean collLeft, Boolean collUp, Boolean collDown)
        {
            if (position.X >= 50 && position.X <= 400)
            {
                position.X += xVelocity;
                right = true;
            }

            else
            {
                xVelocity *= -1;
                position.X += xVelocity;
                left = true;
            }

            if (left || right)
            {
                visibleRec.X += 95;
                if (visibleRec.X >= 192)
                    visibleRec.X = 0;
            }

            //colRectangle.X = position.X;
            //colRectangle.Y = position.Y;
        }


        public override void Shoot(Bullets bullets)
        {
            throw new NotImplementedException();
        }
    }
}
