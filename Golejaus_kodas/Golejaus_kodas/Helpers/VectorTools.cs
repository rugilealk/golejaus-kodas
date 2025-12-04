using System.Text;

namespace Golejaus_kodas.Helpers
{
    internal class VectorTools
    {
        /// <summary>
        /// Nulinis 12 bitų vektorius.
        /// </summary>
        public static byte[] nullVector = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        /// <summary>
        /// Sukuria vectorių, užpildytą nuliais išskyrus nurodytą poziciją.
        /// Naudojamas Golėjaus dekodavimo algoritme konstruojant klaidų vektorius.
        /// </summary>
        /// <param name="position">Pozicija, kurioje bus vienetas (pradedant nuo 0).</param>
        /// <param name="length">Vektoriaus ilgis.</param>
        /// <returns>Vienetinis vektorius su 1 nurodytoje pozicijoje.</returns
        public static byte[] getUnitVector(int position, int length)
        {
            if (position < 0 || position >= length)
                throw new ArgumentOutOfRangeException(nameof(position), "Position must be between 1 and the length of the vector.");

            byte[] unitVector = new byte[length];
            unitVector[position] = 1;
            return unitVector;
        }
        /// <summary>
        /// Konvertuoja vektorių į tekstinę eilutę.
        /// </summary>
        /// <param name="vector">Vektorius, kurį reikia konvertuoti.</param>
        /// <returns>Tekstinė vektoriaus reprezentacija.</returns>
        public static string convertVectorToString(byte[] vector)
        {
            if (vector == null || vector.Length == 0)
             return string.Empty;

            char[] vectorCharArray = new char[vector.Length];
            for (int i = 0; i < vector.Length; ++i)
            {
                vectorCharArray[i] = (char)(vector[i] + '0');
            }

            return new string(vectorCharArray);
        }

        /// <summary>
        /// Palygina du vektorius(pradinį ir gautą iš kanalo) ir randa klaidų pozicijas bei jų skaičių.
        /// </summary>
        /// <param name="originalVector">Pradinis vektorius.</param>
        /// <param name="receivedVector">Gautas vektorius iš kanalo.</param>
        /// <returns>
        /// Kortežą su:
        /// - bendru klaidų skaičiumi
        /// - klaidų pozicijų sąrašą (su -1 kaip naujos eilutės simbolį kas 10 klaidų)
        /// </returns>
        public static (int errorCount, List<int> errorPositions) getErrorInfo(byte[] originalVector, byte[] receivedVector)
        {
            List<int> pos = new List<int>();
            int errorCount = 0;
            int breakPoint = 10;

            if (originalVector == null || receivedVector == null || originalVector.Length != receivedVector.Length)
                return (0, pos);
            
            for(int i=0; i< originalVector.Length; ++i)
            {
                if (originalVector[i] != receivedVector[i])
                {
                    ++errorCount;
                    ++breakPoint;
                    if (breakPoint > 9)
                    {
                        pos.Add(-1);
                        breakPoint = 0;
                    }
                       
                    pos.Add(i + 1);
                }
            }

            return (errorCount, pos);
        }
        /// <summary>
        /// Grąžina dviejų vektorių lyginimo informaciją su naujos eilutės simboliais patogesniam spausdinimui.
        /// </summary>
        /// <param name="originalVector">Pradinis vektorius.</param>
        /// <param name="receivedVector">Gautas vektorius po siuntimo kanalu.</param>
        /// <returns>
        /// Kortežą su:
        /// - klaidų skaičiumi
        /// - klaidų pozicijomis kaip tekstą.
        /// </returns>
        public static (int errorCount, string errorPositionsString) getErrorInfoString(byte[] originalVector, byte[] receivedVector)
        {
            (int errorCount, List<int> errorPositions) = getErrorInfo(originalVector, receivedVector); 

            if (errorPositions == null || errorPositions.Count == 0)
                return (0, "No errors detected.");

            StringBuilder positionsString = new StringBuilder();
            foreach(int pos in errorPositions)
            {
                if (pos == -1)
                    positionsString.Append("\n");
                
                else
                    positionsString.Append(pos.ToString() + " ");
            }
            return (errorCount, positionsString.ToString().Trim());
        }

        /// <summary>
        /// Apskaičiuoja vektoriaus svorį (vienetų skaičių).
        /// </summary>
        /// <param name="vector">Vektorius, kurio svoris skaičiuojamas.</param>
        /// <returns>Vektoriaus svorį.</returns>
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
        /// <summary>
        /// Sudeda du vektorius.
        /// </summary>
        /// <param name="vectorA">Pirmasis vektorius.</param>
        /// <param name="vectorB">Antrasis vektorius.</param>
        /// <returns>Rezultato vektorius.</returns>
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
