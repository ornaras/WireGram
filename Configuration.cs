namespace WireGram;

internal static class Configuration
{
    public static string Token { get; private set; } = "";

    public static long AdminId { get; private set; }

    public static void Load()
    {
        Token = Get("BOT_TOKEN");
        AdminId = int.Parse(Get("ADMIN_ID"));
    }

    private static string Get(string variable) =>
        Environment.GetEnvironmentVariable(variable) ??
            throw new ArgumentNullException($"Env.{variable}");
}
