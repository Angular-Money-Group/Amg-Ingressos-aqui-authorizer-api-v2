using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amg_Ingressos_aqui_authorizer_api_v2.Exceptions;

namespace Amg_Ingressos_aqui_authorizer_api_v2.Utils
{
    public static class ExtensionMethods
    {
        public static void ValidateIdMongo(this string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new IdMongoException("Id é obrigatório");
            else if (id.Length < 24)
                throw new IdMongoException("Id é obrigatório e está menor que 24 digitos");
        }
    }
}