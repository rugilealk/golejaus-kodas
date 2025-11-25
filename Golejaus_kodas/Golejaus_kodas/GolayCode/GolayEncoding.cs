using System;
using System.Collections.Generic;
using System.Text;
using Golejaus_kodas.Helpers;

namespace Golejaus_kodas.GolayCode
{
    internal class GolayEncoding
    {
        public byte[,] matrixB = new Matrices().G;
        public MatrixArithmetic matrixArithmetic = new MatrixArithmetic();
        public byte[] encodeVector(byte[] inputVector)
        {
            if (inputVector.Length != 12)
                throw new ArgumentException("Input vector must be of length 12.");

            return matrixArithmetic.multiplyVectorMatrix(inputVector, matrixB);
        }
    }
}
