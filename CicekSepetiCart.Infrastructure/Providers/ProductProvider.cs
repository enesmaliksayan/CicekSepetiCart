using CicekSepetiCart.Domain.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepetiCart.Infrastructure.Providers
{
    public class ProductProvider : IProductProvider
    {
        public async Task<bool> CheckIfProductExists(string productId)
        {
            // ProductService Request
            return true;
        }
    }
}
