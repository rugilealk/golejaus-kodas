using System;
using System.Collections.Generic;
using System.Text;

namespace Golejaus_kodas.Helpers
{
    internal class VectorTools
    {
        public static string convertVectorToString(byte[] vector)
        {
            if (vector == null || vector.Length == 0)
             return string.Empty;

            char[] vectorCharArray = new char[23];
            for (int i = 0; i < vector.Length; ++i)
            {
                vectorCharArray[i] = (char)(vector[i] + '0');
            }

            return new string(vectorCharArray);
        }

        public static (int errorCount, List<int> errorPositions) getErrorInfo(byte[] originalVector, byte[] receivedVector)
        {
            List<int> pos = new List<int>();
            int errorCount = 0;

            if (originalVector == null || receivedVector == null || originalVector.Length != receivedVector.Length)
                return (0, pos);
            
            for(int i=0; i< originalVector.Length; ++i)
            {
                if (originalVector[i] != receivedVector[i])
                {
                    errorCount++;
                    pos.Add(i + 1);
                }
            }

            return (errorCount, pos);
        }

        public int vectorWeight(byte[] vector)
        {
            int weight = 0;
            foreach (byte b in vector)
            {
                if (b == 1)
                    weight++;
            }
            return weight;
        }
    }
}
