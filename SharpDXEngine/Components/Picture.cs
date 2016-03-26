using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SharpDXEngine.Components {
    class Picture
    {
        protected Texture2D texture;
        public Vector2 position;
        public float rotation;
        public Vector2 expandFactor;
        public Vector2 spriteOrigin;

        public Picture(Vector2 position)
        {
            this.position = position;
            this.rotation = 0f;
            this.expandFactor = new Vector2(1f, 1f);
            this.spriteOrigin = Vector2.Zero;
        }

        public void Load(ContentManager content, string filePath)
        {
            this.texture = content.Load<Texture2D>(filePath);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                this.texture,
                this.position,
                null,
                Color.White,
                this.rotation,
                this.spriteOrigin,
                expandFactor,
                SpriteEffects.None,
                0f
            );
        }

        public Rectangle getRectangle() {
            return new Rectangle(
                (int)this.position.X,
                (int)this.position.Y,
                this.texture.Width,
                this.texture.Height
            );
        }
    }
}
