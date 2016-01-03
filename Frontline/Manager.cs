using SdlDotNet.Core;
using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SdlDotNet.Input;

namespace Frontline
{
    class Manager
    {
        private Surface mVideo;
        private AmericanSoldier americanSoldier;
        //private GermanSoldier germanSoldier;
        private Bullets bullets;
        private bool collRight, collLeft, collUp, collDown;
        //private bool hit;
        //private int bulletInList = 0;

        List<Bullet> bulletList = new List<Bullet>();//:o

        Level level1, activeLevel;

        private bool clickDown;
        //private Rectangle[] recBullet;

        public Manager()
        {
            mVideo = Video.SetVideoMode(1500, 750);

            americanSoldier = new AmericanSoldier(mVideo);
            //germanSoldier = new GermanSoldier(mVideo);
            bullets = new Bullets();

            level1 = new Level1(mVideo, americanSoldier.Position);
            activeLevel = level1;

            Events.MouseButtonUp += Events_MouseButtonUp;
            Events.MouseButtonDown += Events_MouseButtonDown;


            Events.Fps = 10;

            Events.Tick += Events_Tick;
            Events.Run();
        }

        private void Events_Tick(object sender, TickEventArgs e)
        {
            //Clear

            //Update           
            americanSoldier.Update(activeLevel, collRight, collLeft, collUp, collDown);
            //germanSoldier.Update(activeLevel, collRight, collLeft, collUp, collDown);
            collDown = false;
            collRight = false;
            collLeft = false;
            collUp = false;
            UpdateBullets();

            /*hit = false;
            bullets.CheckHit(bulletInList, hit);
            recBullet = bullets.CollRecBullet;
            for (int k = 0; k < recBullet.Length ; k++)
            {
                for (int l = 0; l < activeLevel.bulletColl.Length; l++)
                {
                    if (recBullet[k].IntersectsWith(activeLevel.bulletColl[l]))
                    {
                        bulletInList = k;
                        hit = true;
                        break;
                    }
                    else
                        hit = false;                    
                }
                if (hit)
                    break;
            }
            bullets.CheckHit(bulletInList, hit);*/
            for (int c = 0; c < activeLevel.spriteColl.Length; c++)
            {
                if (americanSoldier.colRectangleRight.IntersectsWith(activeLevel.spriteColl[c]))
                {
                    collRight = true;
                }

                if (americanSoldier.colRectangleLeft.IntersectsWith(activeLevel.spriteColl[c]))
                {
                    collLeft = true;
                }
                if (americanSoldier.colRectangleUp.IntersectsWith(activeLevel.spriteColl[c]))
                {
                    collUp = true;
                }

                if (americanSoldier.colRectangleDown.IntersectsWith(activeLevel.spriteColl[c]))
                {
                    collDown = true;
                }
            }

            //Draw
            DrawAll();

            //Update
            mVideo.Update();
        }

        private void UpdateBullets()
        {
            for (int i = 0; i < bulletList.Count; i++)
            {
                bulletList[i].Move();
                bulletList[i].Draw(mVideo);
            }

            for (int l = 0; l < activeLevel.bulletColl.Length; l++)
            {
                bulletList.RemoveAll(x => new Rectangle(x.CollRecX, x.CollRecY, 15, 15).IntersectsWith(activeLevel.bulletColl[l]) || x.CollRecX > 1500 || x.CollRecX < 0 || x.CollRecY > 750 || x.CollRecY < 0);
            }
        }

        private void DrawAll()
        {
            activeLevel.CreateWorld(americanSoldier.position);
            americanSoldier.Draw();
            //germanSoldier.Draw();
            bullets.Draw(mVideo);


        }
        private void Events_MouseButtonDown(object sender, MouseButtonEventArgs e)
        {
            clickDown = true;
        }
        private void Events_MouseButtonUp(object sender, MouseButtonEventArgs e)
        {

            int x = americanSoldier.positionMid.X;
            int y = americanSoldier.positionMid.Y;
            if (americanSoldier.Direction == "left" || americanSoldier.Direction == "right" || americanSoldier.Direction == "still")
                y = americanSoldier.positionMid.Y + 40;
            else
                x = americanSoldier.positionMid.X + 40;
            //Bullet bullet = new Bullet(x, y, bullets,americanSoldier.Direction);
            bulletList.Add(new Bullet(x, y, americanSoldier.Direction));

        }
    }
}
