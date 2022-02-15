using CicekSepetiCart.Domain.Entities;
using CicekSepetiCart.Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepetiCart.Domain.Repositories
{
    public interface ICartRepository:IRepository<CartItem>
    {
        Task<List<CartItem>> GetByUserIdAsync(string userId);
    }
}
