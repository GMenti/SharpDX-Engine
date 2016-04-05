using SharpDXEngine.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SharpDXEngine.Utilities;
using SharpDXEngine.Utilities.Helpers;
using SharpDXEngine.Frames.Menu.Login;
using SharpDXEngine.Frames.Menu.Register;

namespace SharpDXEngine.Frames.Menu
{
    class Menu
    {
        private AnimPicture background;
        private Picture logo;

        public static TypePanel actualPanel;
        public static LoginPanel loginPanel;
        private RegisterPanel registerPanel;

        public Menu()
        {
            background = new AnimPicture();

            logo = new Picture() {
                position = new Vector2(
                    NumberHelper.getCenterX(Config.GAME_WIDTH, 500), 
                    60
                )
            };

            actualPanel = TypePanel.Login;
            loginPanel = new LoginPanel();
            registerPanel = new RegisterPanel();
        }

        public void Load(ContentManager content)
        {
            Song song = content.Load<Song>("Intro2");
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;

            background.Load(content, "GUI/Menu/palletTown");
            background.spriteOrigin.X = NumberHelper.getRandom(0, background.texture.Width - Config.GAME_WIDTH);
            background.spriteOrigin.Y = NumberHelper.getRandom(0, background.texture.Height - Config.GAME_HEIGHT);

            logo.Load(content, "GUI/logo");

            loginPanel.Load(content);
            registerPanel.Load(content);
        }

        public void Update(GameTime gameTime)
        {
            background.Update(gameTime);

            switch (actualPanel) {
                case TypePanel.Login:
                    loginPanel.Update(gameTime);
                    break;

                case TypePanel.Register:
                    registerPanel.Update(gameTime);
                    break;
            }
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);
            logo.Draw(spriteBatch);

            switch (actualPanel) {
                case TypePanel.Login:
                    loginPanel.Draw(spriteBatch);
                    break;

                case TypePanel.Register:
                    registerPanel.Draw(spriteBatch);
                    break;
            }
        }
    }
}
