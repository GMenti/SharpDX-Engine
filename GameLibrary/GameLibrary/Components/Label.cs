using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.BitmapFonts;

namespace GameLibrary.Components
{
    public class Label
    {

        public string caption;
        public BitmapFont font;
        public Color color;
        public Vector2 position;
        public bool isVisible;

        public Label()
        {
            this.caption = "";
            this.color = Color.White;
            this.position = Vector2.Zero;
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
            this.font = content.Load<BitmapFont>(filePath);
        }

        public void Update(GameTime gameTime)
        {
            //TODO
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (this.isVisible == false) {
                return;
            }

            spriteBatch.DrawString(
               this.font,
               this.caption,
               this.position,
               this.color
           );
        }

        public Rectangle GetStringRectangle()
        {
            return this.font.GetStringRectangle(this.caption, this.position);
        }

    }
}
