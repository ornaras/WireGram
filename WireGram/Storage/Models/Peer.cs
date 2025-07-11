using WireGram.Attributes;

namespace WireGram.Storage.Models
{
    internal sealed class Peer
    {
        public int Id { get; set; }
        public required string PublicKey { get; set; }
        [Encrypted] public required string TelegramId { get; set; }
        [Encrypted] public required string Address { get; set; }
        [Encrypted] public required string PrivateKey { get; set; }
    }
}
