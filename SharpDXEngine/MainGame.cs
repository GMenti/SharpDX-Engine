using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GameClient.Utilities;
using GameClient.Components;
using GameClient.Controllers;

namespace GameClient
{

    public class MainGame : Game
    {
        public static SpriteBatch spriteBatch;
        public static ContentManager engineContent;

        GraphicsDeviceManager graphics;
        Cursor cursor;
        TextBox textBox;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);

            engineContent = Content;
            engineContent.RootDirectory = "Content";
        }

        /// <summary>
        /// Executa qualquer inicialização necessária antes de começar a rodar
        /// </summary> 
        protected override void Initialize()
        {
            cursor = new Cursor();
            textBox = new TextBox();

            InputSystem.Initialize(this.Window);
            base.Initialize();
        }

        /// <summary>
        /// Carrega todo o conteúdo do jogo (Chamado ao iniciar a aplicação)
        /// </summary> 
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            textBox.Load();
            cursor.Load();
        }

        /// <summary>
        /// Descarrega todo o conteúdo do jogo (Chamado ao encerrar a aplicação)
        /// </summary> 
        protected override void UnloadContent()
        {
            this.Content.Dispose();
            engineContent.Dispose();
        }

        /// <summary>
        /// Monta a lógicas da aplicação
        /// Roda em média 60 vezes por segundo
        /// </summary> 
        /// <param name="gameTime">Fornece valores de tempo do jogo.</param>
        int timer = 0;
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (gameTime.TotalGameTime.Milliseconds > timer + 500) {
                textBox.Update();
                timer = gameTime.TotalGameTime.Milliseconds;
            }

            FPS.Update(gameTime);
            cursor.Update();
            base.Update(gameTime);
        }

        /// <summary>
        /// Desenha a parte gráfica da aplicação
        /// Roda em média 60 vezes por segundo
        /// </summary> 
        /// <param name="gameTime">Fornece valores de tempo do jogo.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            FPS.Draw(gameTime);
            cursor.Draw();
            textBox.Draw();

            spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
