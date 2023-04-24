namespace ProjMB23042023.Config
{
    public interface IProjMongoDotnetDatabaseSettings
    {
        string ClientCollectionName { get; set; }
        string AddressCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
