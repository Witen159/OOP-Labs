using System;

namespace Isu.Tools
{
    public class IsuException : Exception
    {
        public IsuException()
        {
            //first commit
        }

        public IsuException(string message) : base(message)
        {
        }

        public IsuException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}