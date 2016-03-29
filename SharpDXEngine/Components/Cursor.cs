using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SharpDXEngine.Components {
    class Cursor
    {
        private Texture2D normTexture;
        private Texture2D clickTexture;
        private Texture2D activeTexture;
        private Vector2 position;
        private Label label;

        public Cursor()
        {
            this.label = new Label() {
                color = Color.Yellow,
                position = new Vector2(5, 20)
            };
        }

        public void Load(ContentManager content)
        {
            this.label.Load(content, "Fonts/Georgia");
            this.normTexture = content.Load<Texture2D>("Cursors/norm");
            this.clickTexture = content.Load<Texture2D>("Cursors/click");
        }

        public void Update()
        {
            MouseState mouseState = Mouse.GetState();
            this.position = new Vector2(mouseState.X, mouseState.Y);
            this.label.caption = "Mouse: " + mouseState.X + ", " + mouseState.Y;

            if (mouseState.LeftButton == ButtonState.Pressed) {
                this.activeTexture = this.clickTexture;
                return;
            } 

            this.activeTexture = this.normTexture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.label.Draw(spriteBatch);
            spriteBatch.Draw(
                this.activeTexture, 
                this.position, 
                Color.White
            );
        }

        
        
    }
}
