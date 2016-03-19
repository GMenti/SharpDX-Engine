using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GameClient.Utilities;
using GameClient.Components;
using GameClient.Controllers;
using SharpDXEngine.Frames;
using System;

namespace GameClient
{

    public class MainGame : Game
    {
        public static SpriteBatch spriteBatch;
        public static ContentManager engineContent;
        public static TimeSpan totalTime;

        GraphicsDeviceManager graphics;

        private Menu menu;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);

            engineContent = Content;
            engineContent.RootDirectory = "Content";

            this.menu = new Menu();
        }

        /// <summary>
        /// Executa qualquer inicialização necessária antes de começar a rodar
        /// </summary> 
        protected override void Initialize()
        {
            InputSystem.Initialize(this.Window);
  
            menu.Initialize();
            base.Initialize();
        }

        /// <summary>
        /// Carrega todo o conteúdo do jogo (Chamado ao iniciar a aplicação)
        /// </summary> 
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            menu.Load();
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
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            menu.Update();

            FPS.Update();
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
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            menu.Draw();
            FPS.Draw();
            spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
