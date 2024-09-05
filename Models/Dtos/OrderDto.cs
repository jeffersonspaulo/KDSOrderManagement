using KDSOrderManagement.Models.Enums;

namespace KDSOrderManagement.Models.Dtos
{
    public class OrderDto
    {
        public string CustomerName { get; set; }
        public DateTime OrderTime { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
    }
}
