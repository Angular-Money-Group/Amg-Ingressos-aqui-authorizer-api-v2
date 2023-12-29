namespace Amg_Ingressos_aqui_authorizer_api_v2.Exceptions
{
    public class DeleteException : Exception
    {
        public DeleteException()
        {
        }

        public DeleteException(string message) : base(message)
        {
        }

        public DeleteException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}