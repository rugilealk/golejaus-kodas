using System;
using System.Collections.Generic;
using System.Text;

namespace Golejaus_kodas.Helpers
{
    internal class MatrixOperations
    {
        public byte[] multiplyVectorMatrix(byte[] vector,  byte[,] matrix)
        {
            byte[] product = new byte[matrix.GetLength(1)];
            for (int i =0; i< matrix.GetLength(1); ++i) //stulpeliu skaicius
            {
                for (int j = 0; j < matrix.GetLength(0); ++j) //eiluciu skaicius
                    product[i] = (byte)((vector[j] * matrix[j, i] + product[i])%2);

            }

            return product;
        }

    }
}
