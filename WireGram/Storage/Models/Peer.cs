namespace WireGram.Storage.Models
{
    internal sealed class Peer
    {
        public int Id { get; set; }
        public required string PublicKey { get; set; }
        public required string TelegramId { get; set; }
        public required string Address { get; set; }
        public required string PrivateKey { get; set; }
    }
}
