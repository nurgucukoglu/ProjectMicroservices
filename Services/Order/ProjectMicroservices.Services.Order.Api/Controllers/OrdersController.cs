﻿using Ecommerce.Shared.ControllerBases;
using Ecommerce.Shared.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectMicroservices.Order.Application.Commands;
using ProjectMicroservices.Order.Application.Queries;
using System.Threading.Tasks;

namespace ProjectMicroservices.Services.Order.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : CustomBaseController
    {
        private readonly IMediator _mediator;
        private readonly ISharedIdentityService _sharedIdentityService;

        public OrdersController(IMediator mediator, ISharedIdentityService sharedIdentityService)
        {
            _mediator = mediator;
            _sharedIdentityService = sharedIdentityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var response = await _mediator.Send(new GetOrdersByUserIdQuery
            {
                UserId = _sharedIdentityService.GetUserId
            });
            return CreateResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrder(CreateOrderCommand createOrderCommand)
        {
            var response= await _mediator.Send(createOrderCommand);
            return CreateResultInstance(response);
        }
    }
}
