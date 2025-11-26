using System;
using System.Collections.Generic;
using System.Text;

namespace Golejaus_kodas.Helpers
{
    internal class VectorToString
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
    }
}
