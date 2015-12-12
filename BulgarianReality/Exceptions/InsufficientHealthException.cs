namespace BulgarianReality.Exceptions
{
    public class InsufficientHealthException : HumanException
    {
        public InsufficientHealthException(string msg) 
            : base(msg)
        {
        }
    }
}
