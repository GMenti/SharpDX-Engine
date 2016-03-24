using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameClient.Controllers
{
    class Cursor
    {
        private Texture2D normTexture;
        private Texture2D clickTexture;
        private Texture2D activeTexture;
        private Vector2 position;

        public Cursor()
        {
            //TODO
        }

        public void Load(ContentManager content)
        {
            this.normTexture = content.Load<Texture2D>("Cursors/norm");
            this.clickTexture = content.Load<Texture2D>("Cursors/click");
        }

        public void Update()
        {
            MouseState mouseState = Mouse.GetState();
            this.position = new Vector2(mouseState.X, mouseState.Y);

            if (mouseState.LeftButton == ButtonState.Pressed) {
                this.activeTexture = this.clickTexture;
                return;
            } 

            this.activeTexture = this.normTexture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                this.activeTexture, 
                this.position, 
                Color.White
            );
        }

        
        
    }
}
