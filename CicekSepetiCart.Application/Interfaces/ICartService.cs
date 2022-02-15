using CicekSepetiCart.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepetiCart.Application.Interfaces
{
    public interface ICartService
    {
        Task<CartItemModel> AddCartItem(CartItemModel model);
        Task<List<CartItemModel>> GetItemsByUserId(string userId);
    }
}
