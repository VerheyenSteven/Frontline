using SdlDotNet.Core;
using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontline
{
    public class AmericanSoldier : BeweegbaarObject
    {
        private Rectangle visibleRectangle;
        private string direction;
        Level activeLevel;

        public AmericanSoldier(Surface video) : base(video)
        {
            stillImage = new Surface("Sprites/Graphics/AmericanStandStill.png");
            leftImage = new Surface("Sprites/Graphics/AmericanRunLeft.png");
            rightImage = new Surface("Sprites/Graphics/AmericanRunRight.png");
            displayImage = stillImage;
            this.video = video;
            direction = "still";
            visibleRectangle = new Rectangle(0, 0, 80, 75);

            positionMid = new Point(750, 375);
            position = new Point(2560, 4000);

            colRectangleRight = new Rectangle(positionMid.X + 75 , positionMid.Y + 25 , 10, 20);
            colRectangleLeft = new Rectangle(positionMid.X, positionMid.Y + 25, 5, 20);
            colRectangleUp = new Rectangle(positionMid.X + 25, positionMid.Y + 5, 30, 5);
            colRectangleDown = new Rectangle(positionMid.X + 25, positionMid.Y + 70, 30, 5);
            xVelocity = 15;
            yVelocity = 15;
      


            Events.KeyboardDown += Events_KeyboardDown;
            Events.KeyboardUp += Events_KeyboardUp;
        }

        public override void Update(Level activeLevel, Boolean collRight, Boolean collLeft, Boolean collUp, Boolean collDown)
        {
            Move(activeLevel, collRight, collLeft, collUp, collDown);
        }
        public override void Move(Level activeLevel, Boolean collRight, Boolean collLeft, Boolean collUp, Boolean collDown)
        {
            if (SdlDotNet.Input.Keyboard.IsKeyPressed(SdlDotNet.Input.Key.LeftArrow))
            {
                displayImage = leftImage;
                direction = "left";
                /*if (positionMid.X < 400) position.X -= xVelocity;
                else positionMid.X -= xVelocity;*/
                if (collLeft)
                {
                    position.X = position.X;                    
                }
                else
                {                    
                    position.X -= xVelocity;
                }
            }

            if (SdlDotNet.Input.Keyboard.IsKeyPressed(SdlDotNet.Input.Key.RightArrow))
            {
                displayImage = rightImage;
                /*if (positionMid.X > 1100) position.X += xVelocity;
                else positionMid.X += xVelocity;*/
                if (collRight)
                {
                    position.X = position.X;
                }
                else
                {                    
                    position.X += xVelocity;
                }
                direction = "right";
            }

            if (SdlDotNet.Input.Keyboard.IsKeyPressed(SdlDotNet.Input.Key.UpArrow))
            {
                /*if (positionMid.Y < 300) position.Y -= yVelocity;
                else positionMid.Y -= xVelocity;*/
                if (collUp)
                {
                    position.Y = position.Y;
                }
                else
                {
                    position.Y -= yVelocity;
                }
                direction = "up";
            }

            if (SdlDotNet.Input.Keyboard.IsKeyPressed(SdlDotNet.Input.Key.DownArrow))
            {
                /*if (positionMid.Y > 450) position.Y += yVelocity;
                else positionMid.Y += xVelocity;*/
                if (collDown)
                {
                    position.Y = position.Y;
                }
                else
                {
                    position.Y += yVelocity;
                }
                direction = "down";
            }                   

            if (direction == "left" || direction == "right")
            {
                visibleRectangle.X += 80;
                if (visibleRectangle.X >= 192)
                    visibleRectangle.X = 0;
            }

            /*colRectangleRight.X = positionMid.X + 75;
            colRectangleLeft.X = positionMid.X;
            colRectangleUp.X = positionMid.X + 25;
            colRectangleDown.X = positionMid.X + 25;
            colRectangleRight.Y =positionMid.Y + 25;
            colRectangleLeft.Y = positionMid.Y + 25;
            colRectangleUp.Y = positionMid.Y + 5;
            colRectangleDown.Y = positionMid.Y + 70;*/
            activeLevel.DrawWorld(Position);
        }
        public override void Shoot(Bullets bullets)
        { 
            Bullet_old bullet = new Bullet_old(positionMid.X , positionMid.Y + 40, bullets, Direction);
        }
        public override void Draw()
        {
            video.Blit(displayImage, positionMid, visibleRectangle);
        }

        private void Events_KeyboardUp(object sender, SdlDotNet.Input.KeyboardEventArgs e)
        {
            direction = "still";
        }
        private void Events_KeyboardDown(object sender, SdlDotNet.Input.KeyboardEventArgs e)
        {

        }

        public string Direction { get { return direction;}}
        public Point Position { get { return position; } }
        public string CollDirection { get; set; }
    }
}
