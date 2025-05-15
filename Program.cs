using Serilog;

namespace WireGram
{
    public class Program
    {
        private static void InitLogger()
        {
            var ver = typeof(Program).Assembly.GetName().Version!.ToString(2);
            Log.Logger = new LoggerConfiguration()
                .Enrich.WithProperty("Version", ver)
                .WriteTo.Console(outputTemplate: Constants.LoggerFormat)
                .WriteTo.File("/var/log/wiregram.log", outputTemplate: Constants.LoggerFormat)
                .CreateLogger();
        }

        static void Main(string[] args)
        {
            CreateIfNotExistsDirectory(Path.GetDirectoryName(Constants.PeersPath)!);
            InitLogger();
            Configuration.Load();
            Peer.Load();
            var bot = new Bot();
        }
    }
}