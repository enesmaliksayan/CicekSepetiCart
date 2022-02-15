using AutoMapper;
using CicekSepetiCart.Application.Models;
using CicekSepetiCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepetiCart.Application.Mapper
{
    public class CartItemMapperProfile : Profile
    {
        public CartItemMapperProfile()
        {
            CreateMap<CartItem, CartItemModel>().ReverseMap().ConstructUsing(x => new CartItem());
        }
    }
}
