using FluentValidation;
using KDSOrderManagement.Data.Repositories;
using KDSOrderManagement.Data.Repositories.Interfaces;
using KDSOrderManagement.Models.Dtos;
using KDSOrderManagement.Models.Entities;
using KDSOrderManagement.Services.Interfaces;
using KDSOrderManagement.Validators;

namespace KDSOrderManagement.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemService(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<IEnumerable<OrderItem>> GetItemsByOrderIdAsync(int id)
        {
            return await _orderItemRepository.GetItemsByOrderIdAsync(id);
        }

        public async Task<OrderItem> AddItemToOrderAsync(int orderId, OrderItemDto orderItemDto)
        {
            Validate(orderItemDto);

            var orderItem = new OrderItem
            {
                Name = orderItemDto.Name,
                Quantity = orderItemDto.Quantity,
                Notes = orderItemDto.Notes
            };

            return await _orderItemRepository.AddItemAsync(orderId, orderItem);
        }

        public async Task UpdateOrderItemAsync(int orderId, int orderItemId, OrderItemDto orderItemDto)
        {
            Validate(orderItemDto);

            //TODO: Verificar atualizar item de um pedido... 
            var orderItem = await _orderItemRepository.GetByIdAsync(orderItemId);

            if (orderItem == null)
            {
                throw new Exception($"Order Item with ID {orderItemId} not found.");
            }

            orderItem.Name = orderItemDto.Name;
            orderItem.Quantity = orderItemDto.Quantity;
            orderItem.Notes = orderItemDto.Notes;

            await _orderItemRepository.UpdateItemAsync(orderItem);
        }

        public async Task DeleteOrderItemAsync(int orderId, int orderItemId)
        {
            await _orderItemRepository.DeleteItemAsync(orderId, orderItemId);
        }

        private void Validate(OrderItemDto orderItemDto)
        {
            var validator = new OrderItemValidator();
            var resultValidator = validator.Validate(orderItemDto);

            if (!resultValidator.IsValid)
            {
                throw new ValidationException(resultValidator.Errors);
            }
        }
    }
}
