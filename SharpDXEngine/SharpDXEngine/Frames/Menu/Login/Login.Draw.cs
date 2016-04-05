using Microsoft.Xna.Framework.Graphics;

namespace SharpDXEngine.Frames.Menu
{
    static partial class Login
    {
        public static void Draw(SpriteBatch spriteBatch)
        {
            Login.login.Draw(spriteBatch);
            Login.txtLogin.Draw(spriteBatch);
            Login.txtPassword.Draw(spriteBatch);
            Login.btnLogin.Draw(spriteBatch);
            Login.btnRegister.Draw(spriteBatch);
            Login.lblStatus.Draw(spriteBatch);
        }
    }
}
