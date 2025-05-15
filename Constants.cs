namespace WireGram;

internal static class Constants
{
    public const string LoggerFormat = "[{Timestamp:yyyy-MM-ddTHH:mm:ss.fff(zzz)} {Version}] {Level:u3} {Message:lj}{NewLine}{Exception}";
    public static string PeersPath = Path.Combine(IsWindows ? 
        Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) : 
        "/etc", "wiregram", "peers.csv");
    public static string LogPath = Path.Combine(IsWindows ?
        Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) :
        "/var", "log", "wiregram.log");
}
