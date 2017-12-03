using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MrWay.Data.Infrastructure.Context;
using MrWay.Domain.DataTransferObjects;
using MrWay.Domain.DataTransferObjects.Order;
using MrWay.Domain.DomainModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrWay.Web.Areas.Сourier.Controllers
{
    [Area("Courier")]
    [Route("api/[area]/[controller]")]
    public class OrderController
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public OrderController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public List<OrderDto> Orders()
        {
            var store = context.Stores.First();
            var orders = context.Orders
                .Include(x => x.Lines)
                .ToList();

            var dto = mapper.Map<List<OrderDto>>(orders);
            dto.ForEach(x =>
            {
                x.Store = new CoordinatesDto
                {
                    Latitude = store.Latitude,
                    Longitude = store.Longitude
                };
            });

            return dto;
        }

        [HttpPost("Accept/{orderId:guid}")]
        public void Accept(Guid orderId)
        {
            var order = context.Orders.Single(x => x.Id == orderId);
            order.DeliveryStatus = DeliveryStatus.Accepted;
        }

        [HttpPost("TakeAway/{orderId:guid}")]
        public void TakeAway(Guid orderId)
        {
            var order = context.Orders.Single(x => x.Id == orderId);
            order.DeliveryStatus = DeliveryStatus.TakenAway;
        }

        [HttpPost("Delivery/{orderId:guid}")]
        public void Delivery(Guid orderId)
        {
            var order = context.Orders.Single(x => x.Id == orderId);
            order.DeliveryStatus = DeliveryStatus.Delivered;
        }
    }
}
