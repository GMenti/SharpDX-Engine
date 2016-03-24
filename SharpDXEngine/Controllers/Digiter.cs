using GameClient.Components;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Timers;
using System;

namespace SharpDXEngine.Controllers
{
    class Digiter
    {
        private string text;
        private ContinuousClock keyTimer;

        public Digiter()
        {
            this.text = "";
            this.keyTimer = new ContinuousClock(1);
            this.keyTimer.Start();
        }

        public string getKeyPressed(GameTime gameTime)
        {
            this.updateValue(gameTime);
            return this.text;
        }

        private void updateValue(GameTime gameTime)
        {
            InputSystem.CharEntered += delegate (Object o, CharacterEventArgs e) {
                this.keyTimer.Update(gameTime);

                keyTimer.Tick += delegate (object sender, EventArgs e2) {
                    this.text += e.Character;
                };
            };
        }

    }
}
