namespace iAgeTest.Extensions
{
    public static class ParametersParser
    {
        public static string SplitString(string stringToSplit)
        {
            return stringToSplit[(stringToSplit.LastIndexOf(':') + 1)..];
        }
    }
}