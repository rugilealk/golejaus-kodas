namespace Golejaus_kodas.Validation
{
    /// <summary>
    /// Klasė, atsakinga už įvesties duomenų validaciją.
    /// </summary>
    internal class InputValidation
    {
        /// <summary>
        /// Patikrina, ar vartotojo įvesta klaidos tikimybė yra tinkama (reikšmė tarp 0 ir 1).
        /// </summary>
        /// <param name="errorProbability"> Įvesta tikimybė</param>
        /// <returns> 
        /// Kortežą su:
        /// - boolean reikšme, kuri nurodo, ar tikimybė yra tinkama
        /// - klaidos pranešimu, jei tikimybė netinkama
        /// </returns>
        public (bool isValid, string errorMessage) isProbabilityValid(string errorProbability)
        {
            if (float.TryParse(errorProbability, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out float probability))
            {
                if (!(probability >= 0 && probability <= 1))
                    return (false, "Error: probability should be between 0 and 1.");

                else
                    return (true, string.Empty);
            }

            else
                return (false, "Error: probability should be a real number between 0 and 1.");
        }

        /// <summary>
        /// Patikrina, ar vartotojo įvestas vektorius yra tinkamas Golėjaus kodavimui (12 bitų, tik 0 ir 1).
        /// </summary>
        /// <param name="inputVector"> Įvestas vektorius.</param>
        /// <returns>
        /// Kortežą su:
        /// - boolean reikšme, kuri nurodo, ar vektorius yra tinkamas
        /// - klaidos pranešimu, jei vektorius netinkamas
        /// </returns>
        public (bool isValid, string errorMessage) isVectorValid(string inputVector)
        {
            if (inputVector == null || inputVector.Length == 0)
                return (false, "Error: vector cannot be null or empty.");
            
            if (inputVector.Length != 12)
                return (false, "Error: vector should be of size 12, not longer or shorter");

            foreach(char b in inputVector)
            {
                if (b != '0' && b != '1')
                    return (false, "Error: vector should only contain 0 and 1.");
            }

            return (true, string.Empty);
        }

        /// <summary>
        /// Patikrina, ar vartotojo įvestas vektorius yra tinkamas Golėjaus dekodavimui (23 bitų, tik su 0 ir 1).
        /// </summary>
        /// <param name="inputVector"> Įvestas vektorius</param>
        /// <returns>
        /// Kortežą su:
        /// - boolean reikšme, kuri nurodo, ar vektorius yra tinkamas
        /// - klaidos pranešimu, jei vektorius netinkamas
        /// </returns>
        public (bool isValid, string errorMessage) isEncodedVectorValid(string inputVector)
        {
            if (inputVector == null || inputVector.Length == 0)
                return (false, "Error: vector cannot be null or empty.");

            if (inputVector.Length != 23)
                return (false, "Error: vector should be of size 23, not longer or shorter");

            foreach (char b in inputVector)
            {
                if (b != '0' && b != '1')
                    return (false, "Error: vector should only contain 0 and 1.");
            }

            return (true, string.Empty);
        }

    }
}
