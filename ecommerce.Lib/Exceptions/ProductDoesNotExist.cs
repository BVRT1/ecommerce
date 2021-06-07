using System;
using System.Runtime.Serialization;

namespace ecommerce.Lib.Exceptions
{
    public class ProductDoesNotExist : Exception
    {
        public ProductDoesNotExist()
        {
        }

        public ProductDoesNotExist(string message) : base(message)
        {
        }

        public ProductDoesNotExist(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ProductDoesNotExist(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}