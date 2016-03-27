using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework.Content;
using SharpDXEngine.Libraries;
using MonoGame.Extended.Timers;
using System.Text.RegularExpressions;
using Microsoft.Xna.Framework.Input;
using SharpDXEngine.Utilities.Helpers;

namespace SharpDXEngine.Components {
    class TextBox
    {
        private Picture picture;
        private Label label;
        private int maxLength;
        public Boolean isPassword;
        private int position;

        private string _text;
        public string text {
            get {
                if (this.isPassword) {
                    return StringHelper.convertToPassword(this._text);
                }
                return this._text;
            }
            set {
                this._text = value;
            }
        }

        private Boolean _isSelected;
        public Boolean selected {
            get {
                return this._isSelected;
            }
            set {
                this._isSelected = value;
                if (value == false) {
                    this.label.caption = this.text.Replace("|", "");
                }
            }
        }

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
            if (this.selected == false) {
                return;
            }

            this.label.caption = this.text.Insert(this.position, "|");
        }

        private void StartInputSystem() {
            InputSystem.CharEntered += delegate (Object o, CharacterEventArgs e) {
                if (this.selected == false) {
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
                if (this.selected == false) {
                    return;
                }

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

            InputSystem.MouseUp += delegate (Object o, MouseEventArgs e) {
                Rectangle position = this.picture.getRectangle();
                this.selected = position.Contains(e.Location);
            };
        }

        private Boolean checkFull() {
            if (this.text.Length <= this.maxLength) {
                return false;
            }

            return true;
        }

    }
}
