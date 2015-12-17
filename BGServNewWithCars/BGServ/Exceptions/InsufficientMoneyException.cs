namespace BulgarianReality.Exceptions
{
    public class InsufficientMoneyException : HumanException
    {
        public InsufficientMoneyException(string msg) 
            : base(msg)
        {
        }
    }
}
