namespace Amg_Ingressos_aqui_authorizer_api_v2.Infra
{
    public class AuthDatabaseSettings
    {
        /// <summary>
        /// Connection string base de dados Mongo
        /// </summary>
        public string ConnectionString { get; set; } = null!;
        /// <summary>
        /// Nome base de dados Mongo
        /// </summary>
        public string DatabaseName { get; set; } = null!;
        /// <summary>
        /// Nome collection Mongo
        /// </summary>
        public string EventCollectionName { get; set; } = null!;
    }
}