namespace WireGram
{
    internal static class Utils
    {
        public static bool IsWindows => Environment.OSVersion.Platform <= PlatformID.WinCE;

        public static void CreateIfNotExistsDirectory(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }
    }
}
