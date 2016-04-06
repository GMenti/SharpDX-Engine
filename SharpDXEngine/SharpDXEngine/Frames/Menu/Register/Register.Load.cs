using Microsoft.Xna.Framework.Content;

namespace SharpDXEngine.Frames.Menu
{
    static partial class Register
    {
        public static void Load(ContentManager content)
        {
            Register.picRegister.Load(content, "GUI/Menu/login");

            Register.txtLogin.Load(
                content,
                "GUI/Menu/textbox",
                "Fonts/Georgia"
            );

            Register.txtPassword.Load(
                content,
                "GUI/Menu/textbox",
                "Fonts/Georgia"
            );

            Register.btnBack.Load(content, "Fonts/Georgia");
            Register.btnConfirme.Load(content, "Fonts/Georgia");

            Register.lblStatus.Load(content, "Fonts/Georgia");
        }
    }
}
