using KDSOrderManagement.Models.Dtos;
using KDSOrderManagement.Models.Entities;
using KDSOrderManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace KDSOrderManagement.Controllers
{
    [Route("orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IOrderItemService _orderItemService;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrderService orderService, IOrderItemService orderItemService, ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _orderItemService = orderItemService;
            _logger = logger;
        }

        [Authorize]
        [HttpGet]
        [SwaggerOperation(
            Summary = "Get All Orders",
            Description = "Get Orders",
            OperationId = "Get Orders",
            Tags = new[] { "Orders" }
        )]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            try
            {
                var orders = await _orderService.GetAllAsync();

                return Ok(orders);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { ErrorMessage = "An error occurred while processing the request." });
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get Order by Id",
            Description = "Get Order by Id",
            OperationId = "Get Order by Id",
            Tags = new[] { "Order" }
        )]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            try
            {
                var order = await _orderService.GetByIdAsync(id);

                if (order == null)
                {
                    return NotFound(new { ErrorMessage = $"Order with ID {id} was not found." });
                }

                return Ok(order);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { ErrorMessage = "An error occurred while processing the request." });
            }
        }

        [Authorize]
        [HttpPost]
        [SwaggerOperation(
            Summary = "Create order",
            Description = "Create order",
            OperationId = "Create order",
            Tags = new[] { "Order" }
        )]
        public async Task<ActionResult<Order>> CreateOrder([FromBody] OrderDto orderDto)
        {
            try
            {
                var createdOrder = await _orderService.CreateAsync(orderDto);

                return Ok(createdOrder);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { ErrorMessage = "An error occurred while processing the request.", Description = ex.Message });
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update order",
            Description = "Update order",
            OperationId = "Update order",
            Tags = new[] { "Order" }
        )]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] OrderDto orderDto)
        {
            try
            {
                await _orderService.UpdateAsync(id, orderDto);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { ErrorMessage = "An error occurred while processing the request.", Description = ex.Message });
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Delete order",
            Description = "Delete order",
            OperationId = "Delete order",
            Tags = new[] { "Order" }
        )]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {
                await _orderService.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { ErrorMessage = "An error occurred while processing the request." });
            }
        }

        [Authorize]
        [HttpGet("{id}/items")]
        [SwaggerOperation(
            Summary = "Get items by order",
            Description = "Get items by order",
            OperationId = "Get items by order",
            Tags = new[] { "Items" }
        )]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItems(int id)
        {
            try
            {
                var items = await _orderItemService.GetItemsByOrderIdAsync(id);

                return Ok(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { ErrorMessage = "An error occurred while processing the request." });
            }
        }

        [Authorize]
        [HttpPost("{id}/items")]
        [SwaggerOperation(
            Summary = "Add item by order",
            Description = "Add item by order",
            OperationId = "Add item by order",
            Tags = new[] { "Items" }
        )]
        public async Task<ActionResult<OrderItem>> AddOrderItem(int id, [FromBody] OrderItemDto orderItemDto)
        {
            try
            {
                var createdItem = await _orderItemService.AddItemToOrderAsync(id, orderItemDto);

                return Ok(createdItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { ErrorMessage = "An error occurred while processing the request." });
            }
        }

        [Authorize]
        [HttpPut("{id}/items/{itemId}")]
        [SwaggerOperation(
            Summary = "Update item by order",
            Description = "Update item by order",
            OperationId = "Update item by order",
            Tags = new[] { "Items" }
        )]
        public async Task<IActionResult> UpdateOrderItem(int id, int itemId, [FromBody] OrderItemDto orderItemDto)
        {
            try
            {
                await _orderItemService.UpdateOrderItemAsync(id, itemId, orderItemDto);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { ErrorMessage = "An error occurred while processing the request." });
            }
        }

        [Authorize]
        [HttpDelete("{id}/items/{itemId}")]
        [SwaggerOperation(
            Summary = "Delete item by order",
            Description = "Delete item by order",
            OperationId = "Delete item by order",
            Tags = new[] { "Items" }
        )]
        public async Task<IActionResult> DeleteOrderItem(int id, int itemId)
        {
            try
            {
                await _orderItemService.DeleteOrderItemAsync(id, itemId);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new { ErrorMessage = "An error occurred while processing the request." });
            }
        }
    }
}
