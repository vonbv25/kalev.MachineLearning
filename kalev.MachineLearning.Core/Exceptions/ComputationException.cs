using System;

namespace kalev.MachineLearning.Core.Exceptions
{
    internal class ComputationException : Exception
    {
        public ComputationException()
        {
        }

        public ComputationException(string message) : base(message)
        {
        }

        public ComputationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}