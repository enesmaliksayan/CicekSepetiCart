using CicekSepetiCart.Domain.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepetiCart.Infrastructure.Providers
{
    public class StockProvider : IStockProvider
    {
        public async Task<bool> CheckIfEnoughStock(string productId, int quantity)
        {
            // StockService Request
            return true;
        }
    }
}
