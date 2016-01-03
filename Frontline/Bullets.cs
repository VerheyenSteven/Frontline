using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontline
{
    
    public class Bullets
    {
        
        private List<Bullet> bulletList = new List<Bullet>();
        public Rectangle [] collRec;

        public void Add(Bullet bullet)
        {
            bulletList.Add(bullet);
        }

        public void Remove(Bullet bullet)
        {
            bulletList.Remove(bullet);
        }

        public void Draw(Surface mVideo)
        {
            for (int i = 0; i < bulletList.Count; i++)
            {
                bulletList[i].Draw(mVideo);
            }
        }

        public void Update()
        {
            Move();
        }

        public void Move()
        {
            for (int i = 0; i < bulletList.Count; i++)
            {
                bulletList[i].Move();
            }
        }        

        public void CheckHit(int bulletInList, bool hit)
        {
            collRec = new Rectangle[200];
            for (int i = 0; i < bulletList.Count; i++)
            {
                collRec[i] = new Rectangle(bulletList[i].CollRecX, bulletList[i].CollRecY,15,15);
            }

            if (hit)
                bulletList.RemoveAt(bulletInList);
        }

        public Rectangle[] CollRecBullet { get { return collRec; } }
    }
}
