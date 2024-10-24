﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace FnaSnowfall
{
    /// <summary>
    /// Хранение <see cref="Snowflake"/> в контейнере
    /// </summary>
    public class SnowflakeContainer
    {
        private readonly List<Snowflake> snowflakes;

        private readonly Texture2D snowflakeTexture;

        public SnowflakeContainer(Texture2D texture)
        {
            snowflakes = new List<Snowflake>();
            snowflakeTexture = texture;
        }

        /// <summary>
        /// Добавить <see cref="Snowflake"/> в коллекцию <see cref="snowflakes"/>
        /// </summary>
        public void AddSnowflake(Vector2 position, float speed, float size, int windowWidth, int windowHeight)
        {
            var snowflake = new Snowflake(snowflakeTexture, position, speed, size, windowWidth, windowHeight);
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
