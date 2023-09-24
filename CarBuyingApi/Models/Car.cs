using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarBuyingApi.Models
{
    public class Car
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string CarName { get; set; } = null!;

        public string Brand { get; set; } = null!;

        public string Model { get; set; } = null!;

        public string Colour { get; set; } = null!;

        public string BodyType {  get; set; } = null!;

        public decimal Price { get; set; }

        public int Mileage {  get; set; }

        public string GearType { get; set; } = null!;

        public string FuelType { get; set; } = null!;

        public string Engine { get; set; } = null!;

        public string EngineSize { get; set; } = null!;

        public string Power { get; set; } = null!;

        public decimal FuelCons {  get; set; }

        public int Seats { get; set; }

        public int Year {  get; set; }

        public string Location { get; set; } = null!;

        public string Drive {  get; set; } = null!;

        public string SellerType {  get; set; } = null!;

        public string VehicleType {  get; set; } = null!;

    }
}
