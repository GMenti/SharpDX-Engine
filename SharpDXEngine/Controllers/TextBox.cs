using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameClient.Components;
using System;

namespace GameClient.Controllers
{
    class TextBox
    {
        public SpriteFont spriteFont { get; set; }
        public Texture2D texture { get; set; }
        public Vector2 position { get; set; }
        public string text { get; set; }
        public Color color { get; set; }
        private int timer500;

        public void Load()
        {
            this.text = "";
            this.position = new Vector2(0, 0);
            this.color = Color.Black;
            this.spriteFont = MainGame.engineContent.Load<SpriteFont>("Fonts/myFont");
        }

        public void Draw()
        {
            MainGame.spriteBatch.DrawString(
                this.spriteFont,
                this.text,
                this.position,
                this.color
            );
        }

        public void Update()
        {
            if (MainGame.totalTime.Seconds < this.timer500) {
                return;
            }

            InputSystem.CharEntered += delegate (Object o, CharacterEventArgs e) {
                if (spriteFont.Characters.Contains(e.Character)) {
                    text += e.Character;
                    return;
                }

                if (e.Character == '\b' && text.Length > 0) {
                    text = text.Substring(0, text.Length - 1);
                    return;
                }

                if (e.Character == '\r') {
                    text += "\n";
                }
            };

            this.timer500 = MainGame.totalTime.Seconds + 500;
        }
    }
}
