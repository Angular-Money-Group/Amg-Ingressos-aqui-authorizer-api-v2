namespace Amg_Ingressos_aqui_authorizer_api_v2.Exceptions
{
    public class GetException : Exception
    {
        public GetException()
        {
        }

        public GetException(string message) : base(message)
        {
        }

        public GetException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}