namespace WireGram.Tests
{
    public class Pricelist
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public void Month()
        {
            var sum = WireGram.Pricelist.Calculate(1);
            Assert.That(sum, Is.EqualTo(70));
        }

        [Test]
        public void Months5()
        {
            var sum = WireGram.Pricelist.Calculate(5);
            Assert.That(sum, Is.EqualTo(5*63));
        }

        [Test]
        public void Months4_13()
        {
            var sum = WireGram.Pricelist.Calculate(4, 13);
            Assert.That(sum, Is.EqualTo(4*63+13*49));
        }
    }
}
