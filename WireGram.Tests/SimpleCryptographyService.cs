using Bogus;

namespace WireGram.Tests
{
    internal class SimpleCryptographyService
    {
        [Test]
        public void Main()
        {
            var service = new Storage.SimpleCryptographyService(new Faker().Random.Hash());
            for(var _ = 0; _ < 1000; _++)
            {
                var text = new Faker().Name.FullName();
                var encrypted = service.Encrypt(text);
                var decrypted = service.Decrypt(encrypted);
                Assert.That(text, Is.Not.EqualTo(encrypted));
                Assert.That(text, Is.EqualTo(decrypted));
            }
        }
    }
}
