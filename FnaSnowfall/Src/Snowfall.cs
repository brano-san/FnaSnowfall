using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FnaSnowfall
{
    /// <summary>
    /// Основной класс приложения
    /// </summary>
    public class Snowfall : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Texture2D backgroundTexture;

        private SnowflakeContainer snowflakeHelper;

        private const int SnowflakeCount = 1000;

        private int screenWidth;
        private int screenHeight;

        private MouseState prevMouseState;

        public Snowfall()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            prevMouseState = Mouse.GetState();

            spriteBatch = new SpriteBatch(GraphicsDevice);

            backgroundTexture = Content.Load<Texture2D>("background");

            Texture2D snowflakeTexture = Content.Load<Texture2D>("snow");
            snowflakeHelper = new SnowflakeContainer(snowflakeTexture);

            for (var i = 0; i < SnowflakeCount; i++)
            {
                snowflakeHelper.AddSnowflake(
                    new Vector2(RandomHelper.NextFloat(0, screenWidth), RandomHelper.NextFloat(-screenHeight, 0)),
                    RandomHelper.NextFloat(50, 150),
                    RandomHelper.NextFloat(0.01f, 0.01f),
                    screenWidth, screenHeight
                );
            }
        }

        protected override void Update(GameTime gameTime)
        {
            var currentMouseState = Mouse.GetState();
            if (prevMouseState != currentMouseState ||
                Keyboard.GetState().GetPressedKeys().Length > 0)
            {
                Exit();
            }

            snowflakeHelper.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
            snowflakeHelper.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
