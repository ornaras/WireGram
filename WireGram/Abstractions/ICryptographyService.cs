namespace WireGram.Abstractions
{
    internal interface ICryptographyService
    {
        string Encrypt(string raw);
        string Decrypt(string encrypted);
    }
}
