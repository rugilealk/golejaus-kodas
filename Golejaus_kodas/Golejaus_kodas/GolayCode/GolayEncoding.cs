using Golejaus_kodas.Helpers;

namespace Golejaus_kodas.GolayCode
{
    internal class GolayEncoding
    {
        public byte[,] matrixB = Matrices.G;
        public byte[] encodeVector(byte[] inputVector)
        {
            if(inputVector == null || inputVector.Length == 0)
                throw new ArgumentException("Input vector cannot be null vector.");

            if (inputVector.Length != 12)
                throw new ArgumentException("Input vector must be of length 12.");

            return MatrixArithmetic.multiplyVectorMatrix(inputVector, matrixB);
        }
    }
}
