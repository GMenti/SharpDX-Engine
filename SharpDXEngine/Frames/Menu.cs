using GameClient.Controllers;
using Microsoft.Xna.Framework;
using SharpDXEngine.Frames.Components;

namespace SharpDXEngine.Frames
{
    class Menu
    {
        private Picture background;

        private TextBox txtLogin;
        private TextBox txtPassword;

        public void Initialize()
        {
            background = new Picture(new Vector2(0, 0));
            txtLogin = new TextBox();
            txtPassword = new TextBox();
        }

        public void Load()
        {
            background.Load();

            txtLogin.Load();
            txtLogin.position = new Vector2(100, 100);

            txtPassword.Load();
            txtPassword.position = new Vector2(100, 200);
            txtPassword.isPassword = true;
        }

        public void Update()
        {
            txtLogin.Update();
            txtPassword.Update();
        }

        public void Draw()
        {
            background.Draw();
            txtLogin.Draw();
            txtPassword.Draw();
        }
    }
}
