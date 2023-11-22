namespace PlaygroundWebApp.Helpers
{    public static class StringExtensions
    {
        public static string FirstCharSubstring(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            return $"{input[0].ToString().ToUpper()}{input.Substring(1)}";
        }
    }
}
