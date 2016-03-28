using Microsoft.Xna.Framework;
using SharpDXEngine.Libraries;

namespace SharpDXEngine.Components
{
    class LabelButton : Label
    {
        private bool hover;
        private bool click;

        public bool isSubmited;

        public LabelButton(string text, Color color, Vector2 position) : base(text, color, position)
        {
            InputSystem.MouseMove += InputSystem_MouseMove;
            InputSystem.MouseDown += InputSystem_MouseDown;
            InputSystem.MouseUp += InputSystem_MouseUp;
        }

        public new void Update(GameTime gameTime)
        {
            if (this.click == true) {
                this.color = new Color(200, 200, 200, 255);
                return;
            }

            if (this.hover == true) {
                this.color = new Color(230, 230, 230, 255);
                return;
            }

            this.color = Color.White;    
        }

        private void InputSystem_MouseMove(object sender, MouseEventArgs e)
        {
            this.hover = this.GetStringRectangle().Contains(e.Location);
        }

        private void InputSystem_MouseDown(object sender, MouseEventArgs e)
        {
            this.click = (e.Button == MouseButton.Left && this.hover);
        }

        private void InputSystem_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.click == false) { 
                return;
            }

            this.click = false;
            this.isSubmited = true;
        }

    }
}
