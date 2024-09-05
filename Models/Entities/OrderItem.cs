using Newtonsoft.Json;

namespace KDSOrderManagement.Models.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }

        public int OrderId { get; set; }

        [JsonIgnore]
        public Order Order { get; set; }
    }
}
