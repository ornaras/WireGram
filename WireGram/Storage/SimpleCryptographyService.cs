using System.Text;
using WireGram.Abstractions;

namespace WireGram.Storage
{
    public class SimpleCryptographyService(string? salt) : ICryptographyService
    {
        private byte[] Salt { get; init; } = Encoding.ASCII.GetBytes(salt ?? "");
        public string Decrypt(string encrypted)
        {
            var bytes = Convert.FromBase64String(encrypted);
            for (var i = 0; i < bytes.Length; i++)
                bytes[i] ^= (byte)(Salt[i % Salt.Length] ^ 0xFF);
            var raw = Encoding.ASCII.GetString(bytes);
            return raw[..(raw.Length - Salt.Length)];
        }

        public string Encrypt(string raw)
        {
            raw += salt;
            var bytes = Encoding.ASCII.GetBytes(raw);
            for (var i = 0; i < bytes.Length; i++)
                bytes[i] ^= (byte)(Salt[i % Salt.Length] ^ 0xFF);
            return Convert.ToBase64String(bytes);
        }
    }
}
