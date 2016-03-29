using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDXEngine.Utilities;
using SharpDXEngine.Components;
using SharpDXEngine.Libraries;
using SharpDXEngine.Frames.Menu;
using System;

namespace SharpDXEngine {

    public class MainGame : Game
    {
        public SpriteBatch spriteBatch;
        public static TimeSpan totalTime;

        GraphicsDeviceManager graphics;

        private Cursor cursor;
        private Menu menu;
        private FPS fpsDrawning;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this) {
                PreferredBackBufferWidth = Config.GAME_WIDTH,
                PreferredBackBufferHeight = Config.GAME_HEIGHT,
                SynchronizeWithVerticalRetrace = true,
                IsFullScreen = false
            };
            graphics.ApplyChanges();
            base.IsFixedTimeStep = false;

            Content.RootDirectory = "Content";

            this.menu = new Menu();
            this.cursor = new Cursor();
            this.fpsDrawning = new FPS() {
                caption = "FPS: 0",
                color = Color.Yellow,
                position = new Vector2(5, 5)
            };
        }

        /// <summary>
        /// Executa qualquer inicialização necessária antes de começar a rodar
        /// </summary> 
        protected override void Initialize()
        {
            InputSystem.Initialize(this.Window);
            base.Initialize();
        }

        /// <summary>
        /// Carrega todo o conteúdo do jogo (Chamado ao iniciar a aplicação)
        /// </summary> 
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            this.menu.Load(this.Content);
            this.cursor.Load(this.Content);
            this.fpsDrawning.Load(this.Content, "Fonts/Georgia");
        }

        /// <summary>
        /// Descarrega todo o conteúdo do jogo (Chamado ao encerrar a aplicação)
        /// </summary> 
        protected override void UnloadContent()
        {
            this.Content.Dispose();
        }

        /// <summary>
        /// Monta a lógicas da aplicação
        /// Roda em média 60 vezes por segundo
        /// </summary> 
        /// <param name="gameTime">Fornece valores de tempo do jogo.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            this.menu.Update(gameTime);
            this.cursor.Update();
            
            base.Update(gameTime);
        }

        /// <summary>
        /// Desenha a parte gráfica da aplicação
        /// Roda em média 60 vezes por segundo
        /// </summary> 
        /// <param name="gameTime">Fornece valores de tempo do jogo.</param>
        protected override void Draw(GameTime gameTime)
        {
            MainGame.totalTime = gameTime.TotalGameTime;
            GraphicsDevice.Clear(Color.Black);
            
            spriteBatch.Begin();
            this.menu.Draw(spriteBatch);
            this.cursor.Draw(spriteBatch);

            this.fpsDrawning.Refresh(gameTime);
            this.fpsDrawning.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
