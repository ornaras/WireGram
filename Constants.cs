namespace WireGram;

internal static class Constants
{
    public const string LoggerFormat = "[{Timestamp:yyyy-MM-ddTHH:mm:ss.fff(zzz)} {Version}] {Level:u3} {Message:lj}{NewLine}{Exception}";
    public static string PeersPath = "/etc/wiregram/peers.csv";
    public const string LogPath = "/var/log/wiregram.log";
}
