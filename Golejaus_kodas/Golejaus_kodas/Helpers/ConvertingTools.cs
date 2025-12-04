using Golejaus_kodas.Channel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Golejaus_kodas.Helpers
{
    internal class ConvertingTools
    {
        public static (List<byte[]>, int padding) stringToGolayByteArray(string input)
        {
            if(input == null)
                throw new ArgumentNullException(nameof(input), "Input string cannot be null.");

            byte[] infoBytes = Encoding.UTF8.GetBytes(input);
            return bitArrayToGolayBytes(infoBytes);
        }

        public static string golayByteArrayToString(List<byte[]> vectors, int paddingCount)
        {
            List<byte> infoBytes = golayByteArrayToInfoBitArray(vectors, paddingCount);
            string infoString = Encoding.UTF8.GetString(infoBytes.ToArray());
            return infoString;
        }
        public static (List<byte[]>, int) bitArrayToGolayBytes(byte[] infoBytes)
        {
            List<byte> allBits = new List<byte>();
            foreach (byte b in infoBytes)
            { 
                for (int bit = 7; bit >= 0; --bit) 
                    allBits.Add((byte)((b >> bit) & 1));
            }

            int totalBits = allBits.Count;
            int paddingCount = (12 - (totalBits % 12)) % 12;

            List<byte[]> messageVectors = new List<byte[]>();
            int totalVectorsNeeded = (totalBits + paddingCount + 11) / 12;

            for (int v = 0; v < totalVectorsNeeded; ++v)
            {
                byte[] message = new byte[12];
                for (int j = 0; j < 12; ++j)
                {
                    int bitIndex = v * 12 + j;
                    if (bitIndex < allBits.Count)
                        message[j] = allBits[bitIndex];
                    else
                        message[j] = (byte)0;
                }
                messageVectors.Add(message);
            }

            return (messageVectors, paddingCount);
        }

        public static List<byte> golayByteArrayToInfoBitArray(List<byte[]> vectors, int paddingCount)
        {
            List<byte> allBits = new List<byte>();

            foreach (var vector in vectors)
                allBits.AddRange(vector);
            

            int totalBits = allBits.Count - paddingCount;

            List<byte> infoBytes = new List<byte>();

            for (int i = 0; i < totalBits; i += 8)
            {
                byte b = 0; //utf8 byte
                for (int j = 0; j < 8 && i + j < totalBits; ++j)
                    b |= (byte)(allBits[i + j] << (7 - j));

                infoBytes.Add(b);
            }

            return infoBytes;
        }

        
    }
}
