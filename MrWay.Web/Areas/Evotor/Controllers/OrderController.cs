using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MrWay.Data.Infrastructure.Context;
using MrWay.Domain.DataTransferObjects.Order;
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
                .Where(x => x.OrderStatus == OrderStatus.Untreated || x.DeliveryStatus == DeliveryStatus.Accepted || x.IsCompleted == false)
                .Include(x => x.Lines)
                .ThenInclude(y => y.Product)
                .ToList();

            var dto = new List<EvotorOrderDto>();

            foreach(var order in orders)
            {
                var orderDto = new EvotorOrderDto()
                {
                    Id = order.Id,
                    Code = order.Code,
                    IsCompleted = order.IsCompleted,
                    DeliveryStatus = order.DeliveryStatus,
                    OrderStatus = order.OrderStatus,
                    Lines = new List<EvotorOrderLineDto>()
                };

                foreach (var line in order.Lines)
                {
                    orderDto.Cost += line.Product.Cost;
                    orderDto.Lines.Add(new EvotorOrderLineDto
                    {
                        ProductUuid = line.Product.uuid,
                        Quantity = line.Quantity,
                        Name = line.Product.Name,
                        Cost = line.Product.Cost
                    });
                }

                dto.Add(orderDto);
            }

            return dto;
        }

        [HttpPost("Pack")]
        public TakeAwayDto Accept([FromBody] TakeAwayDto dto)
        {
            var order = context.Orders.Single(x => x.Id == dto.Id);
            order.OrderStatus = OrderStatus.Packed;
            order.Code = dto.Code;

            return dto;
        }
    }
}
