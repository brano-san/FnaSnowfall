using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FnaSnowfall
{
    /// <summary>
    /// Описание снежинки
    /// </summary>
    public class Snowflake
    {
        /// <summary>
        /// Позиция снежинки на экране <see cref="Texture"/>
        /// </summary>
        public Vector2 Position;

        /// <summary>
        /// Скорость падения снежинки <see cref="Texture"/>
        /// </summary>
        public float Speed;

        /// <summary>
        /// Размер снежинки <see cref="Texture"/>
        /// </summary>
        public float Size;

        private readonly Texture2D texture;

        private readonly int windowWidth;
        private readonly int windowHeight;

        public Snowflake(Texture2D texture, Vector2 position, float speed, float size, int windowWidth, int windowHeight)
        {
            this.texture = texture;
            Position = position;
            Speed = speed;
            Size = size;
            this.windowWidth = windowWidth;
            this.windowHeight = windowHeight;
        }

        /// <summary>
        /// Обновить положение <see cref="Texture"/>
        /// </summary>`
        public void Update(GameTime gameTime)
        {
            Position.Y += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (Position.Y > windowWidth)
            {
                Position.Y = -texture.Height;
                Position.X = RandomHelper.NextFloat(0, windowHeight);
            }
        }

        /// <summary>
        /// Отрисовать <see cref="Texture"/> на экране
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, null, Color.White, 0f, Vector2.Zero, Size, SpriteEffects.None, 0f);
        }
    }

}
