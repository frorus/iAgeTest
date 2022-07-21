namespace iAgeTest.Extensions
{
    /// <summary>
    /// A command parameters parser.
    /// </summary>
    public static class ParametersParser
    {
        /// <summary>
        /// Splits the string by ":".
        /// </summary>
        /// <param name="stringToSplit">A string to split.</param>
        /// <returns>String part after ":".</returns>
        public static string SplitString(string stringToSplit)
        {
            return stringToSplit[(stringToSplit.LastIndexOf(':') + 1)..];
        }
    }
}