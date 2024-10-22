using System;

namespace FnaSnowfall
{
    /// <summary>
    /// Получения случайного вещественного числа
    /// </summary>
    public static class RandomHelper
    {
        private readonly static Random random = new Random();

        /// <summary>
        /// Получить случайное вещественное число между min и max.
        /// </summary>
        public static float NextFloat(float min, float max)
        {
            return (float)(random.NextDouble() * (max - min) + min);
        }
    }
}
