using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Primitives;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tao.Sdl.Sdl;

namespace Frontline
{
    public class Bullet
    {
        private Surface bullet;
        private int bulletSpeed;
        private string givenDirection;
        private Point initialPosition;

        public Bullet(int initialX, int initialY, string direction)
        {        
            bulletSpeed = 100;

            givenDirection = direction;
            initialPosition.X = initialX;
            initialPosition.Y = initialY;

            switch(givenDirection)
            {
                case "left": bullet = new Surface("Sprites/Graphics/BulletLeft.png"); bullet.Transparent = true; bullet.TransparentColor = Color.FromArgb(255, 255, 255); break;
                case "right": bullet = new Surface("Sprites/Graphics/BulletRight.png"); bullet.Transparent = true; bullet.TransparentColor = Color.FromArgb(255, 255, 255); break;
                case "up": bullet = new Surface("Sprites/Graphics/BulletUp.png"); bullet.Transparent = true; bullet.TransparentColor = Color.FromArgb(255, 255, 255); break;
                case "down": bullet = new Surface("Sprites/Graphics/BulletDown.png"); bullet.Transparent = true; bullet.TransparentColor = Color.FromArgb(255, 255, 255); break;
                default: bullet = new Surface("Sprites/Graphics/BulletRight.png"); bullet.Transparent = true; bullet.TransparentColor = Color.FromArgb(255, 255, 255); break;
            }
        }

        internal void Move()
        {
             if (givenDirection == "left")
             {
                 initialPosition.X -= bulletSpeed;
            }

             else if (givenDirection == "right")
             {
                 initialPosition.X += bulletSpeed;
             }

             if (givenDirection == "down")
             {
                 initialPosition.Y += bulletSpeed;
             }

             else if (givenDirection == "up")
             {
                 initialPosition.Y -= bulletSpeed;
             }

             if (givenDirection == "still")
             {
                initialPosition.X += bulletSpeed;             
             }                  
        }

        public void Draw (Surface mVideo)
        {
            mVideo.Blit(bullet, initialPosition);
        }

        public int CollRecX { get { return initialPosition.X; } }
        public int CollRecY { get { return initialPosition.Y; } }
    }
}
