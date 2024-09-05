using System.Runtime.Serialization;

namespace KDSOrderManagement.Models.Enums
{
    public enum OrderStatus
    {
        Pending = 1,
        InProgress = 2,
        Completed = 3,
        Cancelled = 4
    }
}
