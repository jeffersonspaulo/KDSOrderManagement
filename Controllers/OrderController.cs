using KDSOrderManagement.Models;
using KDSOrderManagement.Models.Entities;
using KDSOrderManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KDSOrderManagement.Controllers
{
    [Route("orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IOrderItemService _orderItemService;

        public OrderController(IOrderService orderService, IOrderItemService orderItemService)
        {
            _orderService = orderService;
            _orderItemService = orderItemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var orders = await _orderService.GetAllAsync();

            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _orderService.GetByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder([FromBody] OrderDto orderDto)
        {
            var createdOrder = await _orderService.CreateAsync(orderDto);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] OrderDto orderDto)
        {
            await _orderService.UpdateAsync(id, orderDto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _orderService.DeleteAsync(id);

            return Ok();
        }

        [HttpGet("{id}/items")]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItems(int id)
        {
            var items = await _orderItemService.GetItemsByOrderIdAsync(id);

            return Ok(items);
        }

        [HttpPost("{id}/items")]
        public async Task<ActionResult<OrderItem>> AddOrderItem(int id, [FromBody] OrderItemDto orderItemDto)
        {
            var createdItem = await _orderItemService.AddItemToOrderAsync(id, orderItemDto);

            return CreatedAtAction(nameof(GetOrderItems), new { id }, createdItem);
        }

        [HttpPut("{id}/items/{itemId}")]
        public async Task<IActionResult> UpdateOrderItem(int id, int itemId, [FromBody] OrderItemDto orderItemDto)
        {
            await _orderItemService.UpdateOrderItemAsync(id, itemId, orderItemDto);

            return Ok();
        }

        [HttpDelete("{id}/items/{itemId}")]
        public async Task<IActionResult> DeleteOrderItem(int id, int itemId)
        {
            await _orderItemService.DeleteOrderItemAsync(id, itemId);

            return Ok();
        }
    }
}
