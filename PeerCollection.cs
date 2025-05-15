using CsvHelper;
using System.Globalization;

namespace WireGram
{
    internal partial class Peer
    {
        private static List<Peer> _peers = [];

        public static void Load()
        {
            if (!File.Exists(Constants.PeersPath)) return;
            using var fs = new StreamReader(Constants.PeersPath);
            using var csv = new CsvReader(fs, CultureInfo.InvariantCulture);
            _peers = [.. csv.GetRecords<Peer>()];
        }

        public static Peer[] Get(long userId) =>
            [.. _peers.Where(p => userId == p.UserId)];

        public static Peer[] Get(DateOnly expaired) =>
            [.. _peers.Where(p => expaired == p.Expaired)];

        public static Peer? Get(string publicKey) =>
            _peers.FirstOrDefault(p => p.PublicKey == publicKey);

        public static void Add(Peer peer)
        {
            _peers.Add(peer);
            WriteToFile();
        }

        private static void WriteToFile()
        {
            if (!File.Exists(Constants.PeersPath))
                File.Create(Constants.PeersPath);
            using var fs = new StreamWriter(Constants.PeersPath);
            using var csv = new CsvWriter(fs, CultureInfo.InvariantCulture);
            csv.WriteRecords(_peers);
        }

        public static string[] PublicKeys =>
            [.. _peers.Select(p => p.PublicKey)];
    }
}
