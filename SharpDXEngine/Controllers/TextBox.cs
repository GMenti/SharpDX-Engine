using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameClient.Components;
using System;
using Microsoft.Xna.Framework.Input;
using System.Timers;
using System.Text.RegularExpressions;
using MonoGame.Extended.BitmapFonts;
using Microsoft.Xna.Framework.Content;
using SharpDXEngine.Controllers;

namespace GameClient.Controllers
{
    class TextBox
    {
        private Label labelText;
        private Digiter digiter;

        public Boolean isSelected;

        public TextBox(Vector2 position)
        {
            this.labelText = new Label("", Color.White, position);
            this.digiter = new Digiter();
        }

        public void Load(ContentManager content, string filePath)
        {
            this.labelText.Load(content, filePath);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.labelText.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            this.checkSelected();

            if (this.isSelected == true) {
                this.labelText.text = this.digiter.getKeyPressed(gameTime);
            }
        }

        private void checkSelected()
        {
            if (Mouse.GetState().LeftButton != ButtonState.Pressed) {
                return;
            }

            Rectangle position = this.labelText.GetStringRectangle();
            this.isSelected = position.Contains(Mouse.GetState().Position);
        }
    }
}
