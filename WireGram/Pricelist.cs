using Price = (int Months, double Price);

namespace WireGram
{
    public static class Pricelist
    {
        private readonly static Price[] _items = [
            ( 12, 49 ),
            ( 6, 56 ),
            ( 3, 63 ),
            ( 2, 66.5 ),
            ( 1, 70 ),
        ];

        public static double Calculate(params int[] peers)
        {
            var sum = 0D;
            for (var i = 0; i < peers.Length; i++)
            {
                var months = peers[i];
                double perMonth = 0;
                foreach (var item in _items)
                {
                    if (months < item.Months) continue;
                    perMonth = item.Price;
                    break;
                }
                sum += months * perMonth;
            }
            return sum;
        }
    }
}
