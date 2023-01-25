using Ecommerce.Shared.Dtos;
using MediatR;
using ProjectMicroservices.Order.Application.Commands;
using ProjectMicroservices.Order.Application.Dtos;
using ProjectMicroservices.Order.Domain.OrderAggregate;
using ProjectMicroservices.Order.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectMicroservices.Order.Application.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<Commands.CreateOrderCommand, ResponseDto<CreatedOrderDto>>
    {
        private readonly OrderDbContext _orderDbContext;

        public CreateOrderCommandHandler(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public async Task<ResponseDto<CreatedOrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var newAddress = new Address(request.Address.City, request.Address.Street, request.Address.District, request.Address.ZipCode);

            Domain.OrderAggregate.Order newOrder = new Domain.OrderAggregate.Order(request.BuyerId, newAddress);
            request.OrderItems.ForEach(x =>
            {
                newOrder.AddOrderItem(x.ProductId, x.Name, x.Price, x.PictureURL);

            });
            await _orderDbContext.Orders.AddAsync(newOrder);
            await _orderDbContext.SaveChangesAsync();

            return ResponseDto<CreatedOrderDto>.Success(new CreatedOrderDto { OrderId = newOrder.Id },204 );
        }
    }
}
