using SharpDXEngine.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input;
using SharpDXEngine.Libraries;
using System;
using SharpDXEngine.Utilities;
using SharpDXEngine.Utilities.Helpers;

namespace SharpDXEngine.Frames.Menu
{
    class Menu : MenuController
    {
        private AnimPicture background;
        private Picture logo;
        private Picture login;

        private TextBox txtLogin;
        private TextBox txtPassword;

        private LabelButton btnLogin;

        public Menu()
        {
            background = new AnimPicture(new Vector2(0, 0));

            logo = new Picture(new Vector2(NumberHelper.getCenterX(Config.GAME_WIDTH, 500), 60));

            login = new Picture(new Vector2(NumberHelper.getCenterX(Config.GAME_WIDTH, 276), 300));

            txtLogin = new TextBox(new Vector2(290, 368), 26) {
                isSelected = true
            };

            txtPassword = new TextBox(new Vector2(290, 408), 26) {
                isPassword = true
            };

            btnLogin = new LabelButton("Entrar", Color.White, new Vector2(290, 428));

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

            background.Load(content, "GUI/Menu/palletTown");
            background.spriteOrigin.X = NumberHelper.getRandom(0, background.texture.Width - Config.GAME_WIDTH);
            background.spriteOrigin.Y = NumberHelper.getRandom(0, background.texture.Height - Config.GAME_HEIGHT);

            logo.Load(content, "GUI/logo");
            login.Load(content, "GUI/Menu/login");

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

            btnLogin.Load(content, "Fonts/Georgia");
        }

        public void Update(GameTime gameTime)
        {
            background.Update(gameTime);
            txtLogin.Update(gameTime);
            txtPassword.Update(gameTime);
            btnLogin.Update(gameTime);

            if (btnLogin.isSubmited == true) {
                this.Login(txtLogin.text, txtPassword._text);
                btnLogin.isSubmited = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);
            logo.Draw(spriteBatch);
            login.Draw(spriteBatch);
            txtLogin.Draw(spriteBatch);
            txtPassword.Draw(spriteBatch);
            btnLogin.Draw(spriteBatch);
        }
    }
}
