using System;


namespace BGServ.Exceptions
{
   public class NoBuildingsException : Exception
    {
        public NoBuildingsException()
        {
        }

        public NoBuildingsException(string message)
            : base(message)
        {
        }

        public NoBuildingsException(string message, Exception ex)
            : base(message, ex)
        {
        }
    }
}
