using KDSOrderManagement.Models.Entities;

namespace KDSOrderManagement.Models
{
    public class OrderDto
    {
        public string CustomerName { get; set; }
        public DateTime OrderTime { get; set; }
        public OrderStatus Status { get; set; }
    }
}
