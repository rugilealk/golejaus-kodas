using Golejaus_kodas.Channel;
using Golejaus_kodas.GolayCode;
using Golejaus_kodas.Helpers;

namespace Golejaus_kodas.ScenarioCode
{
    internal class Scenario3Code
    {
        /// <summary>
        /// Simuliuoja BMP formato paveikslėlio perdavima per klaidinga kanalą su ir be Golėjaus kodo.
        /// </summary>
        /// <param name="fileBytes"> Viso paveikslėlio informacija (baitais)</param>
        /// <param name="errorProbability"> Klaidos tikimybė</param>
        /// <returns>
        /// Kortežą su:
        /// - Paveikslėlio baitais, perduotais per klaidingą kanalą su Golėjaus kodu
        /// - Paveikslėlio baitais, perduotais per klaidingą kanalą be Golėjaus kodo
        /// </returns>
        public static (byte[] withCodeBytes, byte[] withoutCodeBytes) Scenario3(byte[] fileBytes, float errorProbability)
        {
            int pixelOffset = BitConverter.ToInt32(fileBytes, 10);

            byte[] headerBytes = new byte[pixelOffset];
            byte[] pixelBytes = new byte[fileBytes.Length - pixelOffset];

            Array.Copy(fileBytes, 0, headerBytes, 0, pixelOffset);
            Array.Copy(fileBytes, pixelOffset, pixelBytes, 0, pixelBytes.Length);

            (List<byte[]> messageVectors, int paddingCount) = ConvertingTools.bitArrayToGolayBytes(pixelBytes);

            GolayEncoding encoder = new GolayEncoding();
            GolayDecoding decoder = new GolayDecoding();

            ChannelWithError channelWithoutCode = new ChannelWithError();
            channelWithoutCode.setErrorProbability(errorProbability);

            ChannelWithError channelWithCode = new ChannelWithError();
            channelWithCode.setErrorProbability(errorProbability);

            // Paveikslėlio be Golėjaus kodu perdavimas per klaidingą kanalą
            List<byte[]> receivedWithoutCode = new List<byte[]>();
            foreach (var message in messageVectors)
            {
                byte[] received = channelWithoutCode.SendThroughChannel(message);
                receivedWithoutCode.Add(received);
            }

            // Konvertavimas atgal i BMP formato paveikslėlį iš gautų vektorių (be kodavimo)
            List<byte> withoutCodeList = ConvertingTools.golayByteArrayToInfoBitArray(receivedWithoutCode, paddingCount);
            byte[] withoutCodeBytes = withoutCodeList.ToArray();
            byte[] withoutCodeBmpBytes = new byte[headerBytes.Length + withoutCodeBytes.Length];
            Array.Copy(headerBytes, 0, withoutCodeBmpBytes, 0, headerBytes.Length);
            Array.Copy(withoutCodeBytes, 0, withoutCodeBmpBytes, headerBytes.Length, withoutCodeBytes.Length);

            // Paveikslėlio su Golėjaus kodu perdavimas per klaidingą kanalą
            List<byte[]> decodedVectors = new List<byte[]>();
            foreach (var message in messageVectors)
            {
                byte[] encoded = encoder.encodeVector(message);
                byte[] received = channelWithCode.SendThroughChannel(encoded);
                byte[] decoded = decoder.decode(received);
                decodedVectors.Add(decoded);
            }

            // Konvertavimas atgal i BMP formato paveikslėlį iš gautų vektorių (su kodavimu)
            List<byte> withCodeList = ConvertingTools.golayByteArrayToInfoBitArray(decodedVectors, paddingCount);
            byte[] withCodeBytes = withCodeList.ToArray();
            byte[] withCodeBmpBytes = new byte[headerBytes.Length + withCodeBytes.Length];
            Array.Copy(headerBytes, 0, withCodeBmpBytes, 0, headerBytes.Length);
            Array.Copy(withCodeBytes, 0, withCodeBmpBytes, headerBytes.Length, withCodeBytes.Length);

            return (withCodeBmpBytes, withoutCodeBmpBytes);
        }
    }
}
