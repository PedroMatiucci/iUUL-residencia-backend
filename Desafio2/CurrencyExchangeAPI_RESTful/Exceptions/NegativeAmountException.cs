using System.Runtime.Serialization;

namespace CurrencyExchangeAPI_RESTful.Exceptions
{
    [Serializable]
    internal class NegativeAmountException : MyCurrencyExchangeAPIException
    {
        public NegativeAmountException()
        {
        }

        public NegativeAmountException(string? message) : base(message)
        {
        }

        public NegativeAmountException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NegativeAmountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}