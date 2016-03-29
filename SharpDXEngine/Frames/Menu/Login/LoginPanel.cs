using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDXEngine.Components;
using SharpDXEngine.Libraries;
using SharpDXEngine.Utilities;
using SharpDXEngine.Utilities.Helpers;

namespace SharpDXEngine.Frames.Menu.Login
{
    class LoginPanel : MenuController
    {
        private Picture login;
        private TextBox txtLogin;
        private TextBox txtPassword;
        private LabelButton btnLogin;

        private Vector2 position;

        public LoginPanel()
        {
            this.position = new Vector2(NumberHelper.getCenterX(Config.GAME_WIDTH, 276), 300);

            login = new Picture() {
                position = this.position
            };

            txtLogin = new TextBox() {
                maxLength = 26,
                picturePosition = new Vector2(
                    this.position.X + 28,
                    this.position.Y + 67
                ),
                labelPosition = new Vector2(
                    this.position.X + 32,
                    this.position.Y + 67
                ),
                isCentralized = true,
                isSelected = true
            };

            txtPassword = new TextBox() {
                maxLength = 26,
                picturePosition = new Vector2(
                    this.position.X + 32,
                    this.position.Y + 106
                ),
                labelPosition = new Vector2(
                    this.position.X + 28,
                    this.position.Y + 106
                ),
                isCentralized = true,
                isPassword = true
            };

            btnLogin = new LabelButton() {
                caption = "Entrar",
                color = Color.White,
                position = new Vector2(
                    this.position.X + 28,
                    this.position.Y + 165
                ),
            };

            InputSystem.CharEntered += InputSystem_CharEntered;
        }

        public void Load(ContentManager content)
        {
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
            login.Draw(spriteBatch);
            txtLogin.Draw(spriteBatch);
            txtPassword.Draw(spriteBatch);
            btnLogin.Draw(spriteBatch);
        }

        private void InputSystem_CharEntered(object sender, CharacterEventArgs e)
        {
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
        }
    }
}
