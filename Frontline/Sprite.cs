using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontline
{
    public class Sprite
    {
        Surface video;
        Surface image;
        Point position;

        public Sprite(Surface video, Point position, Surface tile)
        {
            this.video = video;
            this.position = position;
            image = tile;
        }
        public void Draw()
        {
            video.Blit(image, position);
        }
    }
}
