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

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
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
        public async Task<ActionResult<Order>> CreateOrder([FromBody] Order order)
        {
            var createdOrder = await _orderService.CreateAsync(order);

            return CreatedAtAction(nameof(GetOrder), new { id = createdOrder.Id }, createdOrder);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            await _orderService.UpdateAsync(order);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _orderService.DeleteAsync(id);

            return NoContent();
        }

        [HttpGet("{id}/items")]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItems(int id)
        {
            var items = await _orderService.GetItemsByOrderIdAsync(id);

            return Ok(items);
        }

        [HttpPost("{id}/items")]
        public async Task<ActionResult<OrderItem>> AddOrderItem(int id, [FromBody] OrderItem item)
        {
            var createdItem = await _orderService.AddItemToOrderAsync(id, item);

            return CreatedAtAction(nameof(GetOrderItems), new { id }, createdItem);
        }

        [HttpPut("{id}/items/{itemId}")]
        public async Task<IActionResult> UpdateOrderItem(int id, int itemId, [FromBody] OrderItem item)
        {
            await _orderService.UpdateOrderItemAsync(item);

            return Ok();
        }

        [HttpDelete("{id}/items/{itemId}")]
        public async Task<IActionResult> DeleteOrderItem(int id, int itemId)
        {
            await _orderService.DeleteOrderItemAsync(id, itemId);

            return Ok();
        }
    }
}
