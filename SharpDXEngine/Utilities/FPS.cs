using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Timers;
using SharpDXEngine.Controllers;
using System;

namespace GameClient.Utilities {
    class FPS : Label {
        private FramesPerSecondCounter fpsCounter;
        private ContinuousClock fpsTimer;
        private int fps;

        public FPS(string text, Color color, Vector2 position) : base(text, color, position) {
            this.fpsCounter = new FramesPerSecondCounter();
            this.fpsTimer = new ContinuousClock(1);
            this.fpsTimer.Start();
        }

        public void Refresh(GameTime gameTime) {
            base.Update(gameTime);
            this.fpsCounter.Update(gameTime);
            this.fpsTimer.Update(gameTime);
            this.fps = (int)fpsCounter.TotalFrames;

            fpsTimer.Tick += delegate (object sender, EventArgs e) {
                base.text = "FPS: " + this.fps;
                this.fpsCounter.Reset();
            };
        }



    }
}
