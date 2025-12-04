using Golejaus_kodas.Helpers;


namespace Golejaus_kodas.GolayCode
{
    internal class GolayDecoding
    {
        private byte[,] matrixH = Matrices.H;
        private byte[,] matrixB = Matrices.B;

        /// <summary>
        /// Dekoduoja 23 bitų gautą kodo žodį atgal į 12 bitų žodį.
        /// </summary>
        /// <param name="vector">
        /// 23 bitų gautas vektorius iš kanalo.
        /// </param>
        /// <returns>
        /// 12 bitų dekoduotas informacinis žodis.
        /// </returns>
        public byte[] decode(byte[] vector)
        {
            if(vector==null)
                throw new ArgumentException("Cannot decode null vector.");

            if(vector.Length!=23)
                throw new ArgumentException("Vector should be of length 23.");

            byte[] longerVector = new byte[vector.Length +1];
            for (int i = 0; i < vector.Length; ++i)
                longerVector[i] = vector[i];

            // 1. Pridedame dar vieną koordinatę, kad vektoriaus svoris būtų nelyginis
            if (VectorTools.getWeight(vector) % 2 == 0)
                longerVector[vector.Length] = 1;
            else
                longerVector[vector.Length] = 0;

            // 2. Gauname klaidos vektorių
            byte[] errorVector = getErrorVector(longerVector);

            // 3. Pridedame klaidos vektorių prie gauto vektoriaus, kad gautume dekoduotą žodį
            byte[] decodedVector = VectorTools.addTwoVectors(longerVector, errorVector);

            // 4. Imame pirmas 12 koordinates, kurios ir yra dekoduotas žodis
            byte[] word = new byte[12];
            for (int i = 0; i < 12; ++i)
                word[i] = decodedVector[i];

            return word;
        }

        /// <summary>
        /// Randa klaidų vektorių pagal 3.6.1 algoritmo žingsnius.
        /// </summary>
        /// <param name="vector">
        /// 24 bitų vektorius.
        /// </param>
        /// <returns>
        /// 24 bitų klaidų vektorių arba null, jei klaidų vektoriaus rasti nepavyko.
        /// </returns>
        private byte[] getErrorVector(byte[] vector) // cis su 24 ilgio
        {
            // 1. Skaičiuojame sindromą
            byte[] sindrome = calculateSindrome(vector, matrixH);
            if(sindrome == null)
                throw new ArgumentException("Sindrome calculation failed.");

            // 2. Jei sindromo svoris mažesnis arba lygus 3, tai galime sukonstruoti klaidos vektorių
            if (VectorTools.getWeight(sindrome) <= 3)
                return constructErrorVector(sindrome, VectorTools.nullVector);

            else
            {
                // Jei sindromo svoris didesnis nei 3, tai:
                // 3. Pridedame kiekvieną B matricos eilutę prie sindromo
                //    Jei randame eilutę, kurios pridėjimas prie sindromo duoda vektorių, kurio svoris mažesnis arba lygus 2, tai galime sukonstruoti klaidos vektorių
                (byte[] row1, int number1) = findMatrixBRow(sindrome);
                if (row1 != null)
                    return constructErrorVector(VectorTools.addTwoVectors(sindrome, row1), VectorTools.getUnitVector(number1, 12));

                else
                {
                    // 4. Apskaičiuojame antrasis sindromas sB
                    byte[] sindromeB = calculateSindrome(sindrome, matrixB);

                    // 5. Jei sindromo sB svoris mažesnis arba lygus 3, tai galime sukonstruoti klaidos vektorių
                    if (VectorTools.getWeight(sindromeB) <= 3)
                        return constructErrorVector(VectorTools.nullVector, sindromeB);

                    else
                    {
                        // Jei sindromo sB svoris didesnis nei 3, tai:
                        // 6. Pridedame kiekvieną B matricos eilutę prie sindromo sB
                        //    Jei randame eilutę, kurios pridėjimas prie sindromo sB duoda vektorių, kurio svoris mažesnis arba lygus 2, tai galime sukonstruoti klaidos vektorių
                        (byte[] row2, int number2) = findMatrixBRow(sindromeB);
                        if (row2 != null)
                            return constructErrorVector(VectorTools.getUnitVector(number2, 12), VectorTools.addTwoVectors(sindromeB, row2));
                        else
                            return null; // 7. Jei nerandame, tada prašome vektorių atsiųsti iš naujo
                    }
                }
            }

        }


        /// <summary>
        /// Apskaičiuoja sindromą - daugina vektorių su matrica.
        /// </summary>
        /// <param name="vector">Vektorius, kuriam skaičiuojamas sindromas.</param>
        /// <param name="matrix">Matrica su kuria dauginama.</param>
        /// <returns>Gautą sindromą</returns>

        private byte[] calculateSindrome(byte[] vector, byte[,] matrix)
        {
            return MatrixArithmetic.multiplyVectorMatrix(vector, matrix);
        }

        /// <summary>
        /// Sukonstruoja 24 bitų klaidų vektorių iš dviejų 12 bitų vektorių.
        /// </summary>
        /// <param name="vector1">12 bitų vektorius (nulinis arba vienetinis) arba sindromas</param>
        /// <param name="vector2">12 bitų vektorius (nulinis arba vienetinis) arba sindromas</param>
        /// <returns>24 bitų klaidų vektorių.</returns>

        private byte[] constructErrorVector(byte[] vector1, byte[] vector2) //reikia nulinio vektorio, vienetinio vektoriaus
        {
            byte[] errorVector = new byte[24];
            for(int i=0; i< vector1.Length; ++i)
                errorVector[i] = vector1[i];

            for(int i=0; i< vector2.Length; ++i)
                errorVector[i + vector1.Length] = vector2[i];
            
            return errorVector;
        }

        /// <summary>
        /// Ieško matricos B eilutės, kuri pridėta prie sindromo duotų
        /// rezultatą su svoriu ≤ 2.
        /// </summary>
        /// <param name="sindrome">Sindromas, prie kurio bandoma pridėti B eilutes.</param>
        /// <returns>
        /// Kortežą su:
        /// - rasta eilute
        /// - eilutės numeriu
        /// - arba (null, 0), jei nerasta.
        /// </returns>
        private (byte[], int) findMatrixBRow(byte[] sindrome)
        {
            
            if (sindrome == null)
                throw new ArgumentException("Sindrome cannot be null.");

            int rowNumber = 0;
            byte[] row = new byte[sindrome.Length];
            int i = 0;
            bool rowNotFound = true;
            // Tikriname visas matricos B eilutes
            while (rowNotFound)
            {
                // Jei peržiūrėtos visos eilutės - nerasta
                if (i == matrixB.GetLength(0))
                    break;

                row = MatrixArithmetic.getMatrixRow(i, matrixB);
                byte[] additionResult = new byte[sindrome.Length];
                additionResult = VectorTools.addTwoVectors(row, sindrome);
                if (VectorTools.getWeight(additionResult) <= 2)
                {
                    rowNumber = i;
                    rowNotFound = false;
                }
                ++i;
            }

            if (rowNotFound)
                return (null, 0);

            return (row, rowNumber);
        }
    }
}
