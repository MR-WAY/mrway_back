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

        [HttpPost]
        public void Create([FromBody] List<CreateOrderDto> dto)
        {
            var order = new Order
            {
                Id = SeqGuid.New(),
                OrderStatus = OrderStatus.Untreated,
                DeliveryStatus = DeliveryStatus.Untreated,
                Lines = mapper.Map<List<OrderLine>>(dto)
            };

            order.Lines.ForEach(x => x.Id = SeqGuid.New());

            context.Orders.Add(order);
        }
    }
}
