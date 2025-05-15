namespace WireGram
{
    internal partial class Peer(string publicKey, long userId, DateOnly? expaired)
    {
        public string PublicKey
        {
            get => _publicKey;
            set
            {
                if (value == _publicKey) 
                    return;
                _publicKey = value;
                WriteToFile();
            }
        }
        public long UserId
        {
            get => _userId;
            set
            {
                if (value == _userId) 
                    return;
                _userId = value;
                WriteToFile();
            }
        }
        public DateOnly? Expaired
        {
            get => _expaired;
            set
            {
                if (value == _expaired)
                    return;
                _expaired = value;
                WriteToFile();
            }
        }

        private string _publicKey = publicKey;
        private long _userId = userId;
        private DateOnly? _expaired = expaired;
    }
}
