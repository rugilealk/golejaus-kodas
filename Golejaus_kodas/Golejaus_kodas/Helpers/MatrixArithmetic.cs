using System;
using System.Collections.Generic;
using System.Text;

namespace Golejaus_kodas.Helpers
{
    internal class MatrixArithmetic
    {
        public byte[] multiplyVectorMatrix(byte[] vector,  byte[,] matrix)
        {
            if(vector.Length != matrix.GetLength(0))
                throw new ArgumentException("Vector length must match the number of matrix rows.");

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
