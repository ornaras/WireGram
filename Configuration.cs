namespace WireGram;

internal static class Configuration
{
    public static string Token = 
        Environment.GetEnvironmentVariable("BOT_TOKEN") ?? 
        throw new ArgumentNullException("Env.BOT_TOKEN");

    public static long AdminId = int.Parse(_adminId ?? "");
    private readonly static string _adminId = 
        Environment.GetEnvironmentVariable("ADMIN_ID") ??
        throw new ArgumentNullException("Env.ADMIN_ID");
}
