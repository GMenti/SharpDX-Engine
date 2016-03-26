﻿using SharpDXEngine.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

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

            txtLogin = new TextBox(new Vector2(334, 341), 26);
            txtLogin.isSelected = true;

            txtPassword = new TextBox(new Vector2(333, 367), 26);
        }

        public void Load(ContentManager content)
        {
            Song song = content.Load<Song>("Intro2");
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;

            background.Load(content, "GUI/Menu/background");

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

            txtLogin.Draw(spriteBatch);
            txtPassword.Draw(spriteBatch);
        }
    }
}
