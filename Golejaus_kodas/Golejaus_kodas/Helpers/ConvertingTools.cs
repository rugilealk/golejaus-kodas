using System.Text;

namespace Golejaus_kodas.Helpers
{
    /// <summary>
    /// Pagalbinė klasė skirta teksto(paveiksliuko) informacijos baitų konvertavimui 
    /// į Golėjaus kodo baitus. 
    /// </summary>
    internal class ConvertingTools
    {
        /// <summary>
        /// Konvertuoja UTF-8 tekstą į Golėjaus kodo vektorių sąrašą (po 12 bitų).
        /// </summary>
        /// <param name="input">Įvesties tekstas UTF-8 formatu.</param>
        /// <returns>
        /// Kortežą su vektorių sąrašu ir papildomų bitų skaičiumi.
        /// </returns>
        public static (List<byte[]>, int padding) stringToGolayByteArray(string input)
        {
            if(input == null)
                throw new ArgumentNullException(nameof(input), "Input string cannot be null.");

            byte[] infoBytes = Encoding.UTF8.GetBytes(input);
            return bitArrayToGolayBytes(infoBytes);
        }


        /// <summary>
        /// Atkuria UTF-8 tekstą iš Golėjaus kodo vektorių sąrašo.
        /// </summary>
        /// <param name="vectors">12 bitų vektorių sąrašas.</param>
        /// <param name="paddingCount">Pridėtų nulinių bitų skaičius paskutiniame vektoriuje.</param>
        /// <returns>Atkurtas UTF-8 tekstas.</returns>
        public static string golayByteArrayToString(List<byte[]> vectors, int paddingCount)
        {
            List<byte> infoBytes = golayByteArrayToInfoBitArray(vectors, paddingCount);
            string infoString = Encoding.UTF8.GetString(infoBytes.ToArray());
            return infoString;
        }

        /// <summary>
        /// Skaido baitų masyvą į 12 bitų vektorius Golėjaus kodavimui.
        /// Kiekvienas baitas išskaidomas į 8 atskirus bitus (0 arba 1) ir užrašomas į atskirą baitą.
        /// Jei bendras bitų skaičius nėra dalus iš 12, pridedami nuliniai bitai.
        /// </summary>
        /// <param name="infoBytes">Informacijos baitų masyvas (pvz., UTF-8 tekstas arba bmp paveiksliuko pikseliai).</param>
        /// <returns>
        /// Kortežas su:
        /// - 12 bitų vektorių sąrašas
        /// - Pridėtų nulinių bitų skaičių paskutiniame vektoriuje.
        /// </returns>
        public static (List<byte[]>messageVectors, int padding) bitArrayToGolayBytes(byte[] infoBytes)
        {
            
            List<byte> allBits = new List<byte>();
            // Išskaidome kiekvieną baitą į atskirus bitus (juos talpiname į atskirus baitus)
            foreach (byte b in infoBytes)
            { 
                for (int bit = 7; bit >= 0; --bit) 
                    allBits.Add((byte)((b >> bit) & 1));
            }

            // Apskaičiuojame, kiek papildomų nulinių bitų reikia pridėti, kad bendras bitų skaičius būtų dalus iš 12
            int totalBits = allBits.Count;
            int paddingCount = (12 - (totalBits % 12)) % 12;

            //Gauname vektorių skaičių
            List<byte[]> messageVectors = new List<byte[]>();
            int totalVectorsNeeded = (totalBits + paddingCount + 11) / 12;

            // Visus 'bitus' talpiname į 12 bitų vektorius
            for (int v = 0; v < totalVectorsNeeded; ++v)
            {
                byte[] message = new byte[12];
                for (int j = 0; j < 12; ++j)
                {
                    // Jei bitų sąraše nėra tiek bitų, pridedame nulinius bitus
                    int bitIndex = v * 12 + j;
                    if (bitIndex < allBits.Count)
                        message[j] = allBits[bitIndex];
                    else
                        message[j] = (byte)0;
                }
                messageVectors.Add(message);
            }

            return (messageVectors, paddingCount);
        }

        /// <summary>
        /// Sujungia 12 baitų vektorių sąrašą atgal į baitų masyvą(kiekvieną baitą užrašo kaip bitą).
        /// Pašalina papildomus nulinius bitus paskutiniame vektoriuje ir sujungia bitus po 8 į baitus.
        /// </summary>
        /// <param name="vectors">12 bitų vektorių sąrašas.</param>
        /// <param name="paddingCount">Kiek bitų reikia pašalinti iš galo.</param>
        /// <returns>Baitų sąrašas (pvz., UTF-8 tekstui arba bmp paveikslėlio duomenims).</returns>
        public static List<byte> golayByteArrayToInfoBitArray(List<byte[]> vectors, int paddingCount)
        {
            List<byte> allBits = new List<byte>();

            // Sujungiame visus vektorius į vieną bitų sąrašą
            foreach (var vector in vectors)
                allBits.AddRange(vector);

            // Pašaliname papildomus nulinius bitus iš galo
            int totalBits = allBits.Count - paddingCount;

            List<byte> infoBytes = new List<byte>();

            // Sujungiame bitus po 8 į baitus (dabar kiekvienas bitas baite turi reikšme, o ne tik paskutinis bitas)
            for (int i = 0; i < totalBits; i += 8)
            {
                byte b = 0; //utf8 byte
                // Pasiskaičiuojame bito vietą ir naudodami or bitų operaciją užpildome atitinkamą bitą
                for (int j = 0; j < 8 && i + j < totalBits; ++j)
                    b |= (byte)(allBits[i + j] << (7 - j));

                infoBytes.Add(b);
            }

            return infoBytes;
        }

        
    }
}
