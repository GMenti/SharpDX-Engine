using Microsoft.Xna.Framework;

namespace SharpDXEngine.Frames.Menu
{
    static partial class Login
    {
        public static void Update(GameTime gameTime)
        {
            Login.txtLogin.Update(gameTime);
            Login.txtPassword.Update(gameTime);
            Login.btnLogin.Update(gameTime);
            Login.btnRegister.Update(gameTime);

            if (Login.btnLogin.isSubmited == true) {
                MenuController.Login(txtLogin.text, txtPassword._text);
                Login.btnLogin.isSubmited = false;
            }

            if (Login.btnRegister.isSubmited == true) {
                Menu.actualPanel = TypePanel.Register;
                Login.btnRegister.isSubmited = false;
                Login.Hide();
                Register.Show();
            }
        }
    }
}
