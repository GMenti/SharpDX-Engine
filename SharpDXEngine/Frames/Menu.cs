using GameClient.Controllers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SharpDXEngine.Controllers;

namespace SharpDXEngine.Frames
{
    class Menu
    {
        private Picture background;

        private TextBox txtLogin;
        private TextBox txtPassword;

        public Menu()
        {
            background = new Picture(new Vector2(0, 0));

            txtLogin = new TextBox(200, 20);
            txtPassword = new TextBox(200, 20);
        }

        public void Load(ContentManager content)
        {
            Song song = content.Load<Song>("Intro2");
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;

            background.Load(content, "GUI/Menu/login");

            txtLogin.Load(content, "Fonts/Georgia");
            txtLogin.position = new Vector2(333, 340);
            txtLogin.maxLength = 26;
            txtLogin.selected = true;
            txtLogin.timer.Enabled = true;
           
            txtPassword.Load(content, "Fonts/Georgia");
            txtPassword.position = new Vector2(333, 367);
            txtPassword.isPassword = true;
            txtPassword.maxLength = 26;
        }

        public void Update()
        {
            txtLogin.Update();
            txtPassword.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);

            txtLogin.Draw(spriteBatch);
            txtPassword.Draw(spriteBatch);
        }
    }
}
