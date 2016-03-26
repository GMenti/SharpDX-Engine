using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using SharpDXEngine.Libraries;

namespace SharpDXEngine.Components {
    class TextBox
    {
        private Picture picture;
        private Label label;

        private string text;
        private int maxLength;
        public Boolean isSelected;

        public TextBox(Vector2 position, int maxLength)
        {
            this.picture = new Picture(position);

            this.label = new Label(
                "", 
                Color.White, 
                new Vector2(position.X + 3, position.Y)
            );
            
            this.text = "";
            this.maxLength = maxLength;
            this.isSelected = false;

            this.StartKeyReceiver();
        }

        public void Load(ContentManager content, string picturePath, string fontPath)
        {
            this.picture.Load(content, picturePath);
            this.label.Load(content, fontPath);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.picture.Draw(spriteBatch);
            this.label.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            this.label.caption = this.text;
            this.isSelected = this.checkSelected();
        }

        private void StartKeyReceiver() {
            InputSystem.CharEntered += delegate (Object o, CharacterEventArgs e) {
                if (this.isSelected == false) {
                    return;
                }

                if (e.Character == '\b' && this.text.Length > 0) {
                    this.text = this.text.Substring(0, this.text.Length - 1);
                    return;
                }

                if (this.checkFull() == true) {
                    return;
                }

                if (e.Character == '\r') {
                    this.text += '\n';
                    return;
                }

                this.text += e.Character;
            };
        }

        private Boolean checkSelected() {
            if (Mouse.GetState().LeftButton != ButtonState.Pressed) {
                return this.isSelected;
            }

            Rectangle position = this.picture.getRectangle();
            this.isSelected = position.Contains(Mouse.GetState().Position);

            return this.isSelected;
        }

        private Boolean checkFull() {
            if (this.text.Length <= this.maxLength) {
                return false;
            }

            return true;
        }



    }
}
