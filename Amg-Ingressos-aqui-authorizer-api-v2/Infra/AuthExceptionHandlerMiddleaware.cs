using System.Net;
using Amg_Ingressos_aqui_authorizer_api_v2.Exceptions;
using Amg_Ingressos_aqui_authorizer_api_v2.Model;
using Newtonsoft.Json;

namespace Amg_Ingressos_aqui_authorizer_api_v2.Infra
{
    public class AuthExceptionHandlerMiddleaware : AbstractExceptionHandlerMiddleware
    {
        public AuthExceptionHandlerMiddleaware(
            ILogger<AuthExceptionHandlerMiddleaware>logger,
            RequestDelegate next) : base(logger,next)
        {

        }

        public override (HttpStatusCode code, string message) GetResponse(Exception exception)
        {
            HttpStatusCode code;
            switch (exception)
            {
                case GetException:
                    code = HttpStatusCode.NotFound;
                    break;
                case IdMongoException:
                    code = HttpStatusCode.Conflict;
                    break;
                case UnauthorizedAccessException:
                    code = HttpStatusCode.Unauthorized;
                    break;
                case RuleException
                    or DeleteException
                    or EditException
                    or IdMongoException
                    or ArgumentException
                    or InvalidOperationException:
                    code = HttpStatusCode.BadRequest;
                    break;
                default:
                    code = HttpStatusCode.InternalServerError;
                    break;
            }
            return (code, JsonConvert.SerializeObject(new MessageReturn(){Message=exception.Message}));
        }
    }
}