using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.BitmapFonts;

namespace SharpDXEngine.Controllers
{
    class Label
    {

        public string text;
        public BitmapFont font;
        public Color color;
        public Vector2 position;

        public Label(string text, Color color, Vector2 position)
        {
            this.text = text;
            this.color = color;
            this.position = position;
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
            spriteBatch.DrawString(
               this.font,
               this.text,
               this.position,
               this.color
           );
        }

        public Rectangle GetStringRectangle()
        {
            return this.font.GetStringRectangle(this.text, this.position);
        }

        public Rectangle GetRectangle()
        {
            return this.font.GetStringRectangle("asd", this.position);
        }
    }
}
