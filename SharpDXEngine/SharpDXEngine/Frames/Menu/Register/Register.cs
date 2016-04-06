using GameLibrary.Components;
using GameLibrary.Helpers;
using Microsoft.Xna.Framework;
using SharpDXEngine.Utilities;

namespace SharpDXEngine.Frames.Menu
{
    static partial class Register
    {
        private static Vector2 position;
        static public Label lblStatus;

        public static void Initialize()
        {
            Register.position = new Vector2(NumberHelper.getCenterX(Config.GAME_WIDTH, 276), 300);

            picRegister = new Picture() {
                position = Register.position
            };

            Register.txtLogin = new TextBox() {
                maxLength = 26,
                picturePosition = new Vector2(
                    Register.position.X + 28,
                    Register.position.Y + 67
                ),
                labelPosition = new Vector2(
                    Register.position.X + 32,
                    Register.position.Y + 67
                ),
                isCentralized = true,
                isSelected = true
            };

            Register.txtPassword = new TextBox() {
                maxLength = 26,
                picturePosition = new Vector2(
                    Register.position.X + 28,
                    Register.position.Y + 106
                ),
                labelPosition = new Vector2(
                    Register.position.X + 32,
                    Register.position.Y + 106
                ),
                isCentralized = true,
                isPassword = true
            };

            Register.btnBack = new LabelButton() {
                caption = "Voltar",
                color = Color.White,
                position = new Vector2(
                    Register.position.X + 10,
                    Register.position.Y + 165
                )
            };

            Register.btnConfirme = new LabelButton() {
                caption = "Confirmar",
                color = Color.White,
                position = new Vector2(
                    Register.position.X + 208,
                    Register.position.Y + 165
                )
            };

            Register.lblStatus = new Label() {
                caption = "",
                color = Color.White,
                position = new Vector2(
                    Register.position.X + 58,
                    Register.position.Y + 135
                )
            };

            InputSystem.CharEntered += InputSystem_CharEntered;
        }

        

        private static void InputSystem_CharEntered(object sender, CharacterEventArgs e)
        {
            if (e.Character != '\t') {
                return;
            }

            if (Register.txtLogin.isSelected) {
                Register.txtLogin.isSelected = false;
                Register.txtPassword.isSelected = true;
            } else {
                Register.txtLogin.isSelected = true;
                Register.txtPassword.isSelected = false;
            }
        }
    }
}
