namespace WireGram.DataBase
{
    internal class Peer
    {
        public string PublicKey { get; set; }
        public long UserId { get; set; }
        public DateOnly Expaired { get; set; }

        public static Peer[] Get(long userId)
        {
            return [];
        }

        public static Peer[] Get(DateOnly expaired)
        {
            return [];
        }

        public static Peer Get(string publicKey)
        {
            return null!;
        }

        public static void Add(Peer peer)
        {

        }

        public static string[] PublicKeys { get; }
    }
}
