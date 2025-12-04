namespace Golejaus_kodas.Validation
{
    internal class InputValidation
    {
        public (bool isValid, string errorMessage) isProbabilityValid(string errorProbability)
        {
            if (float.TryParse(errorProbability, out float probability))
            {
                if (!(probability >= 0 && probability <= 1))
                    return (false, "Error: probability should be between 0 and 1.");

                else
                    return (true, string.Empty);
            }

            else
                return (false, "Error: probability should be a real number between 0 and 1.");
        }

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

        public (bool isValid, string errorMessage) fileExists(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
                return (false, "Error: file does not exist.");
            return (true, string.Empty);
        }
    }
}
