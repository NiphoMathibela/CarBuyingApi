namespace CarBuyingApi.Models
{
    public class CarsForSaleDbSettings
    {
        public string ConnectionSring { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string CarsCollectionName { get; set; } = null!;
    }
}
