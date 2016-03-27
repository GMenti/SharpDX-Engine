using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework.Content;
using SharpDXEngine.Libraries;
using MonoGame.Extended.Timers;
using System.Text.RegularExpressions;
using Microsoft.Xna.Framework.Input;

namespace SharpDXEngine.Components {
    class TextBox
    {
        private Picture picture;
        private Label label;

        private string text;
        private int maxLength;
        public Boolean isSelected;
        public Boolean isPassword;
        private int position;

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
            this.position = 0;

            this.StartInputSystem();
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
            string caption = this.text;
            if (this.isPassword) {
                caption = new Regex("\\S").Replace(caption, "*");
            }

            this.label.caption = caption;

            if (this.isSelected == true) {
                if (this.position >= 0) {
                    this.label.caption = this.label.caption.Insert(this.position, "|");
                } else {
                    this.label.caption += "|";
                }
            }

            this.checkSelected();
        }

        private void StartInputSystem() {
            InputSystem.CharEntered += delegate (Object o, CharacterEventArgs e) {
                if (this.isSelected == false) {
                    return;
                }

                if (e.Character == '\b' && this.text.Length > 0 && this.position > 0) {
                    this.position--;
                    this.text = this.text.Remove(this.position, 1);
                    return;
                }

                if (this.checkFull() == true) {
                    return;
                }

                if (e.Character == '\r') {
                    this.text += '\n';
                    return;
                }

                if (e.Character == '\t') {
                    return;
                }

                this.text = this.text.Insert(this.position, e.Character.ToString());
                this.position++;
            };

            InputSystem.KeyDown += delegate (Object o, KeyEventArgs e) {
                switch (e.KeyCode) {
                    case Keys.Left:
                        if (this.position >= 1) {
                            this.position--;
                        }
                        break;

                    case Keys.Right:
                        if (this.position < this.text.Length) {
                            this.position++;
                        }
                        break;
                }
            };
        }
         
        private void checkSelected() {
            if (Mouse.GetState().LeftButton != ButtonState.Pressed) {
                return;
            }

            Rectangle position = this.picture.getRectangle();
            this.isSelected = position.Contains(Mouse.GetState().Position);
        }

        private Boolean checkFull() {
            if (this.text.Length <= this.maxLength) {
                return false;
            }

            return true;
        }



    }
}
