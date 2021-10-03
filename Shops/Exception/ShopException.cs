using System;

namespace Shops.Exception
{
    public class ShopException : System.Exception
    {
        public ShopException()
        {
        }

        public ShopException(string message)
            : base(message)
        {
        }

        public ShopException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }
    }
}