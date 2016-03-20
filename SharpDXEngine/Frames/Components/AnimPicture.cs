using GameClient;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SharpDXEngine.Frames.Components
{
    class AnimPicture : Picture
    {
        
        public AnimPicture(Vector2 position) : base(position)
        {
            this.position = new Vector2(300, 300);
            this.expandFactor = new Vector2(0.2f);
        }

        public new void Load(string basePath)
        {
            base.Load(basePath);

            this.spriteOrigin = new Vector2(
                this.texture.Width / 2,
                this.texture.Height / 2
            );
        }

        public void Update()
        {
            this.rotation += 0.05f;
        }

    }
}
