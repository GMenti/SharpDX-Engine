using SharpDXEngine.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SharpDXEngine.Utilities;
using SharpDXEngine.Utilities.Helpers;
using SharpDXEngine.Frames.Menu.Login;

namespace SharpDXEngine.Frames.Menu
{
    class Menu
    {
        private AnimPicture background;
        private Picture logo;
        private LoginPanel loginPanel;

        public Menu()
        {
            background = new AnimPicture();

            logo = new Picture() {
                position = new Vector2(
                    NumberHelper.getCenterX(Config.GAME_WIDTH, 500), 
                    60
                )
            };

            loginPanel = new LoginPanel();
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
        }

        public void Update(GameTime gameTime)
        {
            background.Update(gameTime);
            loginPanel.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);
            logo.Draw(spriteBatch);
            loginPanel.Draw(spriteBatch);
        }
    }
}
