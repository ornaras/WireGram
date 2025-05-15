namespace WireGram
{
    internal static class Utils
    {
        public static void CreateIfNotExistsDirectory(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }
    }
}
