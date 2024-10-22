using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace FnaSnowfall
{
    public class SnowflakeHelper
    {
        private readonly List<Snowflake> snowflakes;

        private readonly Texture2D snowflakeTexture;

        public SnowflakeHelper(Texture2D texture)
        {
            snowflakes = new List<Snowflake>();
            snowflakeTexture = texture;
        }

        /// <summary>
        /// Добавить <see cref="Snowflake"/> в коллекцию <see cref="snowflakes"/>
        /// </summary>
        public void AddSnowflake(Vector2 position, float speed, float size, int windowWidth, int windowHeight)
        {
            Snowflake snowflake = new Snowflake(snowflakeTexture, position, speed, size, windowWidth, windowHeight);
            snowflakes.Add(snowflake);
        }

        /// <summary>
        /// Обновить все <see cref="Snowflake"/> в коллекции <see cref="snowflakes"/>
        /// </summary>
        public void Update(GameTime gameTime)
        {
            foreach (var snowflake in snowflakes)
            {
                snowflake.Update(gameTime);
            }
        }

        /// <summary>
        /// Отрисовать все <see cref="Snowflake"/> в коллекции <see cref="snowflakes"/>
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var snowflake in snowflakes)
            {
                snowflake.Draw(spriteBatch);
            }
        }
    }
}
