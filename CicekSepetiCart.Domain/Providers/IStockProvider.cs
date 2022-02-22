using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepetiCart.Domain.Providers
{
    public interface IStockProvider
    {
        Task<bool> CheckIfEnoughStock(string productId, int quantity);
    }
}
