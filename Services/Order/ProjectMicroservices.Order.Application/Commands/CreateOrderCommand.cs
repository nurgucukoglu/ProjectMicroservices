using Ecommerce.Shared.Dtos;
using MediatR;
using ProjectMicroservices.Order.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMicroservices.Order.Application.Commands
{
    public class CreateOrderCommand: IRequest<ResponseDto<CreatedOrderDto>>
    {
        public string BuyerId { get; set; }
        public AddressDto Address { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
