using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Golejaus_kodas.Channel
{
    public class Channel
    {
        private Random randomNumberGenerator = GlobalRandomiser.RandomGenerator;
        private float errorProbability;

        public Channel(float errorProbability)
        {
            if (errorProbability < 0 || errorProbability > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(errorProbability), "Error probability must be between 0 and 1.");
            }
            this.errorProbability = errorProbability;
        }

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
