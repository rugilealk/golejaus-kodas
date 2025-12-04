namespace Golejaus_kodas.Helpers
{
    internal class MatrixArithmetic
    {
        public static byte[] multiplyVectorMatrix(byte[] vector, byte[,] matrix)
        {
            if(vector == null)
                throw new ArgumentNullException(nameof(vector), "Vector cannot be null.");

            if(matrix == null)
                throw new ArgumentNullException(nameof(matrix), "Matrix cannot be null.");

            if (vector.Length != matrix.GetLength(0))
                throw new ArgumentException("Vector length must match the number of matrix rows.");

            byte[] product = new byte[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(1); ++i) //stulpeliu skaicius
            {
                for (int j = 0; j < matrix.GetLength(0); ++j) //eiluciu skaicius
                    product[i] = (byte)((vector[j] * matrix[j, i] + product[i]) % 2);

            }

            return product;
        }

        public static byte[] getMatrixRow(int number, byte[,] matrix)
        {
            if (number < 0 || number >= matrix.GetLength(0))
                throw new ArgumentOutOfRangeException(nameof(number), "Row number must be between 1 and the number of matrix rows.");

            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix), "Matrix cannot be null.");

            byte[] row = new byte[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(1); ++i)
                row[i] = matrix[number, i];

            return row;
        }
    }
}
