using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Timers;
using SharpDXEngine.Controllers;
using System;

namespace GameClient.Utilities
{
    class FPS : Caption
    {
        private FramesPerSecondCounter fpsCounter;
        private ContinuousClock timer;

        public FPS(string text, Color color, Vector2 position) : base(text, color, position)
        {
            this.fpsCounter = new FramesPerSecondCounter();
            this.timer = new ContinuousClock(1);
            this.timer.Start();
        }

        public new void Load(ContentManager content)
        {
            base.Load(content);
        }

        public new void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            this.fpsCounter.Update(gameTime);
            this.timer.Update(gameTime);

            timer.Tick += delegate (object sender, EventArgs e) {
                base.text = "FPS: " + (int)fpsCounter.CurrentFramesPerSecond;
            };
        }

        public new void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        
    }
}
