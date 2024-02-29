namespace MyJetWallet.PhazeIo.Client
{
    public class PhazeIoException : Exception
    {
        public PhazeIoException()
        {
        }

        public PhazeIoException(string message) : base(message)
        {
        }

        public PhazeIoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}