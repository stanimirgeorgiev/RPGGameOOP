using System;


namespace BGServ.Exceptions
{
   public class NoTilesException : Exception
    {
        public NoTilesException()
        {
        }

        public NoTilesException(string message)
            : base(message)
        {
        }

        public NoTilesException(string message, Exception ex)
            : base(message, ex)
        {
        }
    }
}
