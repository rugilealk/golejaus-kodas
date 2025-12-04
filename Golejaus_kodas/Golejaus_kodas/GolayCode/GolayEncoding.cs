using Golejaus_kodas.Helpers;

namespace Golejaus_kodas.GolayCode
{
    /// <summary>
    /// Golėjaus kodo kodavimo klasė.
    /// Paima 12 bitų dvejetainį vektorių ir užkoduoja į 23 bitų kodo žodį,
    /// pridedant 11 patikros bitų klaidų aptikimui ir taisymui.
    /// </summary>
    internal class GolayEncoding
    {
        
        /// <summary>
        /// Generuojanti matrica G (12×23).
        /// </summary>
        public byte[,] matrixG = Matrices.G;

        /// <summary>
        /// Užkoduoja 12 bitų informacinį vektorių į 23 bitų kodo žodį.
        /// Kodavimas atliekamas dauginant įvesties vektorių iš generuojančios 
        /// matricos G.
        /// </summary>
        /// <param name="inputVector">12 bitų dvejetainį informacinį vektorių.</param>
        /// <returns>
        /// 23 bitų užkoduotą dvejetainį vektorių (kodo žodis).
        /// </returns>
        public byte[] encodeVector(byte[] inputVector)
        {
            if(inputVector == null || inputVector.Length == 0)
                throw new ArgumentException("Input vector cannot be null vector.");

            if (inputVector.Length != 12)
                throw new ArgumentException("Input vector must be of length 12.");

            return MatrixArithmetic.multiplyVectorMatrix(inputVector, matrixG);
        }
    }
}
