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
    public class Bullet_old
    {
        private Surface bullet;
        private int bulletSpeed;
        private string givenDirection;
        private Point initialPosition;
        private int initialX;
        private int initialY;
        private Bullets bullets;

        public Bullet_old(int initialX, int initialY, Bullets bullets, string direction)
        {        
            bulletSpeed = 100;

            givenDirection = direction;
            initialPosition.X = initialX;
            initialPosition.Y = initialY;
            this.bullets = bullets;
            bullets.Add(this);
        }

        internal void Move()
        {
             if (givenDirection == "left")
             {
                 initialPosition.X -= bulletSpeed;
                 bullet = new Surface("Sprites/Graphics/BulletLeft.jpg");
                bullet.Transparent = true;
                bullet.TransparentColor = Color.FromArgb(255, 255, 255);
            }

             else if (givenDirection == "right")
             {
                 bullet = new Surface("Sprites/Graphics/BulletRight.jpg");
                 initialPosition.X += bulletSpeed;
             }

             if (givenDirection == "down")
             {
                 initialPosition.Y += bulletSpeed;
                 bullet = new Surface("Sprites/Graphics/BulletDown.jpg");
             }

             else if (givenDirection == "up")
             {
                 bullet = new Surface("Sprites/Graphics/BulletUp.jpg");
                 initialPosition.Y -= bulletSpeed;
             }

             if (givenDirection == "still")
             {
                bullet = new Surface("Sprites/Graphics/BulletRight.jpg");
                initialPosition.X += bulletSpeed;             
             }                  
        }

        public void Draw (Surface mVideo)
        {
            mVideo.Blit(bullet, initialPosition);
        }

        internal void Remove(int bulletInList, bool hit)
        {
            bullets.Remove(this);
        }

        public int CollRecX { get { return initialPosition.X; } }
        public int CollRecY { get { return initialPosition.Y; } }
    }
}
