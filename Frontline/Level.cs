using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontline
{
    public abstract class Level
    {
        protected Surface video;

        public Level(Surface video)
        {
            this.video = video;
        }
        protected int[,] intTileArray;

        protected Sprite[,] spriteTileArray;
        protected Sprite[,] spriteTileArrayScreen;
        public Rectangle[] spriteColl;
        public Rectangle[] bulletColl;

        public abstract void CreateWorld(Point positionUser);

        public void DrawWorld(Point positionUser)
        {
            for (int b = 0 ; b < spriteTileArrayScreen.GetUpperBound(0); b++)
            {
                for (int n = 0; n < spriteTileArrayScreen.GetUpperBound(1); n++)
                {
                    if (spriteTileArrayScreen[b, n] != null)
                    {
                        spriteTileArrayScreen[b, n].Draw();
                    }
                }
            }
        }
    }
}
