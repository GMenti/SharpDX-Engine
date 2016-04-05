using GameLibrary.Components;
using GameLibrary.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDXEngine.Utilities;

namespace SharpDXEngine.Frames.Menu.Register
{
    class RegisterPanel
    {
        private Picture login;
        private TextBox txtLogin;
        private TextBox txtPassword;
        private LabelButton btnBack;
        private LabelButton btnRegister;
        private Vector2 position;

        static public Label lblStatus;

        public RegisterPanel()
        {
            this.position = new Vector2(NumberHelper.getCenterX(Config.GAME_WIDTH, 276), 300);

            login = new Picture() {
                position = this.position
            };

            login.position.X += 200;

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
                    this.position.X + 28,
                    this.position.Y + 106
                ),
                labelPosition = new Vector2(
                    this.position.X + 32,
                    this.position.Y + 106
                ),
                isCentralized = true,
                isPassword = true
            };

            btnBack = new LabelButton() {
                caption = "Voltar",
                color = Color.White,
                position = new Vector2(
                    this.position.X + 10,
                    this.position.Y + 165
                )
            };

            btnRegister = new LabelButton() {
                caption = "Confirmar",
                color = Color.White,
                position = new Vector2(
                    this.position.X + 208,
                    this.position.Y + 165
                )
            };

            lblStatus = new Label() {
                caption = "",
                color = Color.White,
                position = new Vector2(
                    this.position.X + 58,
                    this.position.Y + 135
                )
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

            btnBack.Load(content, "Fonts/Georgia");
            btnRegister.Load(content, "Fonts/Georgia");

            lblStatus.Load(content, "Fonts/Georgia");
        }

        public void Update(GameTime gameTime)
        {
            txtLogin.Update(gameTime);
            txtPassword.Update(gameTime);
            btnBack.Update(gameTime);
            btnRegister.Update(gameTime);

            if (btnRegister.isSubmited == true) {
                //this.Login(txtLogin.text, txtPassword._text);
                btnRegister.isSubmited = false;
            }

            if (btnBack.isSubmited == true) {
                btnBack.isSubmited = false;
                Menu.actualPanel = TypePanel.Login;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            login.Draw(spriteBatch);
            txtLogin.Draw(spriteBatch);
            txtPassword.Draw(spriteBatch);
            btnBack.Draw(spriteBatch);
            btnRegister.Draw(spriteBatch);
            lblStatus.Draw(spriteBatch);
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
