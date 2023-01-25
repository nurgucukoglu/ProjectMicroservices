using Ecommerce.Shared.Dtos;
using MediatR;
using ProjectMicroservices.Order.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMicroservices.Order.Application.Queries
{
    public class GetOrdersByUserIdQuery:IRequest<ResponseDto<List<OrderDto>>>
    {
        public string UserId { get; set; }
    }
}
