using Golejaus_kodas.Channel;
using Golejaus_kodas.GolayCode;
using System;
using System.Collections.Generic;
using System.Text;
using Golejaus_kodas.Helpers;

namespace Golejaus_kodas.ScenarioCode
{
    internal class Scenario2Code
    {
        public static (string withCode, string withoutCode) Scenario2(string inputText, float errorProbability)
        {
            var (messageVectors, paddingCount) = ConvertingTools.stringToByteArrayList(inputText);

            GolayEncoding encoder = new GolayEncoding();
            GolayDecoding decoder = new GolayDecoding();

            ChannelWithError channelWithoutCode = new ChannelWithError();
            channelWithoutCode.setErrorProbability(errorProbability);

            ChannelWithError channelWithCode = new ChannelWithError();
            channelWithCode.setErrorProbability(errorProbability);

            List<byte[]> receivedWithoutCode = new List<byte[]>();
            foreach (var message in messageVectors)
            {
                byte[] received = channelWithoutCode.SendThroughChannel(message);
                receivedWithoutCode.Add(received);
            }

            string textWithoutCode = ConvertingTools.byteArrayListToString(receivedWithoutCode, paddingCount);

            List<byte[]> decodedVectors = new List<byte[]>();
            foreach (var message in messageVectors)
            {
                byte[] encoded = encoder.encodeVector(message);
                byte[] received = channelWithCode.SendThroughChannel(encoded);
                byte[] decoded = decoder.decode(received);
                decodedVectors.Add(decoded);
            }
            string textWithCode = ConvertingTools.byteArrayListToString(decodedVectors, paddingCount);

            return (textWithCode, textWithoutCode);
        }
    }
}
