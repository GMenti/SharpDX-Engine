using GameLibrary.Components;
using GameLibrary.Helpers;
using Microsoft.Xna.Framework;
using SharpDXEngine.Utilities;

namespace SharpDXEngine.Frames.Menu
{
    static partial class Login
    {
        private static Vector2 position;
        static public Label lblStatus;

        public static void Initialize()
        {
            Login.position = new Vector2(NumberHelper.getCenterX(Config.GAME_WIDTH, 276), 300);

            login = new Picture() {
                position = Login.position
            };

            txtLogin = new TextBox() {
                maxLength = 26,
                picturePosition = new Vector2(
                    Login.position.X + 28,
                    Login.position.Y + 67
                ),
                labelPosition = new Vector2(
                    Login.position.X + 32,
                    Login.position.Y + 67
                ),
                isCentralized = true,
                isSelected = true
            };

            txtPassword = new TextBox() {
                maxLength = 26,
                picturePosition = new Vector2(
                    Login.position.X + 28,
                    Login.position.Y + 106
                ),
                labelPosition = new Vector2(
                    Login.position.X + 32,
                    Login.position.Y + 106
                ),
                isCentralized = true,
                isPassword = true
            };

            btnLogin = new LabelButton() {
                caption = "Entrar",
                color = Color.White,
                position = new Vector2(
                    Login.position.X + 10,
                    Login.position.Y + 165
                )
            };

            btnRegister = new LabelButton() {
                caption = "Registrar",
                color = Color.White,
                position = new Vector2(
                    Login.position.X + 208,
                    Login.position.Y + 165
                )
            };

            lblStatus = new Label() {
                caption = "",
                color = Color.White,
                position = new Vector2(
                    Login.position.X + 58,
                    Login.position.Y + 135
                )
            };

            InputSystem.CharEntered += InputSystem_CharEntered;
        }

        

        private static void InputSystem_CharEntered(object sender, CharacterEventArgs e)
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
