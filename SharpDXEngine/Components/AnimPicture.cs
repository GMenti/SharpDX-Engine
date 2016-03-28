using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using MonoGame.Extended.Timers;
using SharpDXEngine.Utilities;
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
            this.animTimer = new ContinuousClock(new TimeSpan(0, 0, 0, 0, 16));
            this.animTimer.Tick += delegate (object sender, EventArgs e) {
                if (this.spriteOrigin.X + Config.GAME_WIDTH == this.texture.Width) {
                    this.decrementX = true;
                }

                if (this.spriteOrigin.X == 0) {
                    this.decrementX = false;
                }

                if (this.spriteOrigin.Y + Config.GAME_HEIGHT == this.texture.Height) {
                    this.decrementY = true;
                }

                if (this.spriteOrigin.Y == 0) {
                    this.decrementY = false;
                }

                if (decrementY) {
                    this.spriteOrigin.Y -= 1;
                } else {
                    this.spriteOrigin.Y += 1;
                }

                if (decrementX) {
                    this.spriteOrigin.X -= 1;
                } else {
                    this.spriteOrigin.X += 1;
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
