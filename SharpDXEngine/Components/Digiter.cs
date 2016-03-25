using SharpDXEngine.Libraries;
using System;

namespace SharpDXEngine.Components {
    class Digiter
    {
        public string text;
 
        public Digiter()
        {
            this.text = "";

            InputSystem.CharEntered += delegate (Object o, CharacterEventArgs e) {
                this.text += e.Character;
            };
        }
    }
}
