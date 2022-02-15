using AutoMapper;
using CicekSepetiCart.API.ViewModels;
using CicekSepetiCart.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicekSepetiCart.API.Mapper
{
    public class CartApiMapperProfile : Profile
    {
        public CartApiMapperProfile()
        {
            CreateMap<CartItemViewModel, CartItemModel>().ReverseMap();
        }
    }
}
