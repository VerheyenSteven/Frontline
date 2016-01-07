using SdlDotNet.Core;
using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SdlDotNet.Input;
using System.Media;

namespace Frontline
{
    class Manager
    {
        private Surface mVideo;
        private SoundPlayer soundplayer;
        private SoundPlayer gunFire;
        private SoundPlayer bulletHit;
        private AmericanSoldier americanSoldier;
        private bool collRight, collLeft, collUp, collDown;
        private bool clickDown;
        Level level1, activeLevel;
        private int _reloadTimer = 0;

        List<Bullet> bulletList = new List<Bullet>();
        List<GermanSoldier> germanSolderList = new List<GermanSoldier>();

        //used with Bullet_old
        /*private Bullets bullets;
        private bool hit;
        private int bulletInList = 0;
        private Rectangle[] recBullet;*/
        //private GermanSoldier germanSoldier;
        public Manager()
        {
            mVideo = Video.SetVideoMode(1500, 750);

            americanSoldier = new AmericanSoldier(mVideo);
            //germanSoldier = new GermanSoldier(mVideo);
            germanSolderList.Add(new GermanSoldier(mVideo, 0, 0));
            germanSolderList.Add(new GermanSoldier(mVideo, 60, 100));
            germanSolderList.Add(new GermanSoldier(mVideo, 500, 600));

            level1 = new Level1(mVideo, americanSoldier.Position);
            activeLevel = level1;

            bulletHit = new SoundPlayer("Sprites/Music/Dirt_Sand_06.wav");
            gunFire = new SoundPlayer("Sprites/Music/gunfire.wav");            

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
            americanSoldier.Update(activeLevel, collRight, collLeft, collUp, collDown, americanSoldier.Direction);
            //germanSoldier.Update(activeLevel, collRight, collLeft, collUp, collDown);

            collDown = false; //if not false, can't walk
            collRight = false;
            collLeft = false;
            collUp = false;

            //detect collision with bullets and sprites
            UpdateBullets(); 

            //detect collision with User and sprite
            CollisionDetectonUser();

            for (int i = 0; i < germanSolderList.Count; i++)
            {
                germanSolderList[i].Update(activeLevel, collRight, collLeft, collUp, collDown, americanSoldier.Direction);
                germanSolderList[i].Draw();
            }

            //Draw
            DrawAll();

            //Update
            mVideo.Update();
        }

        private void CollisionDetectonUser()
        {
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
                if (bulletList.RemoveAll(x => new Rectangle(x.CollRecX, x.CollRecY, 15, 15).IntersectsWith(activeLevel.bulletColl[l])) > 0)
                {
                    soundplayer = bulletHit;
                    soundplayer.Play();
                }
                    
                bulletList.RemoveAll(x => new Rectangle(x.CollRecX, x.CollRecY, 15, 15).IntersectsWith(activeLevel.bulletColl[l]) || x.CollRecX > 1500 || x.CollRecX < 0 || x.CollRecY > 750 || x.CollRecY < 0);
            }
        }

        private void DrawAll()
        {
            activeLevel.CreateWorld(americanSoldier.position);
            //germanSoldier.Draw();
            americanSoldier.Draw();
        }
        private void Events_MouseButtonDown(object sender, MouseButtonEventArgs e)
        {
            clickDown = true;
        }
        private void Events_MouseButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_reloadTimer == 2)
            {
                _reloadTimer = 0;
                int x = americanSoldier.positionMid.X;
                int y = americanSoldier.positionMid.Y;
                if (americanSoldier.Direction == "left" || americanSoldier.Direction == "right" || americanSoldier.Direction == "still")
                    y = americanSoldier.positionMid.Y + 40;
                else
                    x = americanSoldier.positionMid.X + 40;
                //Bullet bullet = new Bullet(x, y, bullets,americanSoldier.Direction);
                bulletList.Add(new Bullet(x, y, americanSoldier.Direction));
                soundplayer = gunFire;
                soundplayer.Play();
            }
            else _reloadTimer++;

        }
    }
}
