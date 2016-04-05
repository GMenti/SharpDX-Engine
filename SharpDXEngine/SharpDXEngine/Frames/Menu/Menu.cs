using GameLibrary.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SharpDXEngine.Utilities;
using SharpDXEngine.Frames.Menu.Register;
using GameLibrary.Helpers;

namespace SharpDXEngine.Frames.Menu
{
    class Menu
    {
        private AnimPicture background;
        private Picture logo;

        public static TypePanel actualPanel;

        private RegisterPanel registerPanel;

        public Menu()
        {
            background = new AnimPicture() {
                isVisible = true
            };

            logo = new Picture() {
                position = new Vector2(
                    NumberHelper.getCenterX(Config.GAME_WIDTH, 500), 
                    60
                ),
                isVisible = true
            };

            actualPanel = TypePanel.Login;
            Login.Initialize();

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

            Login.Load(content);
            Login.Show();

            registerPanel.Load(content);
        }

        public void Update(GameTime gameTime)
        {
            background.Update(gameTime);

            switch (actualPanel) {
                case TypePanel.Login:
                    Login.Update(gameTime);
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
                    Login.Draw(spriteBatch);
                    break;

                case TypePanel.Register:
                    registerPanel.Draw(spriteBatch);
                    break;
            }
        }
    }
}
