using System.Linq;

namespace SharpMaterialX.Serialization.Utils
{
    internal static class TokenUtils
    {
        /// <summary>
        /// Tokenizes the provided string and verifies if the token count is correct
        /// </summary>
        /// <param name="input">The string to be tokenized</param>
        /// <param name="requiredCount">The required count of tokens to be produced</param>
        /// <param name="tokens">The array of tokens. An array is assigned even if requiredCount doesn't match the amount of tokens.</param>
        /// <returns>True if successfully tokenized and the produced tokens match requiredCount. False otherwise.</returns>
        public static bool TryTokenize(string input, int requiredCount, out string[] tokens)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                tokens = null;
                return false;
            }

            tokens = input.Split(',')
                .Where(s => string.IsNullOrWhiteSpace(s) == false)
                .Select(s => s.Trim())
                .ToArray();

            return tokens.Length == requiredCount;
        }

        public static bool TryTokenize(string input, out string[] tokens)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                tokens = null;
                return false;
            }

            tokens = input.Split(',')
                .Where(s => string.IsNullOrWhiteSpace(s) == false)
                .Select(s => s.Trim())
                .ToArray();

            return tokens.Length > 0;
        }
    }
}
