namespace AgendaMongoDB
{
    public static class StringExtensions
    {
        public static string Corregir(this string str)
        {
            return str.Trim().Replace("\"", "").Replace("\\", "");
        }
    }
}
