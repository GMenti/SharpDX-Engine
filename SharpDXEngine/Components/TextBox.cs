using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace SharpDXEngine.Components {
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
            this.labelText.text = this.digiter.text;
            this.checkSelected();
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
