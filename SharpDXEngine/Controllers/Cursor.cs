using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameClient.Controllers
{
    class Cursor
    {
        public Texture2D normTexture { get; set;}
        public Texture2D clickTexture { get; set; }
        public Texture2D texture;
        public Vector2 position { get; set; }

        public void Update()
        {
            MouseState mouseState = Mouse.GetState();
            this.position = new Vector2(mouseState.X, mouseState.Y);

            if (Mouse.GetState().LeftButton == ButtonState.Pressed) {
                this.texture = this.clickTexture;
                return;
            } 

            this.texture = this.normTexture;
        }

        public void Draw()
        {
            MainGame.spriteBatch.Draw(
                this.texture, 
                this.position, 
                Color.White
            );
        }

        public void Load()
        {
            this.normTexture = MainGame.engineContent.Load<Texture2D>("Cursors/norm");
            this.clickTexture = MainGame.engineContent.Load<Texture2D>("Cursors/click");
        }
        
    }
}
