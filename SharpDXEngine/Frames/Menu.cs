using SharpDXEngine.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input;
using SharpDXEngine.Libraries;
using System;

namespace SharpDXEngine.Frames
{
    class Menu
    {
        private Picture background;
        private Picture menu;

        private TextBox txtLogin;
        private TextBox txtPassword;

        public Menu()
        {
            background = new Picture(new Vector2(0, 0));
            menu = new Picture(new Vector2(0, 0));

            txtLogin = new TextBox(new Vector2(334, 341), 26) {
                isSelected = true
            };

            txtPassword = new TextBox(new Vector2(333, 367), 26) {
                isPassword = true
            };

            InputSystem.CharEntered += delegate (Object o, CharacterEventArgs e) {
                if (e.Character != '\t') {
                    return;
                }

                if (txtLogin.isSelected) {
                    txtLogin.isSelected = false;
                    txtPassword.isSelected = true;
                } else {
                    txtLogin.isSelected = true;
                    txtPassword.isSelected = false;
                }
            };
        }

        public void Load(ContentManager content)
        {
            Song song = content.Load<Song>("Intro2");
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;

            background.Load(content, "GUI/Menu/background");
            menu.Load(content, "GUI/Menu/menu");

            txtLogin.Load(
                content, 
                "GUI/Menu/textbox",
                "Fonts/Georgia"
            );

            txtPassword.Load(
                content,
                "GUI/Menu/textbox",
                "Fonts/Georgia"
            );
        }

        public void Update(GameTime gameTime)
        {
            txtLogin.Update(gameTime);
            txtPassword.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);
            menu.Draw(spriteBatch);

            txtLogin.Draw(spriteBatch);
            txtPassword.Draw(spriteBatch);
        }
    }
}
