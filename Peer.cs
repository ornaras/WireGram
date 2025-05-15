namespace WireGram
{
    internal partial class Peer
    {
        public string PublicKey { get; set; } = "";
        public long UserId { get; set; }
        public DateOnly? Expaired { get; set; }
    }
}
