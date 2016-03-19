using GameClient.Controllers;
using Microsoft.Xna.Framework;
using SharpDXEngine.Frames.Components;

namespace SharpDXEngine.Frames
{
    class Menu
    {
        private Picture background;
        private TextBox textBox;
        
        public void Initialize()
        {
            background = new Picture(new Vector2(0, 0));
            textBox = new TextBox();
        }

        public void Load()
        {
            background.Load();

            textBox.Load();
            textBox.position = new Vector2(100, 100);
        }

        public void Update()
        {
            textBox.Update();
        }

        public void Draw()
        {
            background.Draw();
            textBox.Draw();
        }
    }
}
