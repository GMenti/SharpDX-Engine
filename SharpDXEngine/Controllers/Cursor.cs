using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameClient.Controllers
{
    class Cursor
    {
        public Texture2D texture { get; set;}
        public Vector2 position { get; set; }

        public void Update()
        {
            MouseState mouseState = Mouse.GetState();
            this.position = new Vector2(mouseState.X, mouseState.Y);
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
            this.texture = MainGame.engineContent.Load<Texture2D>("Cursors/Default");
        }
        
    }
}
