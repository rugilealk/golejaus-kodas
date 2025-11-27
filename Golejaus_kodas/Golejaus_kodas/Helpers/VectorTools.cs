using System;
using System.Collections.Generic;
using System.Text;

namespace Golejaus_kodas.Helpers
{
    internal class VectorTools
    {
        public static byte[] nullVector = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public static byte[] getUnitVector(int position, int length)
        {
            if (position < 1 || position > length)
                throw new ArgumentOutOfRangeException(nameof(position), "Position must be between 1 and the length of the vector.");

            byte[] unitVector = new byte[length];
            unitVector[position] = 1;
            return unitVector;
        }

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
                    ++errorCount;
                    pos.Add(i + 1);
                }
            }

            return (errorCount, pos);
        }

        public static int getWeight(byte[] vector)
        {
            if (vector == null)
                throw new ArgumentNullException(nameof(vector), "Cannot calculate weight of a null vector.");

            int weight = 0;
            foreach (byte b in vector)
            {
                if (b == 1)
                    ++weight;
            }
            return weight;
        }

        public static byte[] addTwoVectors(byte[] vectorA, byte[] vectorB)
        {
            if(vectorA == null || vectorB == null)
                throw new ArgumentNullException("Vectors cannot be null.");

            if(vectorA.Length != vectorB.Length)
                throw new ArgumentException("Vectors must be of the same length.");

            byte[] resultVector = new byte[vectorA.Length];

            for(int i=0; i< vectorA.Length; ++i)
                resultVector[i] = (byte)((vectorA[i] + vectorB[i]) % 2);

            return resultVector;

        }
    }
}
