﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.BitmapFonts;

namespace SharpDXEngine.Components {
    class Label
    {

        public string caption;
        public BitmapFont font;
        public Color color;
        public Vector2 position;

        public Label(string text, Color color, Vector2 position)
        {
            this.caption = text;
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
               this.caption,
               this.position,
               this.color
           );
        }

        public Rectangle GetStringRectangle()
        {
            return this.font.GetStringRectangle(this.caption, this.position);
        }

        public Rectangle GetRectangle()
        {
            return this.font.GetStringRectangle("asd", this.position);
        }
    }
}
