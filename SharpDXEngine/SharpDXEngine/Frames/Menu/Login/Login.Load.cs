using Microsoft.Xna.Framework.Content;

namespace SharpDXEngine.Frames.Menu
{
    static partial class Login
    {
        public static void Load(ContentManager content)
        {
            Login.login.Load(content, "GUI/Menu/login");

            Login.txtLogin.Load(
                content,
                "GUI/Menu/textbox",
                "Fonts/Georgia"
            );

            Login.txtPassword.Load(
                content,
                "GUI/Menu/textbox",
                "Fonts/Georgia"
            );

            Login.btnLogin.Load(content, "Fonts/Georgia");
            Login.btnRegister.Load(content, "Fonts/Georgia");

            Login.lblStatus.Load(content, "Fonts/Georgia");
        }
    }
}
