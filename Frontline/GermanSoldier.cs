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
        private int moveRight = 0, moveLeft = 0, moveDown = 0, moveUp = 0;

        public GermanSoldier(Surface video, int positionX, int positionY):base(video)
        {
            position = new Point(positionX,positionY);
            xVelocity = 1;
            stillImage = new Surface("Sprites/Graphics/GermanRunStill.png");
            leftImage = new Surface("Sprites/Graphics/GermanRunLeft.png");
            rightImage = new Surface("Sprites/Graphics/GermanRunRight.png");
            displayImage = stillImage;

            visibleRec = new Rectangle(0, 0, 80, 75);
        }

        public override void Draw()
        {
            video.Blit(displayImage, position, visibleRec);
        }


        public override void Update(Level activeLevel, Boolean collRight, Boolean collLeft, Boolean collUp, Boolean collDown, string moveAmerican)
        {
            switch(moveAmerican)
            {
                case "right": position.X -= 15; break;
                /*moveRight += 16;
                          moveLeft -= 16;
                if (moveRight == 64)
                {
                    position.X -= 64;
                    moveRight = 0;
                    moveLeft = 0;
                }
                 break;*/

                case "left": position.X += 15; break;
                /* moveRight -= 16;
                 moveLeft += 16;
                 if (moveLeft == 64)
                 {
                     position.X += 64;
                     moveLeft = 0;
                     moveRight = 0;
                 }
                 break;*/
                case "up": position.Y += 15; break;

                /* moveUp += 16;
                 moveDown -= 16;
                 if (moveUp == 64)
                 {
                     position.Y += 64;
                     moveUp = 0;
                     moveDown = 0;
                 }
                 break;*/
                case "down": position.Y -= 15; break;
                    /*
                    moveDown += 16;
                    moveUp -= 16;
                    if (moveDown == 64)
                    {
                        
                        moveDown = 0;
                        moveUp = 0;
                    }
                    break;*/
            }

            if (left || right)
            {
                visibleRec.X += 80;
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
