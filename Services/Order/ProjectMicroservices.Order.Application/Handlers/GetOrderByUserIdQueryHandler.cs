using AutoMapper;
using Ecommerce.Shared.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectMicroservices.Order.Application.Dtos;
using ProjectMicroservices.Order.Application.Queries;
using ProjectMicroservices.Order.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectMicroservices.Order.Application.Handlers
{
    public class GetOrderByUserIdQueryHandler : IRequestHandler<GetOrdersByUserIdQuery,ResponseDto<List<OrderDto>>>
    {
        private readonly OrderDbContext _orderDbContext;
        private readonly IMapper _mapper;

        public GetOrderByUserIdQueryHandler(OrderDbContext orderDbContext, IMapper mapper)
        {
            _orderDbContext = orderDbContext;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<OrderDto>>> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderDbContext.Orders.Include(x => x.OrderItems).Where(x => x.BuyerId == request.UserId).ToListAsync(); 
          
           
                return ResponseDto<List<OrderDto>>.Success(_mapper.Map<List<OrderDto>>(orders), 200);
           
        }
    }
}
