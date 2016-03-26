using Microsoft.Xna.Framework;
using MonoGame.Extended;
using MonoGame.Extended.Timers;
using SharpDXEngine.Components;
using System;

namespace SharpDXEngine.Utilities {
    class FPS : Label {
        private FramesPerSecondCounter fpsCounter;
        private ContinuousClock fpsTimer;
        private int fps;

        public FPS(string text, Color color, Vector2 position) : base(text, color, position) {
            this.fpsCounter = new FramesPerSecondCounter();

            this.fpsTimer = new ContinuousClock(1);
            this.fpsTimer.Tick += delegate (object sender, EventArgs e) {
                base.caption = "FPS: " + this.fps;
                this.fpsCounter.Reset();
            };
            this.fpsTimer.Start();
        }

        public void Refresh(GameTime gameTime) {
            base.Update(gameTime);
            this.fpsCounter.Update(gameTime);
            this.fpsTimer.Update(gameTime);
            this.fps = (int)fpsCounter.TotalFrames;
        }



    }
}
