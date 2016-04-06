using Microsoft.Xna.Framework.Graphics;

namespace SharpDXEngine.Frames.Menu
{
    static partial class Register
    {
        public static void Draw(SpriteBatch spriteBatch)
        {
            Register.picRegister.Draw(spriteBatch);
            Register.txtLogin.Draw(spriteBatch);
            Register.txtPassword.Draw(spriteBatch);
            Register.btnBack.Draw(spriteBatch);
            Register.btnConfirme.Draw(spriteBatch);
        }
    }
}
