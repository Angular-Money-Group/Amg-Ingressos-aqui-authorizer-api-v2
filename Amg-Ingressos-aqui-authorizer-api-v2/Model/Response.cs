namespace Amg_Ingressos_aqui_authorizer_api_v2.Model
{
    public class Response
    {
        public Response()
        {
            Message = string.Empty;
            Data = string.Empty;
        }

        /// <summary>
        /// Mensagem de retorno
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Objeto de dados retornado
        /// </summary>
        public object Data { get; set; }
    }
}