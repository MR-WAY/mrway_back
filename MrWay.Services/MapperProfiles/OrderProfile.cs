using AutoMapper;
using MrWay.Domain.DataTransferObjects;
using MrWay.Domain.DataTransferObjects.Order;
using MrWay.Domain.DomainModels.Order;
using MrWay.Domain.DomainModels.Retail;
using System;
using System.Collections.Generic;
using System.Text;

namespace MrWay.Services.MapperProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<CreateOrderDto, OrderLine>();

            CreateMap<Order, OrderDto>();

            CreateMap<OrderLine, OrderLineDto>();

            CreateMap<Product, ProductDto>();
        }
    }
}
