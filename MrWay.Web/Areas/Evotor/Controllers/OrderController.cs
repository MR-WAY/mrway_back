using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MrWay.Data.Infrastructure.Context;
using MrWay.Domain.DomainModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrWay.Web.Areas.Evotor.Controllers
{
    [Area("Evotor")]
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
        public List<EvotorOrderDto> Orders()
        {
            var orders = context.Orders
                .Where(x => x.OrderStatus == OrderStatus.Untreated)
                .Include(x => x.Lines)
                .ThenInclude(y => y.Product)
                .ToList();

            var dto = new List<EvotorOrderDto>();

            foreach(var order in orders)
            {
                var orderDto = new EvotorOrderDto()
                {
                    Id = order.Id,
                    DeliveryStatus = order.DeliveryStatus,
                    OrderStatus = order.OrderStatus,
                    Lines = new List<EvotorOrderLineDto>()
                };

                foreach (var line in order.Lines)
                {
                    orderDto.Lines.Add(new EvotorOrderLineDto
                    {
                        ProductUuid = line.Product.uuid,
                        Quantity = line.Quantity
                    });
                }
            }

            return dto;
        }
    }
}
