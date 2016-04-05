using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameLibrary.Components
{
    public class Picture
    {
        public Texture2D texture;
        public Vector2 position;
        public float rotation;
        public Vector2 expandFactor;
        public Vector2 spriteOrigin;
        public Color color;
        public bool isVisible;

        public Picture()
        {
            this.position = Vector2.Zero;
            this.rotation = 0f;
            this.color = Color.White;
            this.expandFactor = new Vector2(1f, 1f);
            this.spriteOrigin = Vector2.Zero;
            this.isVisible = false;
        }

        public void Show()
        {
            this.isVisible = true;
        }

        public void Hide()
        {
            this.isVisible = false;
        }

        public void Load(ContentManager content, string filePath)
        {
            this.texture = content.Load<Texture2D>(filePath);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (this.isVisible == false) {
                return;
            }

            spriteBatch.Draw(
                this.texture,
                this.position,
                null,
                this.color,
                this.rotation,
                this.spriteOrigin,
                expandFactor,
                SpriteEffects.None,
                0f
            );
        }
    }
}
