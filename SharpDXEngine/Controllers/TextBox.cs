using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameClient.Components;
using System;
using Microsoft.Xna.Framework.Input;
using System.Timers;

namespace GameClient.Controllers
{
    class TextBox
    {
        public SpriteFont spriteFont { get; set; }
        public Texture2D texture { get; set; }
        public Vector2 position { get; set; }
        public string value { get; set; }
        public Color color { get; set; }

        private Boolean selected;
        private string digitingChar;

        private int timer1000;
        private Timer timer;

        public void Load()
        {
            this.selected = false;
            this.value = "";
            this.position = new Vector2(0, 0);
            this.color = Color.White;
            this.spriteFont = MainGame.engineContent.Load<SpriteFont>("Fonts/myFont");
            this.texture = MainGame.engineContent.Load<Texture2D>("GUI/Default/textbox");

            timer = new Timer();
            timer.Interval = 500;
            timer.Elapsed += OnTimedEvent;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if (this.selected == false) {
                timer.Enabled = false;
                this.digitingChar = "";
                return;
            }

            this.digitingChar = (digitingChar == "|") ? "" : "|";
        }

        public void Draw()
        {
            MainGame.spriteBatch.Draw(
                this.texture,
                this.position,
                Color.Black
            );


            MainGame.spriteBatch.DrawString(
                this.spriteFont,
                this.value + this.digitingChar,
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

            if (mousePosition.X > this.position.X + this.texture.Width || mousePosition.Y > this.position.Y + this.texture.Height) {
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

                if (spriteFont.Characters.Contains(e.Character)) {
                    value += e.Character;
                    return;
                }

                if (e.Character == '\b' && value.Length > 0) {
                    value = value.Substring(0, value.Length - 1);
                    return;
                }

                if (e.Character == '\r') {
                    value += "\n";
                }
            };

            this.timer1000 = MainGame.totalTime.Milliseconds + 1000;
        }
    }
}
