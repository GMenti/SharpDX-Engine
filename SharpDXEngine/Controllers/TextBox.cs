using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameClient.Components;
using System;
using Microsoft.Xna.Framework.Input;
using System.Timers;
using System.Text.RegularExpressions;
using MonoGame.Extended.BitmapFonts;
using Microsoft.Xna.Framework.Content;

namespace GameClient.Controllers
{
    class TextBox
    {
        public BitmapFont spriteFont;
        public Texture2D texture;
        public Vector2 position;
        public string value;
        public Color color;

        private int width;
        private int height;

        public Boolean selected;
        private string digitingChar;

        public Boolean isPassword;

        private int timer1000;
        public Timer timer;

        public int maxLength;

        public TextBox(int width, int height)
        {
            this.selected = false;
            this.value = "";
            this.position = new Vector2(0, 0);
            this.color = Color.White;

            this.width = width;
            this.height = height;
        }

        public void Load(ContentManager content, string texturePath = null)
        {
            timer = new Timer();
            timer.Interval = 300;
            timer.Elapsed += OnTimedEvent;

            this.spriteFont = content.Load<BitmapFont>(texturePath);
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if (this.selected == false) {
                this.timer.Enabled = false;
                this.digitingChar = "";
                return;
            }

            this.digitingChar = (digitingChar == "|") ? "" : "|";
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (this.texture != null) {
                spriteBatch.Draw(
                    this.texture,
                    this.position,
                    Color.Black * 0.8f
                );
            }

            string textOnField = this.value;

            if (this.isPassword) {
                textOnField = new Regex("\\S").Replace(textOnField, "*");
            } 

            spriteBatch.DrawString(
                this.spriteFont,
                textOnField + this.digitingChar,
                new Vector2(this.position.X + 3, this.position.Y + 1),
                this.color
            );
        }

        public void Update()
        {
            this.UpdateText();
            this.checkClick();
        }

        private void checkClick()
        {
            if (Mouse.GetState().LeftButton != ButtonState.Pressed) {
                return;
            }

            this.selected = false;

            Point mousePosition = Mouse.GetState().Position;
            if (mousePosition.X < position.X || mousePosition.Y < position.Y) {
                return;
            }

            if (mousePosition.X > this.position.X + this.width || mousePosition.Y > this.position.Y + this.height) {
                return;
            }

            this.selected = true;
            this.timer.Enabled = true;
        }

        private void UpdateText()
        {
            if (MainGame.totalTime.Milliseconds < this.timer1000) {
                return;
            }

            InputSystem.CharEntered += delegate (Object o, CharacterEventArgs e) {
                if (this.selected == false) {
                    return;
                }

                if (e.Character == '\b' && this.value.Length > 0) {
                    this.value = value.Substring(0, value.Length - 1);
                    return;
                }

                if (this.value.Length >= this.maxLength) {
                    return;
                }

                //if (spriteFont.Characters.Contains(e.Character)) {
                    
                //}

                if (e.Character == '\r') {
                    this.value += "\n";
                }

                this.value += e.Character;
                return;
            };

            this.timer1000 = MainGame.totalTime.Milliseconds + 1000;
        }
    }
}
