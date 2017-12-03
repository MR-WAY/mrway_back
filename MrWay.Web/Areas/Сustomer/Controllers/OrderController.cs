using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MrWay.Data.Infrastructure.Context;
using MrWay.Domain.DataTransferObjects.Order;
using MrWay.Domain.DomainModels;
using MrWay.Domain.DomainModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrWay.Web.Areas.Сustomer.Controllers
{
    [Area("Customer")]
    [Route("api/[area]/[controller]")]
    public class OrderController : Controller
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public OrderController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public void Create()
        {
            var order = new Order
            {
                Id = SeqGuid.New(),
                OrderStatus = OrderStatus.Untreated,
                DeliveryStatus = DeliveryStatus.Untreated,
                Latitude = 55.6762,
                Longitude = 37.6317,
                Lines = new List<OrderLine>()
                {
                    new OrderLine
                    {
                        ProductId = Guid.Parse("21042be4-cd11-4d04-b821-88ec2f5d4266"),
                        Quantity = 10
                    },
                    new OrderLine
                    {
                        ProductId = Guid.Parse("645a8b6e-d914-4fb2-9344-b0a0a459a274"),
                        Quantity = 4   
                    }
                }
            };

            order.Lines.ForEach(x => x.Id = SeqGuid.New());

            context.Orders.Add(order);
        }
    }
}
