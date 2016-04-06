using Microsoft.Xna.Framework;

namespace SharpDXEngine.Frames.Menu
{
    static partial class Register
    {
        public static void Update(GameTime gameTime)
        {
            Register.txtLogin.Update(gameTime);
            Register.txtPassword.Update(gameTime);
            Register.btnBack.Update(gameTime);
            Register.btnConfirme.Update(gameTime);

            if (Register.btnConfirme.isSubmited == true) {
                MenuController.Register(txtLogin.text, txtPassword._text);
                Register.btnConfirme.isSubmited = false;
            }

            if (Register.btnBack.isSubmited == true) {
                Menu.actualPanel = TypePanel.Login;
                Register.btnBack.isSubmited = false;
                Register.Hide();
                Login.Show();
            }
        }
    }
}
