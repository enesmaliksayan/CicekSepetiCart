using CicekSepetiCart.Domain.Entities;
using CicekSepetiCart.Domain.Repositories;
using CicekSepetiCart.Infrastructure.Data;
using CicekSepetiCart.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepetiCart.Infrastructure.Repositories
{
    public class CartRepository : Repository<CartItem>, ICartRepository
    {
        public CartRepository(CartDbContext cartDbContext) : base(cartDbContext) { }
       
        public async Task<List<CartItem>> GetByUserIdAsync(string userId)
        {
            return await _cartDbContext.CartItems.Where(q => q.UserId == userId).ToListAsync();
        }
    }
}
