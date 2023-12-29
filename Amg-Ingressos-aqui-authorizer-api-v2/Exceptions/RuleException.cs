namespace Amg_Ingressos_aqui_authorizer_api_v2.Exceptions
{
    public class RuleException : Exception
    {
        public RuleException()
        {
        }

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}