using System;
using System.Collections.Generic;
namespace Golejaus_kodas.Channel
{
    /// <summary>
    /// Dvejetainis simetrinis kanalas su klaidos tikimybe, nurodyta vartotojo.
    /// Kiekvienas siunčiamas bitas gali būti iškraipomas su nustatyta tikimybe,
    /// nepriklausomai nuo kitų bitų.
    /// </summary>
    public class ChannelWithError
    {
        private Random randomNumberGenerator = GlobalRandomiser.RandomGenerator; //ar gerai cia? nes kol kas tik vienam vektoriui sukurtas kanalas
        private float errorProbability;

        /// <summary>
        /// Nustato kanalo klaidos tikimybę.
        /// </summary>
        /// <param name="errorProbability">
        /// Klaidos tikimybė, kurios reikšmė yra intervale [0, 1].
        /// </param>
        public void setErrorProbability(float errorProbability)
        {
            if (errorProbability < 0 || errorProbability > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(errorProbability), "Error probability must be between 0 and 1.");
            }
            this.errorProbability = errorProbability;
        }


        /// <summary>
        /// Siunčia duomenis per kanalą su klaidomis.
        /// </summary>
        /// <param name="data">
        /// Siunčiamas duomenų masyvas, kur kiekvienas elementas yra 0 arba 1.
        /// </param>
        /// <returns>
        /// Gautas duomenų masyvas po siuntimo per kanalą, su galimomis klaidomis.
        /// </returns>
        public byte[] SendThroughChannel(byte[] data)
        {
            byte[] result = new byte[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                if (randomNumberGenerator.NextDouble() < errorProbability)
                    result[i] = (byte)(data[i] ^ 1);

                else
                    result[i] = data[i];
            }
            return result;
        }
    }
}
