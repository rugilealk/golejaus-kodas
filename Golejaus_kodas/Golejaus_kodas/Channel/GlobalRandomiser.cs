namespace Golejaus_kodas.Channel
{
    internal class GlobalRandomiser
    {
        /// <summary>
        /// Statinis atsitiktinių skaičių generatorius, inicializuojamas tik vieną kartą
        /// programos paleidimo metu.
        /// </summary>
        public static readonly Random RandomGenerator = new Random();
    }
}
