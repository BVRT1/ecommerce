using System;
using System.Runtime.Serialization;

namespace ecommerce.Lib.Exceptions
{
    public class CannotBuyWhenBalanceNotSufficient : Exception
    {
        public CannotBuyWhenBalanceNotSufficient()
        {
        }

        public CannotBuyWhenBalanceNotSufficient(string message) : base(message)
        {
        }

        public CannotBuyWhenBalanceNotSufficient(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CannotBuyWhenBalanceNotSufficient(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}