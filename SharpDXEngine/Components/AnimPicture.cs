using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using MonoGame.Extended.Timers;
using System;

namespace SharpDXEngine.Components
{
    class AnimPicture : Picture
    {
        public ContinuousClock animTimer;
        private Boolean decrementX;
        private Boolean decrementY;

        public AnimPicture(Vector2 position) : base(position)
        {
            this.animTimer = new ContinuousClock(new TimeSpan(0, 0, 0, 0, 20));
            this.animTimer.Tick += delegate (object sender, EventArgs e) {
                if (this.spriteOrigin.X + 800 == this.texture.Width) {
                    this.decrementX = true;
                }

                if (this.spriteOrigin.X == 0) {
                    this.decrementX = false;
                }

                if (this.spriteOrigin.Y + 600 == this.texture.Height) {
                    this.decrementY = true;
                }

                if (this.spriteOrigin.Y == 0) {
                    this.decrementY = false;
                }

                if (decrementY) {
                    this.spriteOrigin.Y--;
                } else {
                    this.spriteOrigin.Y++;
                }

                if (decrementX) {
                    this.spriteOrigin.X--;
                } else {
                    this.spriteOrigin.X++;
                }
            };
            this.animTimer.Start();
        }

        public new void Load(ContentManager content, string basePath)
        {
            base.Load(content, basePath);
        }

        public void Update(GameTime gameTime)
        {
            this.animTimer.Update(gameTime);
        }

    }
}
