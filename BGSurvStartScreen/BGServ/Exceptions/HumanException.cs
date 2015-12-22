using System;

namespace BulgarianReality.Exceptions
{
    public abstract class HumanException : ApplicationException
    {
        protected HumanException(string msg)
            : base(msg)
        {
        }
    }
}
