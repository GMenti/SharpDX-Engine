using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace SharpDXEngine.Controllers
{
    class AnimPicture : Picture
    {
        
        public AnimPicture(Vector2 position) : base(position)
        {
            this.position = new Vector2(300, 300);
            this.expandFactor = new Vector2(0.2f);
        }

        public new void Load(ContentManager content, string basePath)
        {
            base.Load(content, basePath);

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
