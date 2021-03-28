using System;
using AutoMapper;
using MMT.Application.Features.Order.Commands;
using MMT.Application.Models;
using MMT.Domain.Entities;

namespace MMT.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DateTime?, string>().ConvertUsing<DateTimeToStringFormatter>();

            CreateMap<Orderitem, ProductVm>()
                .ForMember(dest=>dest.Product,
                opt=> opt.MapFrom(source=>source.Product.Productname))
                .ForMember(dest=>dest.PriceEach,
                    opt=>opt.MapFrom(source=>source.Price));
            
            CreateMap<Order, OrderDetailsVm>()
                .ForMember(dest => dest.OrderNumber,
                    opt => opt.MapFrom(source => source.Orderid)); ;

            CreateMap<Customer, CustomerDetailsVm>();
        }
    }
}
