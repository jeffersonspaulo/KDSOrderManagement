using FluentValidation;
using KDSOrderManagement.Data.Repositories.Interfaces;
using KDSOrderManagement.Models.Dtos;
using KDSOrderManagement.Models.Entities;
using KDSOrderManagement.Services.Interfaces;
using KDSOrderManagement.Validators;

namespace KDSOrderManagement.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _orderRepository.GetAllWithIncludesAsync(i => i.Items);
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _orderRepository.GetByIdWithIncludesAsync(id, i => i.Items);
        }

        public async Task<Order> CreateAsync(OrderDto orderDto)
        {
            Validate(orderDto);

            var order = new Order
            {
                CustomerName = orderDto.CustomerName,
                OrderTime = orderDto.OrderTime,
                Status = orderDto.Status
            };

            return await _orderRepository.AddAsync(order);
        }

        public async Task UpdateAsync(int id, OrderDto orderDto)
        {
            Validate(orderDto);

            var order = await _orderRepository.GetByIdAsync(id);

            if (order == null)
            {
                throw new Exception($"Order with ID {id} not found.");
            }

            order.CustomerName = orderDto.CustomerName;
            order.OrderTime = orderDto.OrderTime;
            order.Status = orderDto.Status;

            await _orderRepository.UpdateAsync(order);
        }

        public async Task DeleteAsync(int id)
        {
            await _orderRepository.DeleteAsync(id);
        }

        private void Validate(OrderDto orderDto)
        {
            var validator = new OrderValidator();
            var resultValidator = validator.Validate(orderDto);

            if (!resultValidator.IsValid)
            {
                throw new ValidationException(resultValidator.Errors);
            }
        }
    }
}
