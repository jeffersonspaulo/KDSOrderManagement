using KDSOrderManagement.Models.Enums;
using Newtonsoft.Json;

namespace KDSOrderManagement.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderTime { get; set; }
        public OrderStatus Status { get; set; }

        public List<OrderItem> Items { get; set; }
    }
}
