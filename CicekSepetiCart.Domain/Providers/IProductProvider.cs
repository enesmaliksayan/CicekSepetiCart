using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepetiCart.Domain.Providers
{
    public interface IProductProvider
    {
        Task<bool> CheckIfProductExists(string productId);
    }
}
