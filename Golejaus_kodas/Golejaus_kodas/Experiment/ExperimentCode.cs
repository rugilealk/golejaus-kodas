using Golejaus_kodas.Channel;
using Golejaus_kodas.GolayCode;
using Golejaus_kodas.Helpers;

namespace Golejaus_kodas.Experiment
{
    internal class ExperimentCode
    {
        /// <summary>
        /// Atlieka eksperimentą: siunčia nulinį vektorių su Golėjaus kodu ir apskaičiuoja v
        /// vidutinį klaidų kiekį klaidų tikimybei didėjant.
        /// </summary>
        /// <returns>
        /// Kortežą su dviem masyvais:
        /// - errorProbability: klaidos tikimybių masyvas (100 reikšmių nuo 0.01 iki 1.00)
        /// - averageErrorPercentage: vidutinis klaidų procentas su kiekviena tikimybe (100 reikšmių)
        /// </returns>
        public static (float[] errorProbability, float[] averageErrorPercentage) experimentWithEncoding()
        {
            float[] errorProbability = new float[100];
            float[] averageErrorPercentage = new float[100];
            byte[] originalVector = VectorTools.nullVector;
            GolayDecoding decoder = new GolayDecoding();
            GolayEncoding encoder = new GolayEncoding();
            byte[] encodedVector = encoder.encodeVector(originalVector);

            for (int i=0; i<100; ++i)
            {
                errorProbability[i] = (float)(i * 0.01);
                ChannelWithError channel = new ChannelWithError();
                channel.setErrorProbability((float)errorProbability[i]);
                int totalErrorCount = 0;
                for (int j=0; j<100; ++j)
                {
                    byte[] receivedVector = channel.SendThroughChannel(encodedVector);
                    byte[] decodedVector = decoder.decode(receivedVector);
                    totalErrorCount += VectorTools.getErrorInfo(originalVector, decodedVector).errorCount;
                }
                averageErrorPercentage[i] = (float)totalErrorCount / (originalVector.Length * 100) * 100f;
            }
            return (errorProbability, averageErrorPercentage);
        }
        /// <summary>
        /// Atlieka eksperimentą: siunčia nulinį vektorių be Golėjaus kodo ir apskaičiuoja vidutinį klaidų kiekį,
        /// klaidų tikimybei didėjant.
        /// </summary>
        /// <returns>
        /// Kortežą su dviem masyvais:
        /// - errorProbability: klaidos tikimybių masyvas (100 reikšmių nuo 0.01 iki 1.00)
        /// - averageErrorPercentage: vidutinis klaidų procentas su kiekviena tikimybe (100 reikšmių)
        /// </returns>
        public static (float[] errorProbability, float[] averageErrorPercentage) experimentWithoutEncoding()
        {
            float[] errorProbability = new float[100];
            float[] averageErrorPercentage = new float[100];
            byte[] vector = VectorTools.nullVector;

            for (int i = 0; i < 100; ++i)
            {
                errorProbability[i] = (float)(i * 0.01);
                ChannelWithError channel = new ChannelWithError();
                channel.setErrorProbability((float)errorProbability[i]);
                int totalErrorCount = 0;
                for (int j = 0; j < 100; ++j)
                {
                    byte[] receivedVector = channel.SendThroughChannel(vector);
                    totalErrorCount += VectorTools.getErrorInfo(vector, receivedVector).errorCount;
                }
                averageErrorPercentage[i] = (float)totalErrorCount / (vector.Length * 100) * 100f;
            }
            return (errorProbability, averageErrorPercentage);
        }

        /// <summary>
        /// Išsaugo eksperimento rezultatus į failą dviejų skaičių po kablelio tikslumu.
        /// </summary>
        /// <param name="errorProbability">Klaidos tikimybių masyvas.</param>
        /// <param name="averageErrorPercentage">Klaidų procentų masyvas.</param>
        /// <param name="filename">Failo pavadinimas, į kurį bus saugomi rezultatai.</param>
        public static void writeToFile(float[] errorProbability, float[] averageErrorPercentage, string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine("Error_Probability,Average_Error_Percentage");

                for (int i = 0; i < errorProbability.Length; i++)
                {
                    writer.WriteLine($"{errorProbability[i]:F2},{averageErrorPercentage[i]:F2}");
                }
            }
        }

        /// <summary>
        /// Funkcija, kuri labai supaprastina visų eksperimento rezultatų spausdinimą į failą (kad nereikėtų kviesti šių funkcijų atskirai)
        /// </summary>
        public static void writeAll()
        {
            (float[] errorProbabilityEncoded, float[] averageErrorPercentageEncoded) = experimentWithEncoding();
            (float[] errorProbability, float[] averageErrorPercentage) = experimentWithoutEncoding();
            writeToFile(errorProbabilityEncoded, averageErrorPercentageEncoded, "withCode.txt");
            writeToFile(errorProbability, averageErrorPercentage, "withoutCode.txt");
        }

    }
}
