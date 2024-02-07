namespace CarBuyingApi.Models
{
    public class CarsForSaleDbSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string CarsCollectionName { get; set; } = null!;

        public string UserCollectionName { get; set; } = null!;
    }
}
